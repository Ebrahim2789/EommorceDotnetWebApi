

using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Model;
using Ecommorce.Model.OrderModels;

namespace Ecommorce.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository

    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}