using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class PermissionType
    {
        public EnumPermissionType PermissionTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
