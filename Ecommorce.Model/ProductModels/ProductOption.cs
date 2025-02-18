using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductOption : Common
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Name { get; set; }
        public  string Description { get; set; }
        public int DisplayType { get; set; }
        public int ProductID { get; set; }
        public virtual  Product Product { get; set; }
        public virtual  ICollection<ProductOptionValue> OptionValues { get; set; }



    }

}


// Product