using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class TeamLocation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TeamLocationId { get; set; }
        public Guid TeamId { get; set; }
        public Guid LocationId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Location Location { get; set; }
    }
}
