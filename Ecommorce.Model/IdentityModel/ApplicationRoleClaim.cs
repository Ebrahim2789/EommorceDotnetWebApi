using Ecommorce.Model.IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace Ecommorce.Model.IdentityModel
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual  ApplicationRole Role { get; set; }
    }


}

