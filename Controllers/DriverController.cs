using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Taxi_Backend.Managers;
using Taxi_Backend.Mapper;
using Taxi_Backend.Models;
using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;

namespace Taxi_Backend.Controllers
{
    [Route("api/driver")]
    [ApiController]
    [Authorize]
    public class DriverController : ControllerBase
    {
        private readonly DriverManager _driverManager;
        private readonly AuthManager _authManager;

        public DriverController(DriverManager driverManager, AuthManager authManager)
        {
            _driverManager = driverManager;
            _authManager = authManager;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UserDTO driverDto)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            driverDto.Id = id;
            var driver = UserMapper.DTOToUser(driverDto);
            var (success, response) = await _driverManager.UpdateDriver(driver);

            if (!success)
                return Ok(ret.Fail(response.ToString()));

    var driverResponseDto = UserMapper.UserToDTO((AppUser)response);
    ret.Success(driverResponseDto);
            return Ok(ret);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var (success, response) = await _driverManager.DeleteDriver(id);
            if (!success)
                return Ok(ret.Fail(response.ToString()));

    var driverResponseDto = UserMapper.UserToDTO((AppUser)response);
    ret.Success(driverResponseDto);
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var (success, response) = await _driverManager.GetDriverById(id);
            if (!success)
                return Ok(ret.Fail(response.ToString()));

          var driverResponseDto = UserMapper.UserToDTO((AppUser)response);
    ret.Success(driverResponseDto);
            return Ok(ret);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList(
            [Required] int pageNumber,
            [Required] int pageSize,
            string orderColumn = "",
            bool isAscending = true,
            string q = "")
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var page = new Page(pageNumber, pageSize, orderColumn, isAscending);
            var filters = new List<Filter> { new Filter(new List<string> { "name", "drivernumber" }, Op.Contains, q) };
            page.Filters = filters;

            var (count, drivers) = await _driverManager.GetDrivers(page, user.CompanyId);
            var dtos = drivers.Select(UserMapper.UserToDTO).ToList();
            ret.Success(new { count, drivers = dtos });
            return Ok(ret);
        }

        [HttpPost("queue")]
        public async Task<IActionResult> CreateQueue([FromBody] DriverQueueDTO queueDto)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var queue = DriverQueueMapper.DTOToDriverQueue(queueDto);
            queue.CompanyId = user.CompanyId;

            var (success, response) = await _driverManager.CreateDriverQueue(queue);
            if (!success)
                return Ok(ret.Fail(response.ToString()));

       var queueResponseDto = DriverQueueMapper.DriverQueueToDTO((DriverQueue)response);
    ret.Success(queueResponseDto);
            return Ok(ret);
        }

        [HttpPut("queue/{id}")]
        public async Task<IActionResult> UpdateQueue(long id, [FromBody] DriverQueueDTO queueDto)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var queue = DriverQueueMapper.DTOToDriverQueue(queueDto);
            queue.DriverQueueId = id;
            queue.CompanyId = user.CompanyId;

            var (success, response) = await _driverManager.UpdateDriverQueue(queue);
            if (!success)
                return Ok(ret.Fail(response.ToString()));

                var queueResponseDto = DriverQueueMapper.DriverQueueToDTO((DriverQueue)response);
    ret.Success(queueResponseDto);
            return Ok(ret);
        }

        [HttpDelete("queue/{id}")]
        public async Task<IActionResult> DeleteQueue(long id)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var (success, response) = await _driverManager.DeleteDriverQueue(id);
            if (!success)
                return Ok(ret.Fail(response.ToString()));

                var queueResponseDto = DriverQueueMapper.DriverQueueToDTO((DriverQueue)response);
    ret.Success(queueResponseDto);
            return Ok(ret);
        }

        [HttpGet("queue/{id}")]
        public async Task<IActionResult> GetQueue(long id)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var (success, response) = await _driverManager.GetDriverQueueById(id);
            if (!success)
                return Ok(ret.Fail(response.ToString()));

             var queueResponseDto = DriverQueueMapper.DriverQueueToDTO((DriverQueue)response);
    ret.Success(queueResponseDto);
            return Ok(ret);
        }

        [HttpGet("queues")]
        public async Task<IActionResult> GetQueues(
            [Required] int pageNumber,
            [Required] int pageSize,
            string orderColumn = "",
            bool isAscending = true)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var page = new Page(pageNumber, pageSize, orderColumn, isAscending);
            var (count, queues) = await _driverManager.GetDriverQueues(page, user.CompanyId);

             var queueDtos = queues.Select(DriverQueueMapper.DriverQueueToDTO).ToList();
    ret.Success(new { count, queues = queueDtos });
            return Ok(ret);
        }

        // Replace existing GetDriverQueue method with this updated version
        [HttpGet("queue/driver/{driverId}")]
        public async Task<IActionResult> GetDriverQueue(long driverId)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var driverQueue = await _driverManager.GetDriverQueueByDriverId(driverId);
            if (driverQueue == null)
                return Ok(ret.Fail("Driver queue not found"));

       var queueResponseDto = DriverQueueMapper.DriverQueueToDTO(driverQueue);
    ret.Success(queueResponseDto);
            return Ok(ret);
        }
    }
}