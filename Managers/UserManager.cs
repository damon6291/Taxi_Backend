using WMS_backend.Data;
using WMS_backend.Mapper;
using WMS_backend.Models;
using WMS_backend.Models.DBModels;
using WMS_backend.Services;

namespace WMS_backend.Managers
{
    public class UserManager
    {
        private readonly WMSDbContext context;
        private readonly AuthManager authManager;

        public UserManager(WMSDbContext context, AuthManager authManager)
        {
            this.context = context;
            this.authManager = authManager;
        }


        public async Task<(bool, object)> GetMe(Guid userId)
        {
            try
            {
                var user = await authManager.GetUser(userId);
                if (user == null) return (false, "User does not exist");

                var userDTO = UserMapper.UserToDTO(user);

                return (true, userDTO);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, object)> GetNotification(Guid userId)
        {
            try
            {
                var user = await authManager.GetUser(userId);
                if (user == null) return (false, "User does not exist");

                var notifications = context.Notification.Where(x => x.UserId == userId && !x.IsArchived).Select(x => UserMapper.NotificationToDTO(x)).ToList();

                return (true, notifications);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(int, List<User>)> GetUsers(Page page)
        {
            try
            {
                var activeUsers = context.User.Where(x => !x.IsArchived);
                return await page.Get(activeUsers);
            }
            catch (Exception ex)
            {
                return (0, new List<User>());
            }
        }

    }
}
