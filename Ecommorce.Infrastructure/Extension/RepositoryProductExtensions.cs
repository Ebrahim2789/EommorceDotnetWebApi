using System.Text;
using Ecommorce.Model.ProductModels;
using System.Linq.Dynamic.Core;
using Ecommorce.Infrastructure.Extension.Utility;

namespace Ecommorce.Infrastructure.Extension
{
    public static class RepositoryProductExtensions
    {

        public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, int OrderMinimumQuantity, int OrderMaximumQuantity) => products.Where(p => (p.OrderMinimumQuantity >= OrderMinimumQuantity && p.OrderMaximumQuantity <= OrderMaximumQuantity));
        public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return products.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }


        public static IQueryable<Product> Sort(this IQueryable<Product> products, string
        orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(e => e.Name);
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(e => e.Name);
            return products.OrderBy(orderQuery);


        }
    }
}

