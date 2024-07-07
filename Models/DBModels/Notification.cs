using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid NotificationId { get; set; }
        public EnumNotificationType NotificationType { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsArchived { get; set; } = false;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
