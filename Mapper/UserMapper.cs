using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;

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
                ModifiedUser = user.ModifiedUser == null ? null : UserToDTO(user.ModifiedUser),
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
