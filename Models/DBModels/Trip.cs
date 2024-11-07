
using Taxi_Backend.Helper;
using Taxi_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Taxi_Backend.Models.DBModels;

namespace Taxi_Backend.Models
{
    public class Trip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TripId { get; set; }
        public long CustomerId { get; set; }
        public long CompanyId { get; set; }
        public long? DriverId { get; set; }
        public EnumTripStatus TripStatus { get; set; } = EnumTripStatus.QUEUE;
        public EnumTaxiSize CalledTaxiSize { get; set; }
        public string? PickupAddress { get; set; }
        public string? DroppOffAddress { get; set; }
        public decimal Mileage { get; set; } // ex) 4.5 miles to dest
        public string AlcoholPhoneNumber { get; set; } = string.Empty;
        public long? AlcoholTripId { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedTime { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual AppUser? Driver { get; set; }
        public virtual Company? Company { get; set; }
    }
}
