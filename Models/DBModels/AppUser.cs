using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi_Backend.Models.DBModels
{
    public class AppUser : IdentityUser<long>
    {
        public long CompanyId { get; set; }
        public bool IsArchived { get; set; } = false;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Name => FirstName + " " + LastName;
        public string? DriverNumber { get; set; }

        public DateTime? LastLoginDateTime { get; set; }
        public long? CreatedUserId { get; set; }
        public long? ModifiedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDateTime { get; set; } = DateTime.UtcNow;

        [ForeignKey("CreatedUserId")]
        public virtual AppUser CreatedUser { get; set; }
        [ForeignKey("ModifiedUserId")]
        public virtual AppUser ModifiedUser { get; set; }
        public virtual Company Company { get; set; }

        public ICollection<DriverQueue> DriverQueues { get; set; } = new HashSet<DriverQueue>();
        public ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
        public ICollection<Taxi> Taxis { get; set; } = new HashSet<Taxi>();
        public ICollection<AppUserRole> UserRoles { get; set; } = new HashSet<AppUserRole>();


    }
}
