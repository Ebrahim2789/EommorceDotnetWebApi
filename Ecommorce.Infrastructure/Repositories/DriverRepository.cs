using Ecommorce.Application.IRepository;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Model;
using Ecommorce.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Infrastructure.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
