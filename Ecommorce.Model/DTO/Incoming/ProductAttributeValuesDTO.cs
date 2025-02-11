using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Incoming
{
    public class ProductAttributeValuesDTO
    {


        public int AttributeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
    }
}
