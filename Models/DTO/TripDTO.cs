using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Models.DTO
{
    public class TripDTO
    {
        public long TripId { get; set; }
        public long? DriverId { get; set; }
        public long CustomerId { get; set; }
        public long CompanyId { get; set; }
        public string PickupAddress { get; set; }
        public string? DropoffAddress { get; set; }
        public EnumTripStatus EnumTripStatus { get; set; }
        public EnumTaxiSize EnumCalledTaxiSize { get; set; }
        public string CalledTaxiSize { get; set; }
        public string TripStatus { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? CompletedTime { get; set; }
        // Add other properties as needed

        public string CustomerPhoneNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string DriverNumber { get; set; }
    }
}