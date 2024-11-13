using Microsoft.EntityFrameworkCore;
using Taxi_Backend.Data;
using Taxi_Backend.Mapper;
using Taxi_Backend.Models;
using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Services;

namespace Taxi_Backend.Managers
{
    public class UserManager
    {
        private readonly TaxiDBContext context;
        private readonly AuthManager authManager;

        public UserManager(TaxiDBContext context, AuthManager authManager)
        {
            this.context = context;
            this.authManager = authManager;
        }

        public async Task<(bool, object)> GetUserById(long userId)
        {
            try
            {
                var user = await context.Users.Include(x => x.UserRoles).Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (user == null) return (false, "User does not exist");

                return (true, user);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(int, List<AppUser>)> GetUsers(Page page)
        {
            try
            {
                var activeUsers = context.Users.Include(x => x.UserRoles).Where(x => !x.IsArchived);
                return await page.Get(activeUsers);
            }
            catch (Exception ex)
            {
                return (0, new List<AppUser>());
            }
        }

    }
}
