using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Platform
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PlatformId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PlatformCourier> PlatformCouriers { get; set; } = new HashSet<PlatformCourier>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
