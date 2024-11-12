using Microsoft.AspNetCore.Identity;

namespace Taxi_Backend.Models.DBModels
{
    public class AppRole : IdentityRole<long>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
