using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class PurchaseRequest : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PurchaseRequestId { get; set; }
        [MaxLength(2000)]
        public string MessageToTeam { get; set; } = string.Empty;
        public bool IsArchived { get; set; } = false;
        public EnumPORequestStatus Staus { get; set; } = EnumPORequestStatus.Draft;
        [MaxLength(2000)]
        public string? MessageFromTeam { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
