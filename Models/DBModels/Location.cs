using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LocationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public EnumLocationType LocationType { get; set; }
        public bool IsArchived { get; set; } = false;
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new HashSet<PurchaseOrder>();
        public virtual ICollection<Rack> Racks { get; set; } = new HashSet<Rack>();
        public virtual ICollection<Tote> Totes { get; set; } = new HashSet<Tote>();

    }
}
