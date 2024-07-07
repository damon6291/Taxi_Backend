using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;
using WMS_backend.Managers;
using WMS_backend.Models;
using WMS_backend.Models.Auth;
using WMS_backend.Models.Enums;
using WMS_backend.Models.User;
using WMS_backend.Services;

namespace WMS_backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AuthManager authManager;
        public AuthController(IUserService userService, AuthManager authManager)
        {
            this.userService = userService;
            this.authManager = authManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO req)
        {
            var ret = new ReturnModel();
            var (res, msg) = await authManager.Login(req);

            if (!res) return Ok(ret.Fail());

            ret.Success(new { token = msg });

            return Ok(ret);
        }

        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> Register(UserDTO req)
        {
            var ret = new ReturnModel();
            var userId = userService.GetUserId();
            if (userId == null) return Ok(ret.Logout());
            var permissionError = await authManager.CheckPermission((Guid)userId, new EnumPermissionType[] { EnumPermissionType.ManageTeam, EnumPermissionType.ManageCompany }, true);
            if (permissionError != null) return Ok(ret.Fail(permissionError));

            var (res, msg) = await authManager.Register((Guid)userId, req);

            if (!res) return Ok(ret.Fail(msg));

            ret.Success();

            return Ok(ret);
        }

        [HttpPost("refresh")]
        [Authorize]
        public async Task<IActionResult> Refresh()
        {
            var ret = new ReturnModel();
            var userId = userService.GetUserId();
            if (userId == null) return Ok(ret.Logout());

            var (res, msg) = await authManager.Refresh((Guid)userId);

            if (!res) return Ok(ret.Fail(msg));

            ret.Success(new {token = msg});

            return Ok(ret);
        }

        [HttpPost("password/reset")]
        [Authorize]
        public async Task<IActionResult> ResetPassword(PasswordDTO dto)
        {
            var ret = new ReturnModel();
            var userId = userService.GetUserId();
            if (userId == null) return Ok(ret.Logout());

            var (res, msg) = await authManager.ResetPassword((Guid)userId, dto.Password);

            if (!res) return Ok(ret.Fail(msg));

            ret.Success();

            return Ok(ret);
        }

        [HttpPost("password/forgot")]
        public async Task<IActionResult> ForgotPassword(EmailDTO dto)
        {
            var ret = new ReturnModel();
            var (res, msg) = await authManager.ForgotPassword(dto.Email);

            if (!res) return Ok(ret.Fail(msg));

            ret.Success();

            return Ok(ret);
        }
    }
}
