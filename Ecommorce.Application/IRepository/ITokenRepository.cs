using Ecommorce.Application.Repository;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.UserModel;

namespace Ecommorce.Infrastructure.Repositories
{
    public interface ITokenRepository : IGenericRepository<RefreshToken>
    {
        Task SaveRefreshToken(string username, string token);
        Task<bool> RevokeRefreshToken(string refreshToken);
        Task <string>RetrieveUsernameByRefreshToken(string refreshToken);
    }
}