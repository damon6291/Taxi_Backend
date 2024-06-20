using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class UserPreference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserPreferenceId { get; set; }
        public Guid UserId { get; set; }
        public EnumUserPreferenceType PreferenceType { get; set; }
        public string Value { get; set; } = string.Empty;
        public virtual User User { get; set; }
    }
}
