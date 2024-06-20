using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS_backend.Managers;
using WMS_backend.Models;
using WMS_backend.Models.Enums;
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

        [HttpGet]
        public async Task<IActionResult> GetPermission()
        {
            var ret = new ReturnModel();
            var userId = userService.GetUserId();
            if (userId == null) return Ok(ret.Logout());

            var (res, obj) = await permissionManager.GetPermission((Guid)userId);

            if (!res) return Ok(ret.Fail(obj.ToString()));

            return Ok(ret.Success(obj));
        }


        [HttpGet("company")]
        public async Task<IActionResult> GetCompanyPermission()
        {
            var ret = new ReturnModel();
            var userId = userService.GetUserId();
            if (userId == null) return Ok(ret.Logout());
            var permissionError = await authManager.CheckPermission((Guid)userId, new EnumPermissionType[] { EnumPermissionType.ManageTeam, EnumPermissionType.ManageCompany }, false);
            if (permissionError != null) return Ok(ret.Fail(permissionError));

            var (res, obj) = await permissionManager.GetCompanyPermission((Guid)userId);

            if (!res) return Ok(ret.Fail(obj.ToString()));

            return Ok(ret.Success(obj));
        }

        [HttpGet("menu")]
        public async Task<IActionResult> GetMenu()
        {
            var ret = new ReturnModel();
            var userId = userService.GetUserId();
            if (userId == null) return Ok(ret.Logout());

            var (res, obj) = await permissionManager.GetMenu((Guid)userId);

            if (!res) return Ok(ret.Fail(obj.ToString()));

            return Ok(ret.Success(obj));
        }
    }
}
