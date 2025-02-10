using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommorce.Application.Repository;
using Ecommorce.Model.ProductModels;

namespace Ecommorce.Application.IRepository
{
    public interface IProductRepository :IGenericRepository<Product>
    {
    }

    //ProductOption ProductOptionValue ProductAttribute ProductAttributeValue
    //ProductPublish ProductMedia ProductBrand ProductCategory


    public interface IProductOptionRepository : IGenericRepository<ProductOption>
    {
    }
    public interface IProductOptionValueRepository : IGenericRepository<ProductOptionValue>
    {
    }
    public interface IProductAttributeRepository : IGenericRepository<ProductAttribute>
    {
    }
    public interface IProductAttributeValueRepository : IGenericRepository<ProductAttributeValue>
    {
    }
    public interface IProductPublishRepository : IGenericRepository<ProductPublish>
    {
    }
    public interface IProductMediaRepository : IGenericRepository<ProductMedia>
    {
    }
    public interface IProductBrandRepository : IGenericRepository<ProductBrand>
    {
    }
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
    }
}
