using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Rack : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RackId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int XSlotMax { get; set; } = 1;
        public int YSlotMax { get; set; } = 1;
        public bool IsArchived { get; set; } = false;

        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; } = new HashSet<Inventory>();
    }
}
