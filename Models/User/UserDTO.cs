namespace WMS_backend.Models.User
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public bool IsArchived { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Phone { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public UserDTO? ModifiedUser { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
