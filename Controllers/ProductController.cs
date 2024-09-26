using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WMS_backend.Managers;
using WMS_backend.Mapper;
using WMS_backend.Models;
using WMS_backend.Models.Product;
using WMS_backend.Models.User;
using WMS_backend.Services;

namespace WMS_backend.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager userManager;
        private readonly ProductManager productManager;

        public ProductController(IUserService userService, UserManager userManager, ProductManager productManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.productManager = productManager;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var ret = new ReturnModel();
            var user = await userService.GetUser();
            if (user == null) return Ok(ret.Logout());

            var product = await productManager.GetProduct(productId, user.CompanyId.Value);

            if (product == null) return Ok(ret.Fail());

            ret.Success(product);

            return Ok(ret);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetProductList([Required] int pageNumber, [Required] int pageSize, string orderColumn = "", bool isAscending = true, string productName = "")
        {
            var ret = new ReturnModel();
            var user = await userService.GetUser();
            if (user == null) return Ok(ret.Logout());

            Page page = new Page(pageNumber, pageSize, orderColumn, isAscending);
            List<Filter> filters = new List<Filter> { new Filter("Name", Op.Contains, productName), new Filter("CompanyId", Op.Equals, user.CompanyId) };
            page.Filters = filters;
            var (count, res) = await productManager.GetProducts(page);
            List<ProductDTO> dtos = new();
            foreach (var item in res)
            {
                dtos.Add(ProductMapper.ProductToDTO(item));
            }
            ret.Success(new { count, products = dtos });
            return Ok(ret);
        }

    }
}
