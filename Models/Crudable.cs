using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.DBModels;

namespace WMS_backend.Models
{
    public class Crudable
    {
        public long CreatedUserId { get; set; }
        public long ModifiedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDateTime { get; set; } = DateTime.UtcNow;

        public virtual AppUser CreatedUser { get; set; }
        public virtual AppUser ModifiedUser { get; set; }
    }
}
