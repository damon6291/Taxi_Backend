using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS_backend.Managers;
using WMS_backend.Models;
using WMS_backend.Models.Enums;
using WMS_backend.Models.Permission;
using WMS_backend.Services;

namespace WMS_backend.Controllers
{
    [Route("api/permission")]
    [ApiController]
    [Authorize]
    public class PermissionController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly PermissionManager permissionManager;
        private readonly AuthManager authManager;

        public PermissionController(IUserService userService, AuthManager authManager, PermissionManager permissionManager)
        {
            this.userService = userService;
            this.permissionManager = permissionManager;
            this.authManager = authManager;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserPermission()
        {
            var ret = new ReturnModel();
            var user = await userService.GetUser();
            if (user == null) return Ok(ret.Logout());

            var (res, obj) = await permissionManager.GetUserPermission(user.Id);

            if (!res) return Ok(ret.Fail(obj.ToString()));

            return Ok(ret.Success(obj));
        }


        [HttpGet("company")]
        public async Task<IActionResult> GetCompanyPermission()
        {
            var ret = new ReturnModel();
            var user = await userService.GetUser();
            if (user == null) return Ok(ret.Logout());
            var permissionError = await authManager.CheckPermission(user.Id, new EnumPermissionType[] { EnumPermissionType.ManageTeam, EnumPermissionType.ManageCompany }, false);
            if (permissionError != null) return Ok(ret.Fail(permissionError));

            var (res, obj) = await permissionManager.GetCompanyPermission(user.Id);

            if (!res) return Ok(ret.Fail(obj.ToString()));

            return Ok(ret.Success(obj));
        }

        [HttpPut("upsert/{updateUserId}")]
        public async Task<IActionResult> UpsertUserPermission(long updateUserId, List<UserPermissionDTO> permissions)
        {
            var ret = new ReturnModel();
            var user = await userService.GetUser();
            if (user == null) return Ok(ret.Logout());
            var permissionError = await authManager.CheckPermission(user.Id, new EnumPermissionType[] { EnumPermissionType.ManageTeam, EnumPermissionType.ManageCompany }, false);
            if (permissionError != null) return Ok(ret.Fail(permissionError));

            var (res, obj) = await permissionManager.UpsertUserPermission(updateUserId, permissions);

            if (!res) return Ok(ret.Fail(obj.ToString()));

            return Ok(ret.Success(obj));
        }

        [HttpDelete("{userPermissionId}")]
        public async Task<IActionResult> DeleteUserPermission(Guid userPermissionId)
        {
            var ret = new ReturnModel();
            var user = await userService.GetUser();
            if (user == null) return Ok(ret.Logout());
            var permissionError = await authManager.CheckPermission(user.Id, new EnumPermissionType[] { EnumPermissionType.ManageTeam, EnumPermissionType.ManageCompany }, false);
            if (permissionError != null) return Ok(ret.Fail(permissionError));

            var (res, obj) = await permissionManager.DeleteUserPermission(userPermissionId);

            if (!res) return Ok(ret.Fail(obj.ToString()));

            return Ok(ret.Success(obj));
        }
        
    }
}
