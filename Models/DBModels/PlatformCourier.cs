using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class PlatformCourier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PlatformCourierId { get; set; }
        public long PlatformId { get; set; }
        public long CourierId { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual Courier Courier { get; set; }
    }
}
