using System.ComponentModel.DataAnnotations.Schema;
using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerId { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public ICollection<CustomerQueue> CustomerQueues { get; set; } = new HashSet<CustomerQueue>();
        public ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();


    }
}
