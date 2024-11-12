using Taxi_Backend.Data;
using Taxi_Backend.Hubs;
using Taxi_Backend.Models;
using Taxi_Backend.Models.Enums;
using Taxi_Backend.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using USAddress;
using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Mapper;

namespace Taxi_Backend.Managers
{
    public class BackgroundManager
    {
        private readonly TaxiDBContext ctx;
        private readonly IServiceScopeFactory factory;
        private readonly IHubContext<TaxiHub> hubContext;
        private readonly TripManager tripManager;
        private readonly HubManager hubManager;

        public BackgroundManager(TaxiDBContext ctx, IServiceScopeFactory factory, IHubContext<TaxiHub> hubContext, TripManager tripManager, HubManager hubManager)
        {
            this.ctx = ctx;
            this.factory = factory;
            this.hubContext = hubContext;
            this.tripManager = tripManager;
            this.hubManager = hubManager;
        }


        /// <summary>
        /// This is to take care of a bug where Customer queue is pending forever.
        /// </summary>
        /// <returns></returns>
        public async Task RemovePendingCustomerQueue()
        {
            try
            {
                var curTime = DateTime.UtcNow.AddMinutes(-30);
                var customerQueues = ctx.CustomerQueue
                    .Include(x => x.Trip)
                    .Where(x => x.QueueStatus == EnumQueueStatus.PENDING && x.CreatedDateTime < curTime);

                var trips = customerQueues.Select(x => x.Trip);

                ctx.RemoveRange(trips);
                ctx.RemoveRange(customerQueues);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred while removing pending customer queues: {ex.Message}");
                // Optionally log the exception or handle it as needed
            }
        }

        /// <summary>
        /// If driver canceled the trip and customer does not respond for 1 hours, (They can call a new taxi) customer makes full payment
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RemoveDriverCanceledCustomerQueue()
        {
            try
            {
                var customerQueues = ctx.CustomerQueue
                .Include(x => x.Trip)
                .Where(x => x.QueueStatus == EnumQueueStatus.DRIVERCANCELED);

                var trips = customerQueues.Select(x => x.Trip);

                ctx.RemoveRange(trips);
                ctx.RemoveRange(customerQueues);
                await ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred while removing driver-canceled customer queues: {ex.Message}");
                // Optionally log the exception or handle it as needed
                return false;
            }
        }

        public async Task<bool> MatchAllCustomerAndDriverQueues()
        {
            var companies = await ctx.DriverQueue
                .Where(x => x.QueueStatus == EnumQueueStatus.WAITING)
                .Select(x => x.CompanyId)
                .Distinct()
                .ToListAsync();

            try
            {
                // Run parallel processing for each company
                var tasks = companies.Select(companyId => MatchCustomerAndDriverQueue(companyId));
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred during matching: {ex.Message}");
                return false;
            }

            return true;
        }

        private async Task MatchCustomerAndDriverQueue(long companyId)
        {
            using (var scope = factory.CreateScope())
            {
                var scopedCtx = scope.ServiceProvider.GetRequiredService<TaxiDBContext>();

                var driverQueues = await scopedCtx.DriverQueue
                    .Include(x => x.Driver)
                    .Where(x => x.QueueStatus == EnumQueueStatus.WAITING && x.CompanyId == companyId)
                    .OrderBy(x => x.CreatedDateTime)
                    .ToListAsync();

                var customerQueues = await scopedCtx.CustomerQueue
                    .Include(x => x.Trip)
                    .Where(x => x.QueueStatus == EnumQueueStatus.WAITING && x.CompanyId == companyId)
                    .OrderBy(x => x.CreatedDateTime)
                    .ToListAsync();

                foreach (var dq in driverQueues)
                {
                    await MatchDriverWithCustomer(dq, customerQueues, scopedCtx);
                }
            }
        }

        private async Task MatchDriverWithCustomer(DriverQueue dq, List<CustomerQueue> customerQueues, TaxiDBContext scopedCtx)
        {
            foreach (var cq in customerQueues)
            {
                if (dq.CompanyId != cq.CompanyId) continue;
                if (dq.QueueStatus != EnumQueueStatus.WAITING) continue;
                if (cq.QueueStatus != EnumQueueStatus.WAITING) continue;

                //var distance = GeoCalculator.GetDistance(dq.Latitude, dq.Longitude, cq.Trip.PickupLocation.Latitude, cq.Trip.PickupLocation.Longitude);
                var distance = 3;

                if (distance > Constants.TRIP_MATCH_MILE_RANGE) continue;
                if (dq.QueueStatus != EnumQueueStatus.WAITING) continue;
                if (cq.QueueStatus != EnumQueueStatus.WAITING) continue;

                dq.QueueStatus = EnumQueueStatus.PENDING;
                dq.TripId = cq.TripId;
                cq.QueueStatus = EnumQueueStatus.PENDING;
                cq.Trip.TripStatus = EnumTripStatus.QUEUE;
                await scopedCtx.SaveChangesAsync();

                //var tripReturnForDriver = await tripManager.TripReturnForDriver(cq.Trip);
                //await hubManager.SendToClient($"{Constants.DRIVER}{dq.DriverId}", Constants.MATCH, cq.Trip.TripStatus, tripReturnForDriver);

                break;
            }
        }

        private void AddToBackgroundHistory(int cqCount, int dqCount, int successCount, int errorCount, bool err, string errMsg, string process)
        {
            var background = new BackgroundHistory()
            {
                CustomerQueueCount = cqCount,
                DriverQueueCount = dqCount,
                SuccessAmount = successCount,
                ErrorAmount = errorCount,
                Error = errMsg,
                IsSuccess = err,
                Process = process,
                CreatedDateTime = DateTime.UtcNow,
            };
            ctx.BackgroundHistory.Add(background);
            ctx.SaveChanges();

        }

    }
}
