using Taxi_Backend.Data;
using Taxi_Backend.Models;
using Taxi_Backend.Models.Enums;
using Taxi_Backend.Services;
using Microsoft.EntityFrameworkCore;
using Taxi_Backend.Managers;

namespace Ta.Managers
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

        public async Task<DriverQueue?> GetDriverQueueByDriverID(long driverId)
        {
            var driverQueue = await ctx.DriverQueue.Where(x => x.DriverId == driverId).FirstOrDefaultAsync();
            return driverQueue;
        }



        //public async Task<DriverQueue> AddDriverToQueue(long driverId, LatLng loc)
        //{
        //    var newDriverQueue = new DriverQueue();
        //    newDriverQueue.DriverId = driverId;
        //    newDriverQueue.QueueStatus = EnumQueueStatus.WAITING;
        //    newDriverQueue.Latitude = loc.Latitude;
        //    newDriverQueue.Longitude = loc.Longitude;
        //    ctx.DriverQueue.Add(newDriverQueue);
        //    await ctx.SaveChangesAsync();
        //    return newDriverQueue;
        //}

        //public async Task<DriverQueue> ReAddDriverToQueue(long driverId)
        //{
        //    var prevQueue = await ctx.DriverQueue.Where(x => x.DriverId == driverId).FirstOrDefaultAsync();
        //    //RemoveFromQueue(driverId);
        //    var driverQueue = await AddDriverToQueue(driverId, new LatLng(prevQueue.Latitude, prevQueue.Longitude));
        //    return driverQueue;
        //}

        //public async Task<bool> RemoveFromQueue(long driverId, bool revertCustomerQueue = true)
        //{
        //    var driverQueues = ctx.DriverQueue.Where(x => x.DriverId == driverId);
        //    var customerQueueId = driverQueues.FirstOrDefault()?.CustomerQueueId;
        //    var customerQueue = ctx.CustomerQueue.Where(x => x.CustomerQueueId == customerQueueId).FirstOrDefault();
        //    if (customerQueue != null && revertCustomerQueue)
        //    {
        //        customerQueue.QueueStatus = EnumQueueStatus.WAITING;
        //    }
        //    var driverQueueRejectedCustomerQueues = ctx.DriverQueueRejectedCustomerQueues.Include(x => x.DriverQueue).Where(x => x.DriverQueue.DriverID == driverID);
        //    ctx.DriverQueueRejectedCustomerQueues.RemoveRange(driverQueueRejectedCustomerQueues);
        //    ctx.DriverQueues.RemoveRange(driverQueues);
        //    await ctx.SaveChangesAsync();
        //    return true;
        //}



    }
}
