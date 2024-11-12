namespace Taxi_Backend.Models.DTO
{
    public class CompanyDTO
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Contact { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        // Add other properties as needed
    }
} 