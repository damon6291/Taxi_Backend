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



    }
}
