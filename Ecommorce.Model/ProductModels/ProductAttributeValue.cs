using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductAttributeValue
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Name { get; set; } // Example: "Red"
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Value { get; set; }
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Description { get; set; }
        public bool IsPublished { get; set; }

        public int AttributeID { get; set; }
        public virtual  ProductAttribute ProductAttribute { get; set; }
        public virtual  ProductAttributeData AttributeData { get; set; }


    }

}
