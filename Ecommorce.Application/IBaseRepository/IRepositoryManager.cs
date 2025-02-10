
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

        IProductOptionRepository productOptionRepository {get;}
        IProductOptionValueRepository productOptionValueRepository {get;}
        IProductAttributeRepository productAttributeRepository {get;}
        IProductBrandRepository productBrandRepository {get;}

        IProductAttributeValueRepository productAttributeValueRepository {get;}
        IProductPublishRepository productPublishRepository {get;}
        IProductMediaRepository productMediaRepository {get;}
        IProductCategoryRepository productCategoryRepository {get;}

    }
}
