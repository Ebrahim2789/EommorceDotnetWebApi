using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Incoming
{

    public class ProductAttributeDTO
    {

        public required string Name { get; set; }
        public required string Description { get; set; }
        public int ProductId { get; set; }


    }
}
