using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace WMS_backend.Models.DBModels
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsArchived { get; set; } = false;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public virtual ICollection<Team> Teams { get; set; } = new HashSet<Team>();
        public virtual ICollection<Location> Locations { get; set; } = new HashSet<Location>();
        public virtual ICollection<CompanyPermission> CompanyPermissions { get; set; } = new HashSet<CompanyPermission>();
        public virtual ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
    }
}
