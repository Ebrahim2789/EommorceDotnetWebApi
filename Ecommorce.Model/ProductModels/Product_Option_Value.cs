using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductOptionValue
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductOptionDataId { get; set; }
  
        public virtual ProductOptionData ProductOptionData { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Value { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
        public bool IsDisplay { get; set; }



    }

}
