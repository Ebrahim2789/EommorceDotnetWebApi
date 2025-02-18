using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Incoming
{
    public class ProductOptionValueDTO
    {
        public int OptionId { get; set; }

        public required string Value { get; set; }
        public required string Display { get; set; }
        public required string Description { get; set; }
        public bool IsDisplay { get; set; }
    }
}
