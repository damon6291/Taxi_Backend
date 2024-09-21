using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class ShippingOption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ShippingOptionId { get; set; }
        public long CourierId { get; set; }
        public string Name { get; set; }

        public virtual Courier Courier { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
