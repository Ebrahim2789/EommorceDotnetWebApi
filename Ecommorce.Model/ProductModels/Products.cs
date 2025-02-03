using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.ProductModels
{
    public class Product_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Code { get; set; }

        public string ShortDescription { get; set; }
        public int ParentId { get; set; }
        public string Price { get; set; }
        public string LinePrice { get; set; }
        public string CostPrice { get; set; }
        public string StockEnable { get; set; }
        public string Stock { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        public string Thumbnail { get; set; }
        public string VideoUrl { get; set; }
        public bool IsPublished { get; set; }
        public string SKU { get; set; }
        public string Tags { get; set; }



    }

}
