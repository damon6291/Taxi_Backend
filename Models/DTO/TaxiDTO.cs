using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Models.DTO
{
    public class TaxiDTO
    {
        public long TaxiId { get; set; }
        public long DriverId { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public EnumTaxiColor EnumColor { get; set; }
        public EnumTaxiSize EnumSize { get; set; }
        public EnumTaxiMake EnumMake { get; set; }
        public string Size { get; set; }
        public string Make { get; set; }
        // Add other properties as needed
    }
}