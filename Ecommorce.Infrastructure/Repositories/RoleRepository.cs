

using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Model;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.UserModel;


namespace Ecommorce.Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }


}