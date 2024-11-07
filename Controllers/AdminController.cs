using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taxi_Backend.Managers;
using Taxi_Backend.Models;
using Taxi_Backend.Services;
using Taxi_Backend.Data;
using Taxi_Backend.Mapper;
using Taxi_Backend.Models.DBModels;
using Microsoft.AspNetCore.Identity;

namespace Taxi_Backend.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AuthManager authManager;
        private readonly TaxiDBContext context;

        public AdminController(AuthManager authManager, TaxiDBContext context)
        {
            this.authManager = authManager;
            this.context = context;
        }



    }
}
