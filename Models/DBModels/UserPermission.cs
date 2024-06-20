using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class UserPermission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserPermissionId { get; set; }
        public Guid UserId { get; set; }
        public EnumPermissionType PermissionType { get; set; }
        public bool IsCrud { get; set; } = false;
        public virtual User User { get; set; }
    }
}
