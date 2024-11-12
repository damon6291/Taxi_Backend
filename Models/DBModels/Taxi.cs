using Taxi_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Taxi_Backend.Models.DBModels;

namespace Taxi_Backend.Models.DBModels
{
    public class Taxi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaxiId { get; set; }
        public long DriverId { get; set; }
        public EnumTaxiColor Color { get; set; }
        public EnumTaxiMake Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public EnumTaxiSize Size { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public virtual AppUser? Driver { get; set; }

    }
}