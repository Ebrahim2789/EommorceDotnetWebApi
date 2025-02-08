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
}
