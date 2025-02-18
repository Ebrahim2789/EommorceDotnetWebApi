using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommorce.Model.ProductModels
{
    public class ProductMedia : Common
    {
      


        public int ProductID { get; set; }

        public virtual  Product Product { get; set; }

        public int MediaID { get; set; }
        public virtual  Media Media { get; set; }
    }

}
