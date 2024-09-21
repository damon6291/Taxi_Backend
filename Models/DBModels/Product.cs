using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Product : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string? Description { get; set; }
        public bool IsArchived { get; set; } = false;
        public long? SupplierId { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new HashSet<ProductVariant>();
        public virtual ICollection<ProductHistory> ProductHistories { get; set; } = new HashSet<ProductHistory>();
    }
}
