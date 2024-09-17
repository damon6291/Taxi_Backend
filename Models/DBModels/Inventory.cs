using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Inventory : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InventoryId { get; set; }
        public Guid ProductId { get; set; }
        public Guid RackId { get; set; }
        public int XSlot { get; set; }
        public int YSlot { get; set; }
        public int Quantity { get; set; }
        public string LotNumber { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }
        public virtual Rack Rack { get; set; }
    }
}
