
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

        IProductOptionRepository ProductOption {get;}
        IProductOptionValueRepository ProductOptionValue {get;}
        IProductAttributeRepository ProductAttribute {get;}
        IProductBrandRepository ProductBrand {get;}



        IProductAttributeValueRepository ProductAttributeValue {get;}
        IProductPublishRepository ProductPublish {get;}
        IProductMediaRepository ProductMedia {get;}
        IProductCategoryRepository ProductCategory {get;}

        void Save();

    }
}
