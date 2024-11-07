using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Models.DBModels
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public EnumTimeZone TimeZone { get; set; } = EnumTimeZone.Eastern;
        public bool IsArchived { get; set; } = false;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public virtual ICollection<AppUser> Users { get; set; } = new HashSet<AppUser>();
        public virtual ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
        public virtual ICollection<DriverQueue> DriverQueues { get; set; } = new HashSet<DriverQueue>();
        public virtual ICollection<CustomerQueue> CustomerQueues { get; set; } = new HashSet<CustomerQueue>();
    }
}
