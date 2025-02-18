using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ecommorce.Model.ProductModels
{
    public class ProductCategory : Common
    {
      

        public int CategoryID { get; set; }
    
        public virtual  Category Category { get; set; }

        public int ProductID { get; set; }
        public virtual  Product? Products { get; set; }


    }

}
