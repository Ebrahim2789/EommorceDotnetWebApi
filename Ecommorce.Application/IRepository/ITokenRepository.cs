using Ecommorce.Application.Repository;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.UserModel;

namespace Ecommorce.Infrastructure.Repositories
{
    public interface ITokenRepository : IGenericRepository<RefreshToken>
    {
    }
}