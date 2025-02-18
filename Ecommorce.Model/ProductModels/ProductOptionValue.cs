using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductOptionValue
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Name { get; set; }
        public int DisplayType { get; set; }
        public  string Value { get; set; }
        public  string Display { get; set; }
        [Required]
        public  string Description { get; set; }
        public bool IsDisplay { get; set; }
        public int OptionID { get; set; }
        public virtual  ProductOption ProductOption { get; set; }
        public virtual  ProductOptionData OptionData { get; set; }
    }

}
