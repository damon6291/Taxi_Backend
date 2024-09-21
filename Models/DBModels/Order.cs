using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class Order : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }
        public long CompanyId { get; set; }
        public long? PlatformId { get; set; }
        public long? CourierId { get; set; }
        public long? ShippingOptionId { get; set; }
        public long? ClientId { get; set; }
        public EnumOrderStatus OrderStatus { get; set; } = EnumOrderStatus.Draft;

        public string OrderNumber { get; set; }
        public string ExpectedDate { get; set; }
        [MaxLength(2000)]
        public string Note { get; set; }
        public string TrackingNumber { get; set; }

        public virtual Company Company { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual Courier Courier { get; set; }
        public virtual ShippingOption ShippingOption { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new HashSet<OrderHistory>();
    }
}
