using Azure.Core;
using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;
using Ecommorce.Infrastructure.Services;
using Ecommorce.Model;
using Ecommorce.Model.DTO;
using Ecommorce.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using NuGet.Protocol.Core.Types;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        private readonly IConfiguration _configuration;
        private readonly TokenStorage _tokenStorage;
        private readonly IRepositoryManager _repository;
        public AuthController(AuthService authService, IRepositoryManager repositoryManager, IConfiguration configuration, TokenStorage tokenStorage)
        {
            _authService = authService;
            _tokenStorage = tokenStorage;

            _repository = repositoryManager;
            _configuration = configuration;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<IEnumerable<User>>> Login([FromBody] LoginDTO model)
        {
            var users = await _repository.User.FindByCondition(users => users.Email == model.Email).Include(users => users.UserRoles)
                  .ThenInclude(ur => ur.RoleName)
               .FirstOrDefaultAsync(u => u.Email == model.Email);


            if (users == null) return null;


            var claiems = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.PreferredUsername, model.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };


            foreach (var userRole in users.UserRoles)
            {
                claiems.Add(new Claim(ClaimTypes.Role, userRole.RoleName.Name));
            }

            var accessToken = _authService.BuildToken(claiems);
            var refreshToken = _authService.GenretRefreshToken();
            _tokenStorage.SetAccessToken(accessToken);
            _tokenStorage.SetRefreshToken(refreshToken);

            await _repository.Token.SaveRefreshToken(model.UserName, refreshToken);

            return Ok(new { accessToken, refreshToken });

        }
        [HttpPost("Refresh")]

        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            var result = _repository.Token.RetrieveUsernameByRefreshToken(request.RefreshToken);

            //if (!_refreshToken.ContainsKey(request.RefreshToken))
            //    return Unauthorized("Invalide Refresh Token");


            var userName = result.Result;
            if (userName == null) return Unauthorized("Invalide Refresh Token");


            var users = await _repository.User.FindByCondition(users => users.UserName == userName).Include(users => users.UserRoles)
                 .ThenInclude(ur => ur.RoleName)
              .FirstOrDefaultAsync(u => u.UserName == userName);


            var claiems = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.PreferredUsername, userName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };
            foreach (var userRole in users.UserRoles)
            {
                claiems.Add(new Claim(ClaimTypes.Role, userRole.RoleName.Name));
            }

            var newaccessToken = _authService.BuildToken(claiems);
            var newRefreshToken = _authService.GenretRefreshToken();


            await _repository.Token.RevokeRefreshToken(request.RefreshToken);

            await _repository.Token.SaveRefreshToken(userName, newRefreshToken);

            _tokenStorage.SetRefreshToken(newRefreshToken);

            //"refreshToken": "nyMdapAFCL+yJRCT1h4QAWeSjNlLf6pTCrVlFQUrpkQ="

            return Ok(new { newaccessToken, newRefreshToken });

        }
    }






}
