using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Models.DTO
{
    public class CustomerQueueDTO
    {
        public long CustomerQueueId { get; set; }
        public long CustomerId { get; set; }
        public long TripId { get; set; }
        public long CompanyId { get; set; }
        public EnumQueueStatus EnumQueueStatus { get; set; }
        public string QueueStatus { get; set; }
        public DateTime CreatedDateTime { get; set; }
        // Add other properties as needed

        public string CustomerPhoneNumber { get; set; }
        public string TripPickupAddress { get; set; }
        public EnumTaxiSize EnumCalledTaxiSize { get; set; }
        public string CalledTaxiSize { get; set; }
    }
}