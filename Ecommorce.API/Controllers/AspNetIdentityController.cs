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
        private readonly UserManager<UsersIdentity> _userManager;
        private readonly RoleManager<RoleIdentity> _roleManager;
        public AspNetIdentityController(UserManager<UsersIdentity> userManager, RoleManager<RoleIdentity> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        [HttpGet("check-role")]
        public async Task<IActionResult> CheckUserRole()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized("User not found ");
            bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            return Ok(isAdmin ? "User is an Admin" : "User is not an Admin");
        }

        [HttpGet("create-role")]
        public async Task<IActionResult> CreateUserRole()
        {

            string roleName = "Admin";
            string userEmail = "admin@example.com";
            string userPassword = "Admin@123";

            if (!await _roleManager.RoleExistsAsync(roleName))
            {

                await _roleManager.CreateAsync(new RoleIdentity(roleName));
            }
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                user = new UsersIdentity
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
