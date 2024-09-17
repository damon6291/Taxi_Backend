using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class AppUser : IdentityUser<long>
    {
        public bool IsArchived { get; set; } = false;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Name => FirstName + " " + LastName;

        public DateTime? LastLoginDateTime { get; set; }
        public long? CompanyId { get; set; }
        public long CreatedUserId { get; set; }
        public long ModifiedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDateTime { get; set; } = DateTime.UtcNow;

        [ForeignKey("CreatedUserId")]
        public virtual AppUser CreatedUser { get; set; }
        [ForeignKey("ModifiedUserId")]
        public virtual AppUser ModifiedUser { get; set; }
        public virtual Company? Company { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserPermission> UserPermissions { get; set; } = new HashSet<UserPermission>();
        public virtual ICollection<UserPreference> UserPreferences { get; set; } = new HashSet<UserPreference>();
        public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        [InverseProperty("CreatedUser")]
        public virtual ICollection<PurchaseOrder> CreatedPurchaseOrders { get; set; } = new HashSet<PurchaseOrder>();
        [InverseProperty("ModifiedUser")]
        public virtual ICollection<PurchaseOrder> ModifiedPurchaseOrders { get; set; } = new HashSet<PurchaseOrder>();
        [InverseProperty("CreatedUser")]
        public virtual ICollection<PurchaseRequest> CreatedPurchaseRequests { get; set; } = new HashSet<PurchaseRequest>();
        [InverseProperty("ModifiedUser")]
        public virtual ICollection<PurchaseRequest> ModifiedPurchaseRequests { get; set; } = new HashSet<PurchaseRequest>();

    }
}
