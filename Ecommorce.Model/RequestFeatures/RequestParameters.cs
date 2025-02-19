using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
    public class ProductParameters : RequestParameters
    {
     

    }

    public class FiltersParameters : RequestParameters
    {
        public uint OrderMinimumQuantity { get; set; }
        public uint OrderMaximumQuantity { get; set; } = int.MaxValue;
        public bool ValidOrderRange => OrderMaximumQuantity > OrderMinimumQuantity;
  
        public string SearchTerm { get; set; }

    }
}
