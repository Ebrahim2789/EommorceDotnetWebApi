using Microsoft.AspNetCore.Identity;

namespace Ecommorce.Model.IdentityModel
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; }
    }


}



