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

        public string Value { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
        public bool IsDisplay { get; set; }
    }
}
