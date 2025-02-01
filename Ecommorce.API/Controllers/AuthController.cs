using Azure.Core;
using Ecommorce.Application.IRepository;
using Ecommorce.Infrastructure.Services;
using Ecommorce.Model;
using Ecommorce.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly AuthService _authService;
        private static readonly Dictionary<string, string> _refreshToken;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        private readonly IUserRepository _repository;
        public AuthController(AuthService authService, ApplicationDbContext context,IUserRepository userRepository,IConfiguration configuration) 
        {
            _authService=authService;
            _context=context;
            _repository=userRepository;
            _configuration = configuration;
        }
        

        [HttpPost("Login")]
        public async Task<ActionResult<IEnumerable<User>>> Login([FromBody] AddUserModel model)
        {
            var users = await _context.Users.
              Include(users => users.UserRoles)
                  .ThenInclude(ur => ur.RoleUserName)
               .FirstOrDefaultAsync(u => u.Email == model.Email);


            if (users == null) return null;
       

            var claiems = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };



            foreach (var userRole in users.UserRoles)
            {
                claiems.Add(new Claim(ClaimTypes.Role, userRole.RoleUserName.Name));
            }



            var accessToken = _authService.BuildToken(claiems);
            var refreshToken = _authService.GenretRefreshToken();

            //_refreshToken[refreshToken]=model.Email;

            //_refreshToken[refreshToken] ="";

            return Ok(new {  accessToken, refreshToken });

        }
        [HttpPost("Refresh")]

        public IActionResult Refresh([FromBody] RefreshRequst request)
        {
           
            if (!_refreshToken.ContainsKey(request.RefreshToken))
                return Unauthorized("Invalide Refresh Token");
            var userName=_refreshToken[request.RefreshToken];
           //var user= _repository.GetUserByEmailAsync(userName);

      

            var claiems = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Email, request.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };

            var newaccessToken = _authService.BuildToken(claiems);
            var newRefreshToken = _authService.GenretRefreshToken();


            _refreshToken.Remove( request.RefreshToken);
            _refreshToken[newRefreshToken] = userName;

            return Ok(new { newaccessToken, newRefreshToken });

        }
    }

    public class RefreshRequst
    {
        public string RefreshToken { get; set; }
        public string Email { get; set; }
        
    }
}
