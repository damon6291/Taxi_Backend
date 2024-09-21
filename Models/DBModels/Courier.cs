using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Courier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CourierId { get; set; }
        public string Name { get; set; }


        public virtual ICollection<ShippingOption> ShippingOptions { get; set; } = new HashSet<ShippingOption>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
