namespace WMS_backend.Models.Permission
{
    public class UserPermissionDTO
    {
        public Guid UserPermissionId { get; set; }
        public string Name { get; set; }
        public bool IsCrud { get; set; }
    }
}
