using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InventoryId { get; set; }
        public Guid ProductId { get; set; }
        public Guid RackId { get; set; }
        public int XSlot { get; set; }
        public int YSlot { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Rack Rack { get; set; }
    }
}
