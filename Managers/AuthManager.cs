using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Taxi_Backend.Data;
using Taxi_Backend.Mapper;
using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Services;

namespace Taxi_Backend.Managers
{
    public class AuthManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> userManager;

        public AuthManager(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task<AppUser?> GetLoggedInUser()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                var temp = await userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                return temp;
            }
            return null;
        }


    }
}
