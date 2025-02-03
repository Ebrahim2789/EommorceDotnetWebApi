using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.IdentityModel
{
    public class RoleIdentity: IdentityRole
    {
      
        public RoleIdentity() { }
        public string Role {  get; set; }
        public RoleIdentity(string roleName)
        {
            Role = roleName;
        }

    }
}
