using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class TeamUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TeamUserId { get; set; }
        public long UserId { get; set; }
        public Guid TeamId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Team Team { get; set; }

    }
}
