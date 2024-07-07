using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS_backend.Managers;
using WMS_backend.Models;
using WMS_backend.Services;

namespace WMS_backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager userManager;
        public UserController(IUserService userService, UserManager userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            var ret = new ReturnModel();
            var userId = userService.GetUserId();
            if (userId == null) return Ok(ret.Logout());

            var (res, msg) = await userManager.GetMe((Guid)userId);

            if (!res) return Ok(ret.Fail(msg.ToString()));

            ret.Success(msg);

            return Ok(ret);
        }

        [HttpGet("notification")]
        public async Task<IActionResult> GetNotification()
        {
            var ret = new ReturnModel();
            var userId = userService.GetUserId();
            if (userId == null) return Ok(ret.Logout());

            var (res, msg) = await userManager.GetNotification((Guid)userId);

            if (!res) return Ok(ret.Fail(msg.ToString()));

            ret.Success(msg);

            return Ok(ret);
        }
    }
}
