using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Models.DTO
{
    public class DriverQueueDTO
    {
        public long DriverQueueId { get; set; }
        public long DriverId { get; set; }
        public long? TripId { get; set; }
        public long CompanyId { get; set; }
        public EnumQueueStatus EnumQueueStatus { get; set; }
        public string QueueStatus { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        // Add other properties as needed

        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string DriverNumber { get; set; }
        public string? TripPickupAddress { get; set; }
    }
}