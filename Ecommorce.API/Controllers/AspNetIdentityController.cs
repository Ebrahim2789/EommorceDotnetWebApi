using Ecommorce.Model.IdentityModel;
using Ecommorce.Model.UserModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Ecommorce.API.Controllers
{
    public class AspNetIdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AspNetIdentityController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        [HttpPost("check-role")]
        public async Task<IActionResult> CheckUserRole([FromBody] ApplicationUser user)
        {

            if (user == null) return null;

         
            var users = await _userManager.FindByEmailAsync(user.Email);

            if (users == null) return Unauthorized("User not found ");
            bool isAdmin = await _userManager.IsInRoleAsync(users, "Admin");
            return Ok(isAdmin ? "User is an Admin" : "User is not an Admin");
        }

        [HttpGet("create-role")]
        public async Task<IActionResult> CreateUserRole()
        {

            string roleName = "Admin";
            string userEmail = "admin2@example.com";
            string userPassword = "Admin@123";

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
               var role = new ApplicationRole
               {
                   
                   Name=roleName,
                
                };

                

                await _roleManager.CreateAsync(role);
            }
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = userEmail,
                    Email = userEmail
                };

                await _userManager.CreateAsync(user);
                
                await _userManager.AddToRoleAsync(user, roleName);
                
            }

            return Ok(user);
        }

    }
}
