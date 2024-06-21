using WMS_backend.Models.Auth;
using WMS_backend.Models.DBModels;

namespace WMS_backend.Mapper
{
    public static class UserMapper
    {
        public static UserDTO UserToDTO(User user)
        {
            return new UserDTO()
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsArchived = user.IsArchived,
                Phone = user.Phone,
                CreatedDateTime = user.CreatedDateTime,
                LastLoginDateTime = user.LastLoginDateTime,
                ModifiedDateTime = user.ModifiedDateTime,
                ModifiedUser = user.ModifiedUser == null ? null : UserToDTO(user.ModifiedUser),
            };
        }

        public static User DTOToUser(UserDTO dto)
        {
            return new User()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
            };
        }
    }
}
