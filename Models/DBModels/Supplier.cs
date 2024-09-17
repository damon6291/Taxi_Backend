using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Supplier : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool IsArchived { get; set; } = false;
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new HashSet<PurchaseOrder>();
    }
}
