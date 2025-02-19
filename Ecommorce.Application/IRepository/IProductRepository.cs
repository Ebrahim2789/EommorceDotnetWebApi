using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommorce.Application.Repository;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.RequestFeatures;

namespace Ecommorce.Application.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        //Task<IEnumerable<Product>> GetGridAsync(int id, ProductParameters productParameters);
        Task<PagedList<Product>> GetProductsAsync(int id, ProductParameters productParameters, bool trackChanges);
        Task<PagedList<Product>> FilterProductsAsync(int id, FiltersParameters filtersParameters, bool trackChanges);
    }

    public interface IProductOptionRepository : IGenericRepository<ProductOption>
    {
    }
    public interface IProductOptionValueRepository : IGenericRepository<ProductOptionValue>
    {
    }
    public interface IProductOptionDataRepository : IGenericRepository<ProductOptionData>
    {
    }
    public interface IProductAttributeRepository : IGenericRepository<ProductAttribute>
    {
    }
    public interface IProductAttributeValueRepository : IGenericRepository<ProductAttributeValue>
    {
    }

    public interface IProductAttributeDataRepository : IGenericRepository<ProductAttributeData>
    {
    }
    public interface IPublishRepository : IGenericRepository<Publisher>
    {
    }
    public interface IProductMediaRepository : IGenericRepository<ProductMedia>
    {
    }

    public interface IMediaRepository : IGenericRepository<Media>
    {
    }
    public interface IProductBrandRepository : IGenericRepository<ProductBrand>
    {
    }
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
    }

    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}




