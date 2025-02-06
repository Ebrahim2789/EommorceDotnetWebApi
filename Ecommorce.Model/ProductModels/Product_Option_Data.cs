using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductOptionData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public int OptionId { get; set; }
        public ProductOption ProductOption { get; set; }
        public int ProductId { get; set; }
       
        public Product Product { get; set; }
        public string Value { get; set; }
        public string Display { get; set; }
        public int MediaId { get; set; }




    }

}
