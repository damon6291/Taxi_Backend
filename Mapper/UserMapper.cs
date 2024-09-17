using WMS_backend.Models.DBModels;
using WMS_backend.Models.User;

namespace WMS_backend.Mapper
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
                IsAdmin = user.CompanyId == null,
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


        public static NotificationDTO NotificationToDTO(Notification db)
        {
            return new NotificationDTO()
            {
                NotificationId= db.NotificationId,
                NotificationType=db.NotificationType.ToString(),
                Name=db.Name,
                Description=db.Description,
                CreatedDateTime = db.CreatedDateTime,
            };
        }

    }
}
