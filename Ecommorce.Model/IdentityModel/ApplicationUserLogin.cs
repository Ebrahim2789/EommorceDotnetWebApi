using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.IdentityModel
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        [Required] 
        public virtual ApplicationUser User { get; set; }
    }

}



