using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class UserPermission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserPermissionId { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyPermissionId { get; set; }
        public bool IsCrud { get; set; } = false;
        public virtual User User { get; set; }
        public virtual CompanyPermission CompanyPermission { get; set; }
    }
}
