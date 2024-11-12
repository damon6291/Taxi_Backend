using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi_Backend.Data;
using Taxi_Backend.Managers;
using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;
using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TaxiDBContext ctx;
        private readonly CustomerManager customerManager;
        private readonly DriverManager driverManager;

        public TestController(
            TaxiDBContext ctx,
            CustomerManager customerManager,
            DriverManager driverManager)
        {
            this.ctx = ctx;
            this.customerManager = customerManager;
            this.driverManager = driverManager;
        }

        [HttpPost("create-test-queues")]
        public async Task<IActionResult> CreateTestQueues()
        {
            try
            {

                // Remove all existing customer queues, driver queues, and trips
                ctx.CustomerQueue.RemoveRange(ctx.CustomerQueue);
                ctx.DriverQueue.RemoveRange(ctx.DriverQueue);
                ctx.Trip.RemoveRange(ctx.Trip);
                await ctx.SaveChangesAsync();

                // Get all active customers
                var customers = await ctx.Customer
                    .ToListAsync();

                // Get all active drivers
                var drivers = await ctx.Users
                    .Include(x => x.UserRoles)
                    .Where(d => !d.IsArchived && d.UserRoles.Any(x => x.RoleId == (long)EnumUserRole.DRIVER))
                    .ToListAsync();

                var companies = drivers.Select(x => x.CompanyId).Distinct().ToList();

                var results = new
                {
                    CustomerRequests = new List<object>(),
                    DriverQueues = new List<object>()
                };
                Random random = new Random();

                // Create customer requests
                foreach (var customer in customers)
                {
                    long randomCompany = companies[random.Next(companies.Count)];
                    var request = new CustomerRequestDTO
                    {
                        CustomerId = customer.CustomerId,
                        CompanyId = randomCompany,
                        PickupAddress = "123 Test St",
                        DropoffAddress = "456 Test Ave",
                        CalledTaxiSize = EnumTaxiSize.SMALL,
                        Notes = "Test request"
                    };

                    var (success, response) = await customerManager.CreateCustomerRequest(request);
                    results.CustomerRequests.Add(new { CustomerId = customer.CustomerId, Success = success, Response = response });
                }

                // Create driver queues
                foreach (var driver in drivers)
                {
                    var driverQueue = new DriverQueue
                    {
                        DriverId = driver.Id,
                        CompanyId = driver.CompanyId,
                        Latitude = 40.7128, // Example coordinates (New York)
                        Longitude = -74.0060,
                        QueueStatus = EnumQueueStatus.WAITING
                    };

                    var (success, response) = await driverManager.CreateDriverQueue(driverQueue);
                    results.DriverQueues.Add(new { DriverId = driver.Id, Success = success, Response = response });
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}