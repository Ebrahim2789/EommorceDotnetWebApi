

using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;
using Ecommorce.Infrastructure.Repositories;
using Ecommorce.Model;

namespace Ecommorce.Infrastructure.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private ProductRepository _productRepository;
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
        private TokenRepository _tokenRepository;

        private OrderRepository _orderRepository;
        private CarRepository _carRepository;
        private DriverRepository _driverRepository;

        private ProductOptionRepository _productOptionRepository;
        private ProductOptionValueRepository _productOptionValueRepository;

        private ProductOptionDataRepository _productOptionDataRepository;
        private ProductAttributeRepository _productAttributeRepository;
        private ProductBrandRepository _productBrandRepository;

        private ProductAttributeValueRepository _productAttributeValueRepository;
        private ProductAttributeDataRepository _productAttributeDataRepository;
        private PublishRepository _productPublishRepository;
        private ProductMediaRepository _productMediaRepository;

        private MediaRepository _mediaRepository;
        private ProductCategoryRepository _productCategoryRepository;
        private CategoryRepository _categoryRepository;

        public RepositoryManager(ApplicationDbContext context)
        {

            _context = context;
        }


        public IProductRepository Product
        {

            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);
                return _productRepository;
            }

        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;

            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_context);
                return _orderRepository;
            }
        }

        public ICarRepository Car
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new CarRepository(_context);
                return _carRepository;
            }
        }

        public IDriverRepository Driver
        {
            get
            {
                if (_driverRepository == null)
                    _driverRepository = new DriverRepository(_context);

                return _driverRepository;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_context);
                return _roleRepository;
            }
        }

        public ITokenRepository Token
        {
            get
            {
                if (_tokenRepository == null)
                    _tokenRepository = new TokenRepository(_context);
                return _tokenRepository;
            }
        }
        //      
        //  ProductCategory
        public IProductOptionRepository ProductOption
        {
            get
            {
                if (_productOptionRepository == null)
                    _productOptionRepository = new ProductOptionRepository(_context);
                return _productOptionRepository;
            }
        }

        public IProductOptionValueRepository ProductOptionValue
        {
            get
            {
                if (_productOptionValueRepository == null)
                    _productOptionValueRepository = new ProductOptionValueRepository(_context);
                return _productOptionValueRepository;
            }
        }

        public IProductAttributeRepository ProductAttribute
        {
            get
            {
                if (_productAttributeRepository == null)
                    _productAttributeRepository = new ProductAttributeRepository(_context);
                return _productAttributeRepository;

            }
        }

        public IProductBrandRepository ProductBrand
        {
            get
            {
                if (_productBrandRepository == null)
                    _productBrandRepository = new ProductBrandRepository(_context);
                return _productBrandRepository;
            }
        }

        public IProductAttributeValueRepository ProductAttributeValue
        {
            get
            {
                if (_productAttributeValueRepository == null)
                    _productAttributeValueRepository = new ProductAttributeValueRepository(_context);
                return _productAttributeValueRepository;

            }
        }

        public IPublishRepository Publish
        {
            get
            {
                if (_productPublishRepository == null)
                    _productPublishRepository = new PublishRepository(_context);
                return _productPublishRepository;
            }
        }

        public IProductMediaRepository ProductMedia
        {
            get
            {
                if (_productMediaRepository == null)
                    _productMediaRepository = new ProductMediaRepository(_context);
                return _productMediaRepository;
            }
        }

        public IProductCategoryRepository ProductCategory
        {
            get
            {
                if (_productCategoryRepository == null)
                    _productCategoryRepository = new ProductCategoryRepository(_context);
                return _productCategoryRepository;
            }
        }

        public IMediaRepository Media
        {
            get
            {
                if (_mediaRepository == null)
                    _mediaRepository = new MediaRepository(_context);
                return _mediaRepository;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        public IProductOptionDataRepository ProductOptionData
        {
            get
            {
                if (_productOptionDataRepository == null)
                    _productOptionDataRepository = new ProductOptionDataRepository(_context);
                return _productOptionDataRepository;
            }
        }

        public IProductAttributeDataRepository ProductAttributeData
        {
            get
            {
                if (_productAttributeDataRepository == null)
                    _productAttributeDataRepository = new ProductAttributeDataRepository(_context);
                return _productAttributeDataRepository;
            }
        }

        public void Save() => _context.SaveChanges();

    }
}
