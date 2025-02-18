using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductOptionData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Name { get; set; }  // Example: "Weight"

        public required string Value { get; set; }
        public required string Display { get; set; }
        public int MediaId { get; set; }

        public int ValueID { get; set; }
        public virtual  ProductOptionValue OptionValue { get; set; }



    }

}
