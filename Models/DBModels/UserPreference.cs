using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class UserPreference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserPreferenceId { get; set; }
        public long UserId { get; set; }
        public EnumUserPreferenceType PreferenceType { get; set; }
        public string Value { get; set; } = string.Empty;
        public virtual AppUser User { get; set; }
    }
}
