using Taxi_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Taxi_Backend.Models.DBModels;

namespace Taxi_Backend.Models
{
    public class CustomerQueue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerQueueId { get; set; }
        public long CustomerId { get; set; }
        public long TripId { get; set; }
        public long CompanyId { get; set; }
        public EnumQueueStatus QueueStatus { get; set; } = EnumQueueStatus.WAITING;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public virtual Customer Customer { get; set; }
        public virtual Company Company { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
