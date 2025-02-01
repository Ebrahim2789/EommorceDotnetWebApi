using Ecommorce.Model.UserModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ecommorce.Infrastructure.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        public AuthService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string BuildToken(IEnumerable<Claim> claiems)
        {

            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var credential = new SigningCredentials(

                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                claims: claiems,
                issuer: _config["Jwt:Issuer"],

                audience: _config["Jwt:Audience"],

                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:ExpiryMinutes"])),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        public string GenretRefreshToken()
        {
            var randomByte = new Byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomByte);
            return Convert.ToBase64String(randomByte);
        }



    }
}
