using WMS_backend.Models.Auth;
using WMS_backend.Models.DBModels;
using WMS_backend.Models.Enums;
using WMS_backend.Models.Permission;

namespace WMS_backend.Mapper
{
    public class PermissionMapper
    {
        public static UserPermissionDTO PermissionToDTO(UserPermission data)
        {
            return new UserPermissionDTO()
            {
                UserPermissionId = data.UserPermissionId,
                Name = data.PermissionType.ToString(),
                IsCrud = data.IsCrud,
            };
        }

        public static UserPermission DTOToPermission(UserPermissionDTO dto)
        {
            Enum.TryParse(dto.Name, out EnumPermissionType type);
            return new UserPermission()
            {
                UserPermissionId= dto.UserPermissionId,
                PermissionType = type,
                IsCrud = dto.IsCrud,
            };
        }
    }
}
