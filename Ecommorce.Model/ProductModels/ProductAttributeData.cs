using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductAttributeData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Name { get; set; }  // Example: "Hex Code"
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Value { get; set; } // Example: "#FF0000"
        [Required(ErrorMessage = "Fields is a required field.")]
        public bool IsDisplay { get; set; }
        public int ValueID { get; set; }
        public virtual  ProductAttributeValue AttributeValue { get; set; }




    }

}
