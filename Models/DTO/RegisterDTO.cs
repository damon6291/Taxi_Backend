using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Models.DTO
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CompanyId { get; set; }
        public EnumUserRole Role { get; set; }
    }
}
