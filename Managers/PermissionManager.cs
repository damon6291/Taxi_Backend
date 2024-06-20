using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.ComponentModel.DataAnnotations;
using WMS_backend.Data;
using WMS_backend.Models.Permission;
using WMS_backend.Services;

namespace WMS_backend.Managers
{
    public class PermissionManager
    {
        private readonly WMSDbContext context;
        private readonly AuthManager authManager;

        public PermissionManager(WMSDbContext context,  AuthManager authManager)
        {
            this.context = context;
            this.authManager = authManager;
        }
        public async Task<(bool, object)> GetMenu(Guid userId)
        {
            var user = await authManager.GetUser(userId);
            if (user == null) return (false, "User does not exist");

            var userPermission = await context.UserPermission.Where(x => x.UserId == userId).Select(x => x.CompanyPermission.PermissionType).ToListAsync();

            var menu = userPermission.GroupBy(x => x.GetAttributeOfType<DisplayAttribute>().GroupName)
                .Select(x => new MenuDTO() { Name = x.Key ?? "", Children = x.Select(x => new MenuDTO() { Name = x.ToString(), URL = x.GetAttributeOfType<DisplayAttribute>().Description ?? "" }).ToList() })
                .ToList();

            menu.Insert(0, new MenuDTO() { Name = "Dashboard", URL = "/dashboard/root" });
            menu.FirstOrDefault(x => x.Name == "Setting")?.Children.Insert(0, new MenuDTO() { Name = "Preference", URL = "/dashboard/setting/preference" });

            return (true, menu);
        }

        public async Task<(bool, object)> GetPermission(Guid userId)
        {
            var user = await authManager.GetUser(userId);
            if (user == null) return (false, "User does not exist");

            var userPermission = await context.UserPermission.Where(x => x.UserId == userId).Select(x => new UserPermissionDTO { Name = x.CompanyPermission.PermissionType.ToString(), IsCrud = x.IsCrud }).ToListAsync();

            return (true, userPermission);
        }

        public async Task<(bool, object)> GetCompanyPermission(Guid userId)
        {
            var user = await authManager.GetUser(userId);
            if (user == null) return (false, "User does not exist");

            var companyPermissions = await context.CompanyPermission.Where(x => x.CompanyId == user.CompanyId).ToListAsync();

            return (true, companyPermissions);
        }


    }
}
