using System.ComponentModel.DataAnnotations;
using WMS_backend.Models.DBModels;

namespace WMS_backend.Models.Product
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsArchived { get; set; } = false;
        public long? SupplierId { get; set; }
        public long CompanyId { get; set; }

        public List<ProductVariantDTO> ProductVariants { get; set; } = new();
    }

}
