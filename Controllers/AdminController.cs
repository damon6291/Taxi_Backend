using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS_backend.Managers;
using WMS_backend.Models;
using WMS_backend.Services;
using WMS_backend.Data;
using WMS_backend.Mapper;
using WMS_backend.Models.DBModels;
using Microsoft.AspNetCore.Identity;
using WMS_backend.Models.User;

namespace WMS_backend.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AuthManager authManager;
        private readonly WMSDbContext context;

        public AdminController(IUserService userService, AuthManager authManager, WMSDbContext context)
        {
            this.userService = userService;
            this.authManager = authManager;
            this.context = context;
        }

        [HttpPost("password")]
        public IActionResult Password(string password)
        {
            var ret = new ReturnModel();
            userService.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            ret.Success(new { passwordHash, passwordSalt });

            return Ok(ret);
        }

        [HttpPost("user")]
        public async Task<IActionResult> User(UserDTO dto, string companyId)
        {
            var ret = new ReturnModel();

            var newUser = UserMapper.DTOToUser(dto);
            newUser.CompanyId = new Guid(companyId);
            userService.CreatePasswordHash("password", out var passwordHash, out var passwordSalt);
            newUser.PasswordSalt = passwordSalt;
            newUser.PasswordHash = passwordHash;
            context.Add(newUser);
            await context.SaveChangesAsync();

            ret.Success(newUser);

            return Ok(ret);
        }
    }
}
