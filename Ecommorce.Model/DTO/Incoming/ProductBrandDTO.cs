using Ecommorce.Model.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Incoming
{
    public class ProductBrandDTO
    {
   

        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsPublished { get; set; }

    }


    public class ProductBrandDTOForProduct: ProductBrandDTO
    {

        public ICollection<Product>? Products { get; set; }
    }
}
