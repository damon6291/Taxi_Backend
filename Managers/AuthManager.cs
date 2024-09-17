using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WMS_backend.Data;
using WMS_backend.Mapper;
using WMS_backend.Models.Auth;
using WMS_backend.Models.DBModels;
using WMS_backend.Models.Enums;
using WMS_backend.Models.Permission;
using WMS_backend.Models.User;
using WMS_backend.Services;

namespace WMS_backend.Managers
{
    public class AuthManager
    {
        private readonly WMSDbContext context;
        private readonly IUserService userService;
        private readonly IEmailService emailService;

        public AuthManager(WMSDbContext context, IUserService userService, IEmailService emailService)
        {
            this.context = context;
            this.userService = userService;
            this.emailService = emailService;
        }

        public async Task<AppUser?> GetUser(long userId)
        {
            var ret = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            return ret;
        }

        public async Task<AppUser?> GetActiveUserByEmail(string email)
        {
            var ret = await context.Users.FirstOrDefaultAsync(x => x.Email == email && !x.IsArchived);
            return ret;
        }

        public async Task<string?> CheckPermission(long userId, EnumPermissionType[] permissions, bool isCrud)
        {
            string? ret = null;
            var permissionList = permissions.Select(x => new { PermissionType = x }).ToList();
            var havePermission = await context.UserPermission.Where(x => x.UserId == userId && isCrud ? x.IsCrud : true).WhereBulkContains(permissionList, x => x.PermissionType).CountAsync();
            if (havePermission > 0) return ret;
            ret = ("User does not have permission");
            return ret;
        }

    }
}
