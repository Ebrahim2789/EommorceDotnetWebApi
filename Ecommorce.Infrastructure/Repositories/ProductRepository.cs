
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Model;
using Ecommorce.Model.ProductModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ecommorce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }


    //ProductOption ProductOptionValue ProductAttribute ProductAttributeValue
    //ProductPublish ProductMedia ProductBrand ProductCategory
  


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
    public class ProductPublishRepository : GenericRepository<ProductPublish>, IProductPublishRepository
    {
        public ProductPublishRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class ProductMediaRepository : GenericRepository<ProductMedia>, IProductMediaRepository
    {
        public ProductMediaRepository(ApplicationDbContext context) : base(context)
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

}
