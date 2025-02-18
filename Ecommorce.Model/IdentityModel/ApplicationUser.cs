using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.IdentityModel
{
    public class ApplicationUser : IdentityUser
    {
        public virtual  ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual  ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual  ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual  ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
