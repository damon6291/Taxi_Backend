using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TeamId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsArchived { get; set; } = false;


        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }


        public virtual ICollection<TeamUser> TeamUsers { get; set; } = new HashSet<TeamUser>();
        public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = new HashSet<PurchaseRequest>();
    }
}
