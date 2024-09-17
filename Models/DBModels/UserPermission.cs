using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class UserPermission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserPermissionId { get; set; }
        public long UserId { get; set; }
        public EnumPermissionType PermissionType { get; set; }
        public bool IsCrud { get; set; } = false;
        public virtual AppUser User { get; set; }
    }
}
