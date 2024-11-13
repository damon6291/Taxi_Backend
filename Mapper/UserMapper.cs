using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;
using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Mapper
{
    public static class UserMapper
    {
        public static UserDTO UserToDTO(AppUser user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsArchived = user.IsArchived,
                PhoneNumber = user.PhoneNumber,
                CreatedDateTime = user.CreatedDateTime,
                LastLoginDateTime = user.LastLoginDateTime,
                ModifiedDateTime = user.ModifiedDateTime,
                ModifiedUserName = user.ModifiedUser?.Name ?? "",
                UserRole = string.Join(',', user.UserRoles.Select(x => ((EnumUserRole)x.RoleId).ToString()).ToList()),
                DriverNumber = user.DriverNumber ?? "",
                Taxis = user.Taxis.Select(TaxiMapper.TaxiToDTO).ToList()

            };
        }

        public static AppUser DTOToUser(UserDTO dto)
        {
            return new AppUser()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
            };
        }

    }
}
