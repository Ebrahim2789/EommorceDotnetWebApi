using Ecommorce.Model.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Incoming
{
    public class ProductMediaDTO
    {
 
        public required string MediaType { get; set; }
        public required string MediaName { get; set; }
        public required string ImageUrl { get; set; }
        public int DisplayOrder { get; set; }

    
        public int ProductID { get; set; }


    }
}
