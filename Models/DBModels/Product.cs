using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Product : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string? Barcode1 { get; set; }
        public string? Barcode2 { get; set; }
        public string? Barcode3 { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public float PurchasePrice { get; set; }
        public float RetailPrice { get; set; }
        public float TaxRate { get; set; }
        public bool IsArchived { get; set; } = false;
        public long? SupplierId { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; } = new HashSet<Inventory>();
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new HashSet<PurchaseOrderItem>();
    }
}
