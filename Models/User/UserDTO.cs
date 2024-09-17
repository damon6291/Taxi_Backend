namespace WMS_backend.Models.User
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public bool IsArchived { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => FirstName + " " + LastName;
        public string? PhoneNumber { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public UserDTO? ModifiedUser { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
