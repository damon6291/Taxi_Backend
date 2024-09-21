using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class ProductHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductHistoryId { get; set; }
        public long UserId { get; set; }
        [MaxLength(2000)]
        public string Message { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public virtual AppUser User { get; set; }
        
    }
}
