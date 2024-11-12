using Taxi_Backend.Data;

using Microsoft.EntityFrameworkCore;

using Taxi_Backend.Models.DBModels;

using Taxi_Backend.Models;

using Taxi_Backend.Models.DTO;

using Taxi_Backend.Mapper;



namespace Taxi_Backend.Managers

{

    public class DriverManager

    {

        private readonly TaxiDBContext ctx;

        private readonly TripManager tripManager;



        public DriverManager(TaxiDBContext ctx, TripManager tripManager)

        {

            this.ctx = ctx;

            this.tripManager = tripManager;

        }

        public async Task<(bool success, object response)> UpdateDriver(AppUser driver)

        {

            try

            {

                var existingDriver = await ctx.Users

                    .FirstOrDefaultAsync(d => d.Id == driver.Id && !d.IsArchived);



                if (existingDriver == null)

                    return (false, "Driver not found");



                existingDriver.FirstName = driver.FirstName;

                existingDriver.LastName = driver.LastName;

                existingDriver.PhoneNumber = driver.PhoneNumber;

                existingDriver.Email = driver.Email;

                existingDriver.DriverNumber = driver.DriverNumber;

                existingDriver.ModifiedDateTime = DateTime.UtcNow;



                ctx.Users.Update(existingDriver);

                await ctx.SaveChangesAsync();

                return (true, existingDriver);

            }

            catch (Exception ex)

            {

                return (false, $"Error updating driver: {ex.Message}");

            }

        }



        public async Task<(bool success, object response)> DeleteDriver(long driverId)

        {

            try

            {

                var driver = await ctx.Users.FindAsync(driverId);

                if (driver == null)

                    return (false, "Driver not found");



                driver.IsArchived = true;

                await ctx.SaveChangesAsync();

                return (true, "Driver archived successfully");

            }

            catch (Exception ex)

            {

                return (false, $"Error deleting driver: {ex.Message}");

            }

        }



        public async Task<(bool success, object response)> GetDriverById(long driverId)

        {

            try

            {

                var driver = await ctx.Users

                    .Include(d => d.Taxis)

                    .Include(d => d.DriverQueues)

                    .FirstOrDefaultAsync(d => d.Id == driverId && !d.IsArchived);



                if (driver == null)

                    return (false, "Driver not found");



                return (true, driver);

            }

            catch (Exception ex)

            {

                return (false, $"Error retrieving driver: {ex.Message}");

            }

        }



        public async Task<(int count, List<AppUser> items)> GetDrivers(Page page, long companyId)

        {

            try

            {

                var query = ctx.Users

                    .Where(d => !d.IsArchived && d.CompanyId == companyId);



                return await page.Get(query);

            }

            catch (Exception)

            {

                return (0, new List<AppUser>());

            }

        }



        public async Task<DriverQueue?> GetDriverQueueByDriverId(long driverId)

        {

            return await ctx.DriverQueue

                .Include(q => q.Driver)

                .Include(q => q.Trip)

                .FirstOrDefaultAsync(x => x.DriverId == driverId);

        }



        public async Task<(bool success, object response)> CreateDriverQueue(DriverQueue driverQueue)

        {

            try

            {

                var existingQueue = await GetDriverQueueByDriverId(driverQueue.DriverId);

                if (existingQueue != null)

                    return (false, "Driver already has an active queue");



                await ctx.DriverQueue.AddAsync(driverQueue);

                await ctx.SaveChangesAsync();



                var queueWithDetails = await ctx.DriverQueue

                    .Include(q => q.Driver)

                    .Include(q => q.Trip)

                    .FirstOrDefaultAsync(q => q.DriverQueueId == driverQueue.DriverQueueId);



                return (true, queueWithDetails);

            }

            catch (Exception ex)

            {

                return (false, $"Error creating driver queue: {ex.Message}");

            }

        }



        public async Task<(bool success, object response)> UpdateDriverQueue(DriverQueue driverQueue)

        {

            try

            {

                var existingQueue = await ctx.DriverQueue

                    .Include(q => q.Driver)

                    .Include(q => q.Trip)

                    .FirstOrDefaultAsync(q => q.DriverQueueId == driverQueue.DriverQueueId);



                if (existingQueue == null)

                    return (false, "Driver queue not found");



                existingQueue.QueueStatus = driverQueue.QueueStatus;

                existingQueue.Latitude = driverQueue.Latitude;

                existingQueue.Longitude = driverQueue.Longitude;

                existingQueue.TripId = driverQueue.TripId;

                existingQueue.DeclinedCount = driverQueue.DeclinedCount;

                existingQueue.CustomerQueueId = driverQueue.CustomerQueueId;

                existingQueue.DeclinedTime = DateTime.UtcNow;



                ctx.DriverQueue.Update(existingQueue);

                await ctx.SaveChangesAsync();



                return (true, existingQueue);

            }

            catch (Exception ex)

            {

                return (false, $"Error updating driver queue: {ex.Message}");

            }

        }



        public async Task<(bool success, object response)> DeleteDriverQueue(long driverQueueId)

        {

            try

            {

                var driverQueue = await ctx.DriverQueue.FindAsync(driverQueueId);

                if (driverQueue == null)

                    return (false, "Driver queue not found");



                ctx.DriverQueue.Remove(driverQueue);

                await ctx.SaveChangesAsync();

                return (true, "Driver queue removed successfully");

            }

            catch (Exception ex)

            {

                return (false, $"Error deleting driver queue: {ex.Message}");

            }

        }



        public async Task<(bool success, object response)> GetDriverQueueById(long driverQueueId)

        {

            try

            {

                var driverQueue = await ctx.DriverQueue

                    .Include(q => q.Driver)

                    .Include(q => q.Trip)

                    .FirstOrDefaultAsync(q => q.DriverQueueId == driverQueueId);



                if (driverQueue == null)

                    return (false, "Driver queue not found");



                return (true, driverQueue);

            }

            catch (Exception ex)

            {

                return (false, $"Error retrieving driver queue: {ex.Message}");

            }

        }



        public async Task<(int count, List<DriverQueue> items)> GetDriverQueues(Page page, long companyId)

        {

            try

            {

                var query = ctx.DriverQueue

                    .Include(q => q.Driver)

                    .Include(q => q.Trip)

                    .Where(q => q.CompanyId == companyId);



                return await page.Get(query);

            }

            catch (Exception)

            {

                return (0, new List<DriverQueue>());

            }

        }

    }

}














