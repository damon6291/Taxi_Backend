using Microsoft.EntityFrameworkCore;
using USAddress;
using Taxi_Backend.Helper;
using Taxi_Backend.Data;
using Taxi_Backend.Models;
using Taxi_Backend.Models.Enums;
using Taxi_Backend.Services;

namespace Taxi_Backend.Managers
{
    public class TripManager
    {
        private readonly TaxiDBContext ctx;
        private readonly HubManager hubManager;
        private readonly IMapService mapService;

        public TripManager(TaxiDBContext ctx, HubManager hubManager, IMapService mapService)
        {
            this.ctx = ctx;
            this.hubManager = hubManager;
            this.mapService = mapService;
        }

        public async Task<Trip> GetTripByCustomerQueueID(long customerQueueId)
        {
            var trip = await ctx.CustomerQueue.Include(cq => cq.Trip).Where(cq => cq.CustomerQueueId == customerQueueId).Select(cq => cq.Trip).FirstOrDefaultAsync();
            return trip;
        }

        public async Task<Trip?> GetTripByID(long tripId)
        {
            try
            {
                var trip = await ctx.Trip.Where(x => x.TripId == tripId).FirstOrDefaultAsync();
                return trip;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        //public Trip CloneTrip(Trip trip)
        //{
        //    return new Trip()
        //    {
        //        CompanyID = trip.CompanyID,
        //        PickupLocationID = trip.PickupLocationID,
        //        TripStatus = trip.TripStatus,
        //        Notes = trip.Notes,
        //        CustomerPhoneNumber = trip.CustomerPhoneNumber,
        //        CalledTaxiSize = trip.CalledTaxiSize,
        //        TripType = trip.TripType,
        //    };
        //}

        //public Trip CloneTripForAlcohol(Trip trip)
        //{
        //    var newTrip = CloneTrip(trip);
        //    newTrip.AlcoholTripID = trip.TripID;
        //    newTrip.TripType = EnumTripType.ALCOHOL2;
        //    return newTrip;
        //}

        //public async Task MatchAlcoholTrip(Trip trip)
        //{
        //    if (trip.TripType == EnumTripType.ALCOHOL1 || trip.TripType == EnumTripType.ALCOHOL2)
        //    {
        //        var otherAlcoholTrip = await ctx.Trips.Include(x => x.Driver).Where(x => x.TripID == trip.AlcoholTripID).FirstOrDefaultAsync();
        //        if (otherAlcoholTrip != null && otherAlcoholTrip.DriverID != null)
        //        {
        //            var tripDriver = await ctx.Drivers.Where(x => x.DriverID == trip.DriverID).FirstOrDefaultAsync();
        //            otherAlcoholTrip.AlcoholPhoneNumber = tripDriver.PhoneNumber;
        //            trip.AlcoholPhoneNumber = otherAlcoholTrip.Driver.PhoneNumber;

        //            await ctx.SaveChangesAsync();

        //            await hubManager.SendToClient($"{Constants.DRIVER}{otherAlcoholTrip.DriverID}", Constants.ALCOHOLDRIVERMATCH, otherAlcoholTrip.TripID, otherAlcoholTrip.AlcoholPhoneNumber);
        //            await hubManager.SendToClient($"{Constants.DRIVER}{trip.DriverID}", Constants.ALCOHOLDRIVERMATCH, trip.TripID, trip.AlcoholPhoneNumber);
        //        }

        //    }
        //}


        public async Task<Trip?> GetCurrentTripCustomer(long customerId)
        {
            var customerQueue = await ctx.CustomerQueue.Include(x => x.Trip).Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
            if (customerQueue == null) return null;
            return customerQueue.Trip;
        }

        //public async Task<List<TripReturnForCompany>> GetCurrentTripsCompany(long companyID)
        //{
        //    var trips = await ctx.CustomerQueues
        //        .AsNoTracking()
        //        .Include(x => x.Trip)
        //        .Where(x => x.CompanyID == companyID)
        //        .Select(cq => new TripReturnForCompany
        //        {
        //            TripID = cq.Trip.TripID,
        //            TripStatus = cq.Trip.TripStatus,
        //            CreatedDateTime = cq.Trip.CreatedDateTime,
        //            PhoneNumber = cq.Trip.CustomerPhoneNumber,
        //            Notes = cq.Trip.Notes,
        //            CompanyTripPrice = cq.Trip.CompanyTripAmount,
        //            StartLocationId = cq.Trip.PickupLocationID,
        //            EndLocationId = cq.Trip.DropoffLocationID.Value,
        //            DriverId = cq.Trip.DriverID.Value,
        //        })
        //        .OrderBy(x => x.CreatedDateTime)
        //        .ToListAsync();

        //    var startLocationIds = trips.Select(trip => trip.StartLocationId).Where(id => id != null).Distinct().ToList();
        //    var endLocationIds = trips.Select(trip => trip.EndLocationId).Where(id => id != null).Distinct().ToList();
        //    var driverIds = trips.Select(trip => trip.DriverId).Where(id => id != null).Distinct().ToList();

        //    var startLocations = await ctx.GoogleLocations
        //        .Include(x => x.CompanyGoogleLocation)
        //        .AsNoTracking()
        //        .Where(gl => startLocationIds.Contains(gl.GoogleLocationID))
        //        .ToListAsync();

        //    var endLocations = await ctx.GoogleLocations
        //        .Include(x => x.CompanyGoogleLocation)
        //        .AsNoTracking()
        //        .Where(gl => endLocationIds.Contains(gl.GoogleLocationID))
        //        .ToListAsync();

        //    var drivers = await ctx.Drivers
        //        .AsNoTracking()
        //        .Include(d => d.Taxi)
        //        .Where(d => driverIds.Contains(d.DriverID))
        //        .ToListAsync();

        //    foreach (var trip in trips)
        //    {
        //        if (trip.StartLocationId != null)
        //        {
        //            var startLocation = startLocations.FirstOrDefault(gl => gl.GoogleLocationID == trip.StartLocationId);
        //            if (startLocation != null)
        //            {
        //                if (startLocation.CompanyGoogleLocation != null)
        //                {
        //                    trip.StartPreferredName = startLocation.CompanyGoogleLocation.Name;
        //                }
        //                trip.StartAddress = startLocation.Address;
        //                trip.StartName = startLocation.Name;
        //                trip.StartLatitude = startLocation.Latitude;
        //                trip.StartLongitude = startLocation.Longitude;
        //                trip.StartLocationType = startLocation.LocationType;
        //            }
        //        }
        //        if (trip.EndLocationId != null)
        //        {
        //            var endLocation = endLocations.FirstOrDefault(gl => gl.GoogleLocationID == trip.EndLocationId);
        //            if (endLocation != null)
        //            {
        //                if (endLocation.CompanyGoogleLocation != null)
        //                {
        //                    trip.EndPreferredName = endLocation.CompanyGoogleLocation.Name;
        //                }
        //                trip.EndAddress = endLocation.Address;
        //                trip.EndName = endLocation.Name;
        //                trip.EndLatitude = endLocation.Latitude;
        //                trip.EndLongitude = endLocation.Longitude;
        //                trip.EndLocationType = endLocation.LocationType;
        //            }
        //        }
        //        if (trip.DriverId != null)
        //        {
        //            var driver = drivers.FirstOrDefault(d => d.DriverID == trip.DriverId);
        //            if (driver != null)
        //            {
        //                trip.DriverNumber = driver.DriverNumber;
        //                trip.DriverPhoneNumber = driver.PhoneNumber;
        //                trip.Color = driver.Taxi?.Color;
        //                trip.Make = driver.Taxi?.Make;
        //                trip.Model = driver.Taxi?.Model;
        //                trip.LicensePlate = driver.Taxi?.LicensePlate;
        //            }
        //        }
        //    }

        //    return trips;
        //}
        //  public async Task<TripReturnForCompany> GetCurrentTripCompany(Trip trip)
        //  {

        //      var tripReturn = await ctx.CustomerQueues
        //        .AsNoTracking()
        //        .Include(x => x.Trip)
        //        .Where(x => x.TripID == trip.TripID)
        //        .Select(cq => new TripReturnForCompany
        //        {
        //            TripID = cq.Trip.TripID,
        //            TripStatus = cq.Trip.TripStatus,
        //            CreatedDateTime = cq.Trip.CreatedDateTime,
        //            PhoneNumber = cq.Trip.CustomerPhoneNumber,
        //            Notes = cq.Trip.Notes,
        //            CompanyTripPrice = cq.Trip.CompanyTripAmount,
        //            StartLocationId = cq.Trip.PickupLocationID,
        //            EndLocationId = cq.Trip.DropoffLocationID.Value,
        //            DriverId = cq.Trip.DriverID.Value,
        //        }).FirstOrDefaultAsync();


        //      if (tripReturn.StartLocationId != null)
        //      {
        //          var startLocation = await ctx.GoogleLocations
        //.Include(x => x.CompanyGoogleLocation)
        //.AsNoTracking()
        //.Where(gl => tripReturn.StartLocationId == gl.GoogleLocationID)
        //.FirstOrDefaultAsync();
        //          if (startLocation != null)
        //          {
        //              if (startLocation.CompanyGoogleLocation != null)
        //              {
        //                  tripReturn.StartPreferredName = startLocation.CompanyGoogleLocation.Name;
        //              }
        //              tripReturn.StartAddress = startLocation.Address;
        //              tripReturn.StartName = startLocation.Name;
        //              tripReturn.StartLatitude = startLocation.Latitude;
        //              tripReturn.StartLongitude = startLocation.Longitude;
        //              tripReturn.StartLocationType = startLocation.LocationType;
        //          }
        //      }
        //      if (tripReturn.EndLocationId != null)
        //      {
        //          var endLocation = await ctx.GoogleLocations
        //.Include(x => x.CompanyGoogleLocation)
        //.AsNoTracking()
        //.Where(gl => tripReturn.EndLocationId.Value == gl.GoogleLocationID)
        //.FirstOrDefaultAsync();

        //          if (endLocation != null)
        //          {
        //              if (endLocation.CompanyGoogleLocation != null)
        //              {
        //                  tripReturn.EndPreferredName = endLocation.CompanyGoogleLocation.Name;
        //              }
        //              tripReturn.EndAddress = endLocation.Address;
        //              tripReturn.EndName = endLocation.Name;
        //              tripReturn.EndLatitude = endLocation.Latitude;
        //              tripReturn.EndLongitude = endLocation.Longitude;
        //              tripReturn.EndLocationType = endLocation.LocationType;
        //          }
        //      }

        //      if (tripReturn.DriverId != null)
        //      {
        //          var driver = await ctx.Drivers
        //      .AsNoTracking()
        //      .Include(d => d.Taxi)
        //      .Where(d => tripReturn.DriverId.Value == d.DriverID)
        //      .FirstOrDefaultAsync();
        //          if (driver != null)
        //          {
        //              tripReturn.DriverNumber = driver.DriverNumber;
        //              tripReturn.DriverPhoneNumber = driver.PhoneNumber;
        //              tripReturn.Color = driver.Taxi?.Color;
        //              tripReturn.Make = driver.Taxi?.Make;
        //              tripReturn.Model = driver.Taxi?.Model;
        //              tripReturn.LicensePlate = driver.Taxi?.LicensePlate;
        //          }
        //      }
        //      return tripReturn;
        //  }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverID"></param>
        /// <param name="filterType">
        ///     0 = Today
        ///     1 = This Week
        ///     2 = This month
        ///     3 = Last month
        ///     4 = Everything
        /// </param>
        /// <returns></returns>
        //public async Task<List<Trip>> GetDriverRecentTrips(long driverID, int filterType = 4)
        //{
        //    List<Trip> trips = new List<Trip>();
        //    DateTime today = DateTime.Today;
        //    int offset = today.DayOfWeek - DayOfWeek.Monday;
        //    DateTime monday = today.AddDays(-offset);
        //    DateTime sunday = monday.AddDays(6);
        //    try
        //    {
        //        trips = await ctx.Trip.Include(x => x.Customer)
        //                   .Include(x => x.PickupLocation)
        //                   .Include(x => x.DropoffLocation)
        //                   .Include(x => x.Payment)
        //                   .Where(x => x.DriverID == driverID
        //                       && x.TripStatus == EnumTripStatus.COMPLETED
        //                       && x.Payment != null
        //                       && x.Payment.PaymentStatus == EnumPaymentStatus.PAID
        //                       && ((filterType == 0 && x.CreatedDateTime.Day == today.Day && x.CreatedDateTime.Month == today.Month && x.CreatedDateTime.Year == today.Year)
        //                       || (filterType == 1 && monday <= x.CreatedDateTime && x.CreatedDateTime <= sunday)
        //                       || (filterType == 2 && x.CreatedDateTime.Month == today.Month && x.CreatedDateTime.Year == today.Year)
        //                       || (filterType == 3 && x.CreatedDateTime.Month == today.AddMonths(-1).Month && x.CreatedDateTime.Year == today.AddMonths(-1).Year)
        //                       || (filterType == 4)))
        //                   .OrderByDescending(x => x.CreatedDateTime)
        //                   .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return trips;
        //}

        public async Task<CustomerQueue?> RemoveCustomerQueue(long customerId)
        {
            var customerQueue = await ctx.CustomerQueue.Where(x => customerId == x.CustomerId).FirstOrDefaultAsync();
            if (customerQueue == null) { return null; }
            ctx.CustomerQueue.Remove(customerQueue);
            await ctx.SaveChangesAsync();

            return customerQueue;
        }


        public async Task<CustomerQueue?> RemoveCustomerQueueByTripID(long tripId)
        {
            var customerQueue = await ctx.CustomerQueue.Where(x => x.TripId == tripId).FirstOrDefaultAsync();
            if (customerQueue == null) { return null; }
            ctx.CustomerQueue.Remove(customerQueue);
            await ctx.SaveChangesAsync();

            return customerQueue;
        }


        //public async Task<TripReturnForDriver> TripReturnForDriver(Trip trip)
        //{
        //    var ret = new TripReturnForDriver(trip);

        //    var start = await GetGoogleLocation(trip.PickupLocationID);
        //    if (start != null)
        //    {
        //        if (start.CompanyGoogleLocation != null)
        //        {
        //            ret.StartPreferredName = start.CompanyGoogleLocation.Name;
        //        }
        //        ret.StartName = start.Name;
        //        ret.StartAddress = start.Address;
        //        ret.StartLatitude = start.Latitude;
        //        ret.StartLongitude = start.Longitude;
        //    }

        //    var end = await GetGoogleLocation(trip.DropoffLocationID);
        //    if (end != null)
        //    {
        //        if (end.CompanyGoogleLocation != null)
        //        {
        //            ret.EndPreferredName = end.CompanyGoogleLocation.Name;
        //        }
        //        ret.EndName = end.Name;
        //        ret.EndAddress = end.Address;
        //        ret.EndLatitude = end.Latitude;
        //        ret.EndLongitude = end.Longitude;
        //    }

        //    var payment = await ctx.Payments.Where(x => x.TripID == trip.TripID).FirstOrDefaultAsync();
        //    if (payment != null)
        //    {
        //        ret.TripAmount = payment.FullAmount;
        //    }
        //    else
        //    {
        //        ret.TripAmount = trip.CompanyTripAmount;
        //    }

        //    var customer = await ctx.Customers.Where(x => x.CustomerID == trip.CustomerID).FirstOrDefaultAsync();
        //    if (customer != null)
        //    {
        //        ret.CustomerFirstName = customer.FirstName;
        //        ret.CustomerPhoneNumber = customer.PhoneNumber;
        //    }
        //    else
        //    {
        //        var company = await ctx.Companies.Where(x => x.CompanyID == trip.CompanyID).FirstOrDefaultAsync();
        //        ret.CustomerFirstName = company.Name;
        //        ret.CustomerPhoneNumber = trip.CustomerPhoneNumber;
        //    }

        //    return ret;
        //}








    }
}
