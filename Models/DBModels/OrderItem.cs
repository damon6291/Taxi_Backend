using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductVariantId { get; set; }
        public int Count { get; set; }
        public int AmountPerItem { get; set; }

        public virtual Order Order { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
