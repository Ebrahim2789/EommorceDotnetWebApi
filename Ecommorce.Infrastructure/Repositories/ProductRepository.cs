
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

}
