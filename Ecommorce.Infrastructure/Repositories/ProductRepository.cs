
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;
using Ecommorce.Infrastructure.Extension;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Model;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ecommorce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {


        }


        // public async Task<IEnumerable<Product>> GetGridIncluding(Expression<Func<Product, bool>> pradicte=null, params Expression<Func<Product, bool>>[] includes )
        // {
        //     return await GetGridIncluding(includes);
        // }


        // public async Task<(IEnumerable<Product> Data, int TotalCount)> GetGridIncluding(RequestParameters requestParameters, Expression<Func<Product, bool>> predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, params Expression<Func<Product, bool>>[] includes )
        // {
        //     return await GetGridAsync(requestParameters, orderBy: q => q.OrderBy(p => p.Name));
        // }

        public async Task<PagedList<Product>> GetProductsAsync(int id, ProductParameters productParameters, bool trackChanges)
        {

            var products = await GetGridAsync(productParameters, orderBy: q => q.OrderBy(p => p.Name));

            //  _context.Entry(products).Reference(p=>p.categories).Load();
            // var products = await FindByConditions(e => e.Id == id)
            // .OrderBy(e => e.Name).Skip((productParameters.PageNumber - 1) * productParameters.PageSize).Take(productParameters.PageSize).ToListAsync();

            return PagedList<Product>.ToPagedList(products.Data, productParameters.PageNumber, productParameters.PageSize);
        }
        public async Task<PagedList<Product>> FilterProductsAsync(int id, FiltersParameters filtersParameters, bool trackChanges)
        {

            // var products = await GetGridAsync(filtersParameters, orderBy: q => q.OrderBy(p => p.Name));

            // var product2= await GetAllAsync();


            var products1 = await FindByConditions(e => e.Id >=1 )
             .FilterProducts(filtersParameters.OrderMinimumQuantity, filtersParameters.OrderMaximumQuantity)
              .Search(filtersParameters.SearchTerm)
              .Sort(filtersParameters.OrderBy)
            //   .OrderBy(e => e.Name)
              .ToListAsync();





            return PagedList<Product>.ToPagedList(products1, filtersParameters.PageNumber, filtersParameters.PageSize);
        }

    }


    public class ProductOptionRepository : GenericRepository<ProductOption>, IProductOptionRepository
    {
        public ProductOptionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductOptionValueRepository : GenericRepository<ProductOptionValue>, IProductOptionValueRepository
    {
        public ProductOptionValueRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public class ProductOptionDataRepository : GenericRepository<ProductOptionData>, IProductOptionDataRepository
    {
        public ProductOptionDataRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductAttributeRepository : GenericRepository<ProductAttribute>, IProductAttributeRepository
    {
        public ProductAttributeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductAttributeValueRepository : GenericRepository<ProductAttributeValue>, IProductAttributeValueRepository
    {
        public ProductAttributeValueRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public class ProductAttributeDataRepository : GenericRepository<ProductAttributeData>, IProductAttributeDataRepository
    {
        public ProductAttributeDataRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class PublishRepository : GenericRepository<Publisher>, IPublishRepository
    {
        public PublishRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductMediaRepository : GenericRepository<ProductMedia>, IProductMediaRepository
    {
        public ProductMediaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public class MediaRepository : GenericRepository<Media>, IMediaRepository
    {
        public MediaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductBrandRepository : GenericRepository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }



    

}
