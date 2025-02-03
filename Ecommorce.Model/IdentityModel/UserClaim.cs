using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.IdentityModel
{
    public class UserClaim : IdentityUserClaim<string>
    {
        public UserClaim(int id ,string userId, string claimType,string claimValue) {

            this.Id = id;
            this.UserId = userId;
            this.ClaimType = claimType;
            this.ClaimValue = claimValue;

        }

        public UserClaim() { }

    }
}
