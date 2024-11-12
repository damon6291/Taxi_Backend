using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

using Taxi_Backend.Managers;

using Taxi_Backend.Mapper;

using Taxi_Backend.Models;

using Taxi_Backend.Models.DTO;

using Taxi_Backend.Models.DBModels;



namespace Taxi_Backend.Controllers

{

    [Route("api/company")]

    [ApiController]

    [Authorize]

    public class CompanyController : ControllerBase

    {

        private readonly CompanyManager _companyManager;

        private readonly AuthManager _authManager;



        public CompanyController(CompanyManager companyManager, AuthManager authManager)

        {

            _companyManager = companyManager;

            _authManager = authManager;

        }



        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CompanyDTO companyDto)

        {

            var ret = new ReturnModel();

            var user = await _authManager.GetLoggedInUser();

            if (user == null) return Ok(ret.Logout());



            var company = CompanyMapper.DTOToCompany(companyDto);

            var (success, response) = await _companyManager.CreateCompany(company);



            if (!success)

                return Ok(ret.Fail(response.ToString()));



            ret.Success(CompanyMapper.CompanyToDTO((Company)response));

            return Ok(ret);

        }



        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, [FromBody] CompanyDTO companyDto)

        {

            var ret = new ReturnModel();

            var user = await _authManager.GetLoggedInUser();

            if (user == null) return Ok(ret.Logout());



            var company = CompanyMapper.DTOToCompany(companyDto);

            company.CompanyId = id;



            var (success, response) = await _companyManager.UpdateCompany(company);

            if (!success)

                return Ok(ret.Fail(response.ToString()));



            ret.Success(CompanyMapper.CompanyToDTO((Company)response));

            return Ok(ret);

        }



        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(long id)

        {

            var ret = new ReturnModel();

            var user = await _authManager.GetLoggedInUser();

            if (user == null) return Ok(ret.Logout());



            var (success, response) = await _companyManager.DeleteCompany(id);

            if (!success)

                return Ok(ret.Fail(response.ToString()));



            ret.Success(response);

            return Ok(ret);

        }



        [HttpGet("{id}")]

        public async Task<IActionResult> Get(long id)

        {

            var ret = new ReturnModel();

            var user = await _authManager.GetLoggedInUser();

            if (user == null) return Ok(ret.Logout());



            var (success, response) = await _companyManager.GetCompanyById(id);

            if (!success)

                return Ok(ret.Fail(response.ToString()));



            ret.Success(CompanyMapper.CompanyToDTO((Company)response));

            return Ok(ret);

        }



        [HttpGet("list")]

        public async Task<IActionResult> GetList(

            [Required] int pageNumber,

            [Required] int pageSize,

            string orderColumn = "",

            bool isAscending = true,

            string name = "")

        {

            var ret = new ReturnModel();

            var user = await _authManager.GetLoggedInUser();

            if (user == null) return Ok(ret.Logout());



            var page = new Page(pageNumber, pageSize, orderColumn, isAscending);

            var filters = new List<Filter> { new Filter("Name", Op.Contains, name) };

            page.Filters = filters;



            var (count, companies) = await _companyManager.GetCompanies(page);

            var companyDtos = companies.Select(CompanyMapper.CompanyToDTO).ToList();



            ret.Success(new { count, companies = companyDtos });

            return Ok(ret);

        }

    }

} 
