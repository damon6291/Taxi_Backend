using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Taxi_Backend.Managers;
using Taxi_Backend.Mapper;
using Taxi_Backend.Models;
using Taxi_Backend.Models.DTO;
using Taxi_Backend.Services;

namespace Taxi_Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AuthManager authManager;
        private readonly UserManager userManager;
        public UserController(AuthManager authManager, UserManager userManager)
        {
            this.authManager = authManager;
            this.userManager = userManager;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            var ret = new ReturnModel();
            var user = await authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var (res, msg) = await userManager.GetUserById(user.Id);

            if (!res) return Ok(ret.Fail(msg.ToString()));

            ret.Success(msg);

            return Ok(ret);
        }


        [HttpGet("list")]
        public async Task<IActionResult> GetUsersList([Required] int pageNumber, [Required] int pageSize, string orderColumn = "", bool isAscending = true, string userName = "")
        {
            var ret = new ReturnModel();
            var user = await authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            Page page = new Page(pageNumber, pageSize, orderColumn, isAscending);
            List<Filter> filters = new List<Filter> { new Filter("Name", Op.Contains, userName) };
            page.Filters = filters;
            var (count, res) = await userManager.GetUsers(page);
            List<UserDTO> dtos = new();
            foreach (var ruser in res)
            {
                dtos.Add(UserMapper.UserToDTO(ruser));
            }
            ret.Success(new { count, users = dtos });
            return Ok(ret);
        }
    }
}
