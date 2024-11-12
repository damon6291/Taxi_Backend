using Bogus.DataSets;
using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;

namespace Taxi_Backend.Mapper
{
    public static class TripMapper
    {
        public static TripDTO TripToDTO(Trip trip)
        {
            return new TripDTO()
            {
                TripId = trip.TripId,
                CustomerId = trip.CustomerId,
                DriverId = trip.DriverId,
                CompanyId = trip.CompanyId,
                PickupAddress = trip.PickupAddress,
                DropoffAddress = trip.DropoffAddress,
                EnumTripStatus = trip.TripStatus,
                EnumCalledTaxiSize = trip.CalledTaxiSize,
                TripStatus = trip.TripStatus.ToString(),
                CalledTaxiSize = trip.CalledTaxiSize.ToString(),
                CreatedDateTime = trip.CreatedDateTime,
                CompletedTime = trip.CompletedTime,
                CustomerPhoneNumber = trip.Customer?.PhoneNumber,
                DriverName = trip.Driver?.Name,
                DriverPhoneNumber = trip.Driver?.PhoneNumber,
                DriverNumber = trip.Driver?.DriverNumber
            };
        }

        public static Trip DTOToTrip(TripDTO dto)
        {
            return new Trip()
            {
                TripId = dto.TripId,
                CustomerId = dto.CustomerId,
                DriverId = dto.DriverId,
                CompanyId = dto.CompanyId,
                PickupAddress = dto.PickupAddress,
                DropoffAddress = dto.DropoffAddress,
                TripStatus = dto.EnumTripStatus,
                CalledTaxiSize = dto.EnumCalledTaxiSize,
                CreatedDateTime = dto.CreatedDateTime,
                CompletedTime = dto.CompletedTime
            };
        }
    }
}