using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class Client : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClientId { get; set; }
        public string Name { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        [MaxLength(2000)]
        public string? Note { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
