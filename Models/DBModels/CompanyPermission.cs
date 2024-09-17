using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class CompanyPermission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyPermissionId { get; set; }
        public long CompanyId { get; set; }
        public EnumPermissionType PermissionType { get; set; }
        public virtual Company Company { get; set; }
    }
}
