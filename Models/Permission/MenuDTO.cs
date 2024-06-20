namespace WMS_backend.Models.Permission
{
    public class MenuDTO
    {
        public string Name { get; set; }
        public string URL { get; set; } = string.Empty;
        public List<MenuDTO> Children { get; set; } = new List<MenuDTO>();
    }
}
