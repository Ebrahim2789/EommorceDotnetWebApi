using Microsoft.AspNetCore.Identity;

namespace Ecommorce.Model.IdentityModel
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }


}



