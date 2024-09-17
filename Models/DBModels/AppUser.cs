﻿using Microsoft.AspNetCore.Identity;
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
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDateTime { get; set; } = DateTime.UtcNow;
        public long? ModifiedUserId { get; set; }
        public long? CompanyId { get; set; }
        [ForeignKey("ModifiedUserId")]
        public virtual AppUser? ModifiedUser { get; set; }
        public virtual Company? Company { get; set; }

        public virtual ICollection<TeamUser> TeamUsers { get; set; } = new HashSet<TeamUser>();
        public virtual ICollection<UserPermission> UserPermissions { get; set; } = new HashSet<UserPermission>();
        public virtual ICollection<UserPreference> UserPreferences { get; set; } = new HashSet<UserPreference>();
        public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new HashSet<PurchaseOrder>();
        public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = new HashSet<PurchaseRequest>();

    }
}