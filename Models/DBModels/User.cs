using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public bool IsArchived { get; set; } = false;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Phone { get; set; }

        public DateTime? LastLoginDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDateTime { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public Guid CompanyId { get; set; }
        [ForeignKey("ModifiedUserId")]
        public virtual User ModifiedUser { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<TeamUser> TeamUsers { get; set; } = new HashSet<TeamUser>();
        public virtual ICollection<UserPermission> UserPermissions { get; set; } = new HashSet<UserPermission>();
        public virtual ICollection<UserPreference> UserPreferences { get; set; } = new HashSet<UserPreference>();
        public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new HashSet<PurchaseOrder>();
        public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = new HashSet<PurchaseRequest>();

    }
}
