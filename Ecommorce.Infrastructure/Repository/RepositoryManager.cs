

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

          public RepositoryManager(ApplicationDbContext context) {

            _context = context;
        }


        public IProductRepository Product {

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
                if(_userRepository==null)
                    _userRepository=new UserRepository(_context);
                return _userRepository;

            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository==null)
                _orderRepository=new OrderRepository(_context);
               return _orderRepository;
            }
        }

        public ICarRepository Car
        {
            get
            {
                  if (_carRepository==null)
                _carRepository=new CarRepository(_context);
               return _carRepository;
            }
        }

        public IDriverRepository Driver
        {
            get
            {
                if(_driverRepository==null)
                _driverRepository=new DriverRepository(_context);

                return _driverRepository;
            }
        }

        public IRoleRepository Role {
            get{
                if (_roleRepository==null)
                    _roleRepository=new RoleRepository(_context);
                return _roleRepository;
            }
        }

        public ITokenRepository Token
        {
            get
            {
                if(_tokenRepository==null)
                    _tokenRepository=new TokenRepository(_context);
                return _tokenRepository;
            }
        }
    }
}
