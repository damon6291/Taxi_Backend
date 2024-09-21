using System.ComponentModel.DataAnnotations.Schema;
using WMS_backend.Models.Enums;

namespace WMS_backend.Models.DBModels
{
    public class CompanyCourier : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyCourierId { get; set; }
        public long CompanyId { get; set; }
        public string Key { get; set; }
        public virtual Company Company { get; set; }
    }
}
