
using Ecommorce.Application.IRepository;
using Ecommorce.Infrastructure.Repositories;

namespace Ecommorce.Application.Repository
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        ITokenRepository Token { get; }

        IOrderRepository Order {get;}

        ICarRepository Car {get;}

        IDriverRepository Driver {get;}

    }
}
