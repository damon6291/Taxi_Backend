using Taxi_Backend.Data;
using Taxi_Backend.Hubs;
using Taxi_Backend.Models;
using Taxi_Backend.Models.Enums;
using Taxi_Backend.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using USAddress;

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
            var curTime = DateTime.UtcNow.AddMinutes(-30);
            var customerQueues = ctx.CustomerQueue.Include(x => x.Trip).Where(x => x.QueueStatus == EnumQueueStatus.PENDING && x.CreatedDateTime < curTime);
            await ctx.BulkDeleteAsync(customerQueues);
        }

        /// <summary>
        /// If driver canceled the trip and customer does not respond for 1 hours, (They can call a new taxi) customer makes full payment
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RemoveDriverCanceledCustomerQueue()
        {
            var customerQueues = await ctx.CustomerQueue.Include(x => x.Trip).Where(x => x.QueueStatus == EnumQueueStatus.DRIVERCANCELED).ToListAsync();
            await ctx.BulkDeleteAsync(customerQueues);
            return true;
        }

        /// <summary>
        /// Trip matching algorithm
        /// </summary>
        /// <returns></returns>
        public async Task<bool> MatchTrip()
        {
            //var matchedTripCount = 0;
            //var error = string.Empty;
            //var driverQueues = await ctx.DriverQueue
            //    .Include(x => x.Driver)
            //        .ThenInclude(x => x.Company)
            //    .Include(x => x.Driver)
            //        .ThenInclude(x => x.Taxi)
            //    .Where(x => x.QueueStatus == EnumQueueStatus.WAITING)
            //    .OrderBy(x => x.CreatedDateTime)
            //    .ToListAsync();
            //var customerQueues = await ctx.CustomerQueue
            //    .Include(x => x.Trip)
            //    .OrderBy(x => x.CreatedDateTime)
            //    .Where(x => x.QueueStatus == EnumQueueStatus.WAITING).ToListAsync();

            //try
            //{
            //    foreach (var dq in driverQueues)
            //    {
            //        foreach (var cq in customerQueues)
            //        {
            //            // Is Queue Taken?
            //            if (cq.QueueStatus == EnumQueueStatus.PENDING) continue;
            //            if ((int)(DateTime.UtcNow - dq.DeclinedTime).TotalSeconds < Constants.DRIVER_MATCH_IDLE_TIME) continue;

            //            // Is Taxi Size the possible?
            //            if (dq.Driver.Taxi.Size < cq.Trip.CalledTaxiSize) continue;
            //            // if Trip never rejected?
            //            if (dq.DriverQueueRejectedCustomerQueues != null && dq.DriverQueueRejectedCustomerQueues.Count > 0)
            //            {
            //                if (dq.DriverQueueRejectedCustomerQueues.Any(x => x.CustomerQueueID == cq.CustomerQueueID)) continue;
            //            }



            //            if (cq.CompanyID != null)
            //            {
            //                //Company Restrictions
            //            }
            //            else
            //            {
            //                //Customer Restrictions

            //                //Driver is not eligible for app taxi. (only company allowed)
            //                if (!dq.Driver.IsAppTaxi) continue;

            //                // Is Trip Operatable state?
            //                if (!dq.Driver.Company.CompanyOperatingStates.Any(x => x.FromState == cq.Trip.PickupLocation.State && (x.ToState == null || x.ToState == cq.Trip.DropoffLocation.State))) continue;

            //                // Newyork Airport situation
            //                if ((cq.Trip.PickupLocation.LocationType == EnumLocationType.AIRPORT && (cq.Trip.PickupLocation.State == EnumState.NY || cq.Trip.PickupLocation.State == EnumState.NYC))
            //                    || (cq.Trip.DropoffLocation.LocationType == EnumLocationType.AIRPORT && (cq.Trip.DropoffLocation.State == EnumState.NY || cq.Trip.DropoffLocation.State == EnumState.NYC)))
            //                {
            //                    if (!dq.Driver.TLCApproved) continue;
            //                }

            //                // Is Close range?
            //                // This Distance is inaccurate. Change it to our own API later.
            //                var mile = GeoCalculator.GetDistance(dq.Latitude, dq.Longitude, cq.Trip!.PickupLocation!.Latitude, cq.Trip!.PickupLocation!.Longitude);
            //                var waitedTime = (int)(DateTime.UtcNow - cq.CreatedDateTime).TotalMinutes;
            //                if (mile > Constants.TRIP_MATCH_MILE_RANGE + waitedTime) continue;
            //            }

            //            // if match
            //            dq.QueueStatus = EnumQueueStatus.PENDING;
            //            dq.TripID = cq.TripID;
            //            dq.CustomerQueueID = cq.CustomerQueueID;
            //            cq.QueueStatus = EnumQueueStatus.PENDING;
            //            ctx.SaveChanges();
            //            matchedTripCount += 1;

            //            var tripReturnForDriver = await tripManager.TripReturnForDriver(cq.Trip);
            //            //notify driver
            //            await hubManager.SendToClient($"{Constants.DRIVER}{dq.DriverID}", Constants.MATCH, cq.Trip.TripStatus, tripReturnForDriver);

            //            break;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    error = ex.ToString();
            //}
            //finally
            //{
            //    var cqCount = customerQueues.Count();
            //    var dqCount = driverQueues.Count();
            //    var err = error != string.Empty;
            //    if ((cqCount != 0 && dqCount != 0) || err)
            //    {
            //        AddToBackgroundHistory(cqCount, dqCount, matchedTripCount, 0, err, error, "Matching");
            //    }

            //}

            return true;
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
