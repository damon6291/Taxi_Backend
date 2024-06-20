using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class TeamUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TeamUserId { get; set; }
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
        public virtual User User { get; set; }
        public virtual Team Team { get; set; }

    }
}
