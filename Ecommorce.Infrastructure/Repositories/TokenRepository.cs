using Ecommorce.Application.IRepository;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Model;
using Ecommorce.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Infrastructure.Repositories
{
    public class TokenRepository : GenericRepository<RefreshToken>, ITokenRepository
    {

        public TokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<string> RetrieveUsernameByRefreshToken(string refreshToken)
        {
            var tokenRecord = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.ExpiryDate > DateTime.UtcNow);
            // Return the username if the token is found and valid, otherwise null.
            return tokenRecord?.Username;
        }

        public async Task<bool> RevokeRefreshToken(string refreshToken)
        {
            // Asynchronously find the refresh token in the database.
            var tokenRecord = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken);
            // If the token is found, remove it from the DbSet.
            if (tokenRecord != null)
            {
                _context.RefreshTokens.Remove(tokenRecord);
                // Save changes to the database asynchronously to reflect the token removal.

                return true;  // Return true to indicate successful revocation.
            }
            // Return false if no matching token was found, indicating no revocation was performed.
            return false;
        }

        public async Task SaveRefreshToken(string username, string token)
        {
            var refreshToken = new RefreshToken
            {
                Username = username,  // Set the username associated with the token.
                Token = token,  // Set the token value.
                ExpiryDate = DateTime.UtcNow.AddDays(7)  // Set the expiration date to 7 days from the current UTC date/time.
            };
            // Add the new refresh token to the corresponding DbSet in the database context.
            _context.RefreshTokens.Add(refreshToken);
            // Asynchronously save changes to the database, which includes inserting the new refresh token.
            await _context.SaveChangesAsync();
        }
    }
}
