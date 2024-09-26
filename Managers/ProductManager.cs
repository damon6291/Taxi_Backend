using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WMS_backend.Data;
using WMS_backend.Mapper;
using WMS_backend.Models;
using WMS_backend.Models.DBModels;
using WMS_backend.Models.Permission;
using WMS_backend.Models.Product;

namespace WMS_backend.Managers
{
    public class ProductManager
    {
        private readonly WMSDbContext context;

        public ProductManager(WMSDbContext context)
        {
            this.context = context;
        }

        public async Task<Product?> GetProduct(Guid productId, long companyId)
        {
            var product = await context.Product.Include(x => x.ProductVariants).Where(x => x.ProductId == productId && x.CompanyId == companyId).FirstOrDefaultAsync();
            return product;
        }

        public async Task<(int, List<Product?>)> GetProducts(Page page)
        {
            try
            {
                var activeProducts = context.Product.Include(x => x.ProductVariants).Where(x => !x.IsArchived);
                return await page.Get(activeProducts);
            }
            catch (Exception ex)
            {
                return (0, new List<Product?>());
            }
        }

        public async Task<(bool, object)> UpsertProduct(Guid productId, ProductDTO dto)
        {
            List<ProductVariant> productVariants = new();
            var product = ProductMapper.DTOToProduct(dto);
            await context.BulkMergeAsync(new List<Product> { product });

            foreach (var variant in dto.ProductVariants)
            {
                var temp = ProductMapper.DTOToProductVariant(variant);
                temp.ProductId = product.ProductId;
                productVariants.Add(temp);
            }
            try
            {
                await context.BulkMergeAsync(productVariants);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
            return (true, string.Empty);
        }

        public async Task<(bool, object)> DeleteProduct(Guid productId)
        {
            try
            {
                await context.Product.Where(x => x.ProductId == productId).DeleteFromQueryAsync();
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
            return (true, string.Empty);
        }
    }
}
