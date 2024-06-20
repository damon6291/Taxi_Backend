using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class PurchaseRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PurchaseRequestId { get; set; }
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
        [MaxLength(2000)]
        public string MessageToTeam { get; set; } = string.Empty;
        public bool IsArchived { get; set; } = false;
        public EnumPORequestStatus Staus { get; set; } = EnumPORequestStatus.Draft;
        [MaxLength(2000)]
        public string? MessageFromTeam { get; set; }

        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
    }
}
