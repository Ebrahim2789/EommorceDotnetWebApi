using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Incoming
{
    public class ProductCategoryDTO
    {


        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public string Thumbnail { get; set; }
        public string DisplayOrder { get; set; }
        public bool IsPublished { get; set; }
    }
}
