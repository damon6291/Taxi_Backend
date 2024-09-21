using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class PurchaseOrder : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PurchaseOrderId { get; set; }
        public string PurchaseOrderNumber { get; set; } = string.Empty;
        public EnumPOStatus POStatus { get; set; } = EnumPOStatus.Draft;
        public long LocationId { get; set; }
        public long SupplierId { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string? ShippingCarrier { get; set; }
        public string? TrackingNumber { get; set; }
        [MaxLength(2000)]
        public string? Note { get; set; }

        public int UnitOrders { get; set; }
        public float Subtotal { get; set; }
        public float Tax { get; set; }
        public float Shipping { get; set; }
        public float Total { get; set; }
        public bool IsArchived { get; set; } = false;
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Location Location { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new HashSet<PurchaseOrderItem>();
        public virtual ICollection<PurchaseOrderHistory> PurchaseOrderHistories { get; set; } = new HashSet<PurchaseOrderHistory>();

    }
}
