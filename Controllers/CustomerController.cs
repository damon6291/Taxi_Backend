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
    [Route("api/customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerManager _customerManager;
        private readonly AuthManager _authManager;

        public CustomerController(CustomerManager customerManager, AuthManager authManager)
        {
            _customerManager = customerManager;
            _authManager = authManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDTO customerDto)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var customer = CustomerMapper.DTOToCustomer(customerDto);
            var (success, response) = await _customerManager.CreateCustomer(customer);

            if (!success)
                return Ok(ret.Fail(response.ToString()));

    var customerResponseDto = CustomerMapper.CustomerToDTO((Customer)response);
    ret.Success(customerResponseDto);
            return Ok(ret);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] CustomerDTO customerDto)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            customerDto.CustomerId = id;
            var customer = CustomerMapper.DTOToCustomer(customerDto);
            var (success, response) = await _customerManager.UpdateCustomer(customer);

            if (!success)
                return Ok(ret.Fail(response.ToString()));

    var customerResponseDto = CustomerMapper.CustomerToDTO((Customer)response);
    ret.Success(customerResponseDto);
            return Ok(ret);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var (success, response) = await _customerManager.DeleteCustomer(id);
            if (!success)
                return Ok(ret.Fail(response.ToString()));

    var customerResponseDto = CustomerMapper.CustomerToDTO((Customer)response);
    ret.Success(customerResponseDto);
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var ret = new ReturnModel();
            var user = await _authManager.GetLoggedInUser();
            if (user == null) return Ok(ret.Logout());

            var (success, response) = await _customerManager.GetCustomerById(id);
            if (!success)
                return Ok(ret.Fail(response.ToString()));

    var customerResponseDto = CustomerMapper.CustomerToDTO((Customer)response);
    ret.Success(customerResponseDto);
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
            var filters = new List<Filter> { new Filter(new List<string> { "phonenumber" }, Op.Contains, q) };
            page.Filters = filters;

            var (count, customers) = await _customerManager.GetCustomers(page);
              var dtos = customers.Select(CustomerMapper.CustomerToDTO).ToList();
            ret.Success(new { count, customers = dtos });
            return Ok(ret);
        }

        [HttpPost("queue")]
    public async Task<IActionResult> CreateQueue([FromBody] CustomerQueueDTO queueDto)
    {
        var ret = new ReturnModel();
        var user = await _authManager.GetLoggedInUser();
        if (user == null) return Ok(ret.Logout());

        var queue = CustomerQueueMapper.DTOToCustomerQueue(queueDto);
        queue.CompanyId = user.CompanyId;
        
        var (success, response) = await _customerManager.CreateCustomerQueue(queue);
        if (!success)
            return Ok(ret.Fail(response.ToString()));

    var queueResponseDto = CustomerQueueMapper.CustomerQueueToDTO((CustomerQueue)response);
    ret.Success(queueResponseDto);
        return Ok(ret);
    }

    [HttpPut("queue/{id}")]
    public async Task<IActionResult> UpdateQueue(long id, [FromBody] CustomerQueueDTO queueDto)
    {
        var ret = new ReturnModel();
        var user = await _authManager.GetLoggedInUser();
        if (user == null) return Ok(ret.Logout());

        var queue = CustomerQueueMapper.DTOToCustomerQueue(queueDto);
        queue.CustomerQueueId = id;
        queue.CompanyId = user.CompanyId;

        var (success, response) = await _customerManager.UpdateCustomerQueue(queue);
        if (!success)
            return Ok(ret.Fail(response.ToString()));

var queueResponseDto = CustomerQueueMapper.CustomerQueueToDTO((CustomerQueue)response);
    ret.Success(queueResponseDto);
        return Ok(ret);
    }

    [HttpDelete("queue/{id}")]
    public async Task<IActionResult> DeleteQueue(long id)
    {
        var ret = new ReturnModel();
        var user = await _authManager.GetLoggedInUser();
        if (user == null) return Ok(ret.Logout());

        var (success, response) = await _customerManager.DeleteCustomerQueue(id);
        if (!success)
            return Ok(ret.Fail(response.ToString()));

var queueResponseDto = CustomerQueueMapper.CustomerQueueToDTO((CustomerQueue)response);
    ret.Success(queueResponseDto);
        return Ok(ret);
    }

    [HttpGet("queue/{id}")]
    public async Task<IActionResult> GetQueue(long id)
    {
        var ret = new ReturnModel();
        var user = await _authManager.GetLoggedInUser();
        if (user == null) return Ok(ret.Logout());

        var (success, response) = await _customerManager.GetCustomerQueueById(id);
        if (!success)
            return Ok(ret.Fail(response.ToString()));

var queueResponseDto = CustomerQueueMapper.CustomerQueueToDTO((CustomerQueue)response);
    ret.Success(queueResponseDto);
        return Ok(ret);
    }

    [HttpGet("queue/customer/{customerId}")]
    public async Task<IActionResult> GetCustomerQueue(long customerId)
    {
        var ret = new ReturnModel();
        var user = await _authManager.GetLoggedInUser();
        if (user == null) return Ok(ret.Logout());

        var customerQueue = await _customerManager.GetCustomerQueueByCustomerId(customerId);
        if (customerQueue == null)
            return Ok(ret.Fail("Customer queue not found"));

var queueResponseDto = CustomerQueueMapper.CustomerQueueToDTO(customerQueue);
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
        var (count, queues) = await _customerManager.GetCustomerQueues(page, user.CompanyId);
        var dtos = queues.Select(CustomerQueueMapper.CustomerQueueToDTO).ToList();
            ret.Success(new { count, queues = dtos });

        return Ok(ret);
    }

    // Add this method to the existing CustomerController class
[HttpPost("request")]
public async Task<IActionResult> CreateRequest([FromBody] CustomerRequestDTO request)
{
    var ret = new ReturnModel();
    var user = await _authManager.GetLoggedInUser();
    if (user == null) return Ok(ret.Logout());

    // Set company ID from authenticated user
    request.CompanyId = user.CompanyId;
    var (success, response) = await _customerManager.CreateCustomerRequest(request);
    if (!success)
        return Ok(ret.Fail(response.ToString()));

var queueResponseDto = CustomerQueueMapper.CustomerQueueToDTO((CustomerQueue)response);
    ret.Success(queueResponseDto);
    return Ok(ret);
}
    }
}