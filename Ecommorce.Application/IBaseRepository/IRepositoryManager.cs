
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
        IProductOptionDataRepository ProductOptionData {get;}
        IProductAttributeRepository ProductAttribute {get;}
        IProductBrandRepository ProductBrand {get;}


        IProductAttributeDataRepository ProductAttributeData {get;}
        IProductAttributeValueRepository ProductAttributeValue {get;}
        IPublishRepository Publish {get; }
        IProductMediaRepository ProductMedia {get;}
        IMediaRepository Media { get; }
        IProductCategoryRepository ProductCategory {get;}
        ICategoryRepository Category { get; }
        void Save();

    }
}
