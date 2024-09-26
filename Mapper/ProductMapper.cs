using WMS_backend.Models.DBModels;
using WMS_backend.Models.Enums;
using WMS_backend.Models.Permission;
using WMS_backend.Models.Product;

namespace WMS_backend.Mapper
{
    public class ProductMapper
    {
        public static ProductDTO ProductToDTO(Product data)
        {
            return new ProductDTO()
            {
                ProductId = data.ProductId,
                Name = data.Name,
                Description = data.Description,
                IsArchived = data.IsArchived,
                SupplierId = data.SupplierId,
            };
        }

        public static Product DTOToProduct(ProductDTO dto)
        {
            return new Product()
            {
                ProductId = dto.ProductId,
                Name = dto.Name,
                Description = dto.Description,
                IsArchived = dto.IsArchived,
                SupplierId = dto.SupplierId,
            };
        }

        public static ProductVariantDTO ProductVariantToDTO(ProductVariant data)
        {
            return new ProductVariantDTO()
            {
                ProductVariantId = data.ProductVariantId,
                SKU = data.SKU,
                Barcode = data.Barcode,
                Barcode1 = data.Barcode1,
                Barcode2 = data.Barcode2,
                Barcode3 = data.Barcode3,
                Width = data.Width,
                Length = data.Length,
                Height = data.Height,
                Weight = data.Weight,
                PurchasePrice = data.PurchasePrice,
                RetailPrice = data.RetailPrice,
                TaxRate = data.TaxRate,
                IsArchived = data.IsArchived
            };
        }

        public static ProductVariant DTOToProductVariant(ProductVariantDTO dto)
        {
            return new ProductVariant()
            {
                ProductVariantId = dto.ProductVariantId,
                SKU = dto.SKU,
                Barcode = dto.Barcode,
                Barcode1 = dto.Barcode1,
                Barcode2 = dto.Barcode2,
                Barcode3 = dto.Barcode3,
                Width = dto.Width,
                Length = dto.Length,
                Height = dto.Height,
                Weight = dto.Weight,
                PurchasePrice = dto.PurchasePrice,
                RetailPrice = dto.RetailPrice,
                TaxRate = dto.TaxRate,
                IsArchived = dto.IsArchived
            };
        }
    }
}
