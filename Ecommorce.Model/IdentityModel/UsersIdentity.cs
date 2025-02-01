using Microsoft.AspNetCore.Identity;

namespace Ecommorce.Model.IdentityModel
{
    public class UsersIdentity:IdentityUser
    {
        public string FullName { get; set; }
    }
}
