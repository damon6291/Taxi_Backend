using Taxi_Backend.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Taxi_Backend.Models.DBModels;

namespace Taxi_Backend.Models
{
    public class DriverQueue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DriverQueueId { get; set; }
        public long DriverId { get; set; }
        public long CompanyId { get; set; }
        public long? TripId { get; set; }
        public string? CustomerQueueId { get; set; } // comma separated list of CustomerQueue that was shown to the driver. Will not show these again
        public EnumQueueStatus QueueStatus { get; set; } = EnumQueueStatus.WAITING;
        public int? DeclinedCount { get; set; } = 0;
        [Column(TypeName = "decimal(9,6)")]
        public double Longitude { get; set; }
        [Column(TypeName = "decimal(8,6)")]
        public double Latitude { get; set; }
        public DateTime DeclinedTime { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public virtual AppUser Driver { get; set; }
        public virtual Company Company { get; set; }
        public virtual Trip? Trip { get; set; }
    }
}
