using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class OrderHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderHistoryId { get; set; }
        public Guid OrderId { get; set; }
        public long UserId { get; set; }
        public long Message { get; set; }

        public virtual Order Order { get; set; }
        public virtual AppUser User { get; set; }
    }
}
