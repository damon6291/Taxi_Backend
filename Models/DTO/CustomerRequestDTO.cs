using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Models.DTO
{
    public class CustomerRequestDTO
    {
        // Customer Information
        public long CustomerId { get; set; }
        public string? CustomerPhoneNumber { get; set; }

        // Trip Information
        public string PickupAddress { get; set; }
        public string DropoffAddress { get; set; }
        public EnumTaxiSize CalledTaxiSize { get; set; }
        public string? Notes { get; set; }

        // Queue Information
        public long CompanyId { get; set; }
    }
}