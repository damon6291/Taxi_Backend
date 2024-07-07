using WMS_backend.Models.Enums;

namespace WMS_backend.Models.User
{
    public class NotificationDTO
    {
        public Guid NotificationId { get; set; }
        public string NotificationType { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    }
}
