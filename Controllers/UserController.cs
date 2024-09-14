using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WMS_backend.Managers;
using WMS_backend.Mapper;
using WMS_backend.Models;
using WMS_backend.Models.User;
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

        [HttpGet("list")]
        public async Task<IActionResult> GetUsersList([Required] int pageNumber, [Required] int pageSize, string orderColumn = "", bool isAscending = true, string userName = "")
        {
            var ret = new ReturnModel();
            var userId = userService.GetUserId();
            if (userId == null) return Ok(ret.Logout());

            Page page = new Page(pageNumber, pageSize, orderColumn, isAscending);
            List<Filter> filters = new List<Filter> { new Filter("Name", Op.Contains, userName)};
            page.Filters = filters;
            var (count, res) = await userManager.GetUsers(page);
            List<UserDTO> dtos = new();
            foreach (var user in res)
            {
                dtos.Add(UserMapper.UserToDTO(user));
            }
            ret.Success(new { count, users = dtos });
            return Ok(ret);
        }
    }
}
