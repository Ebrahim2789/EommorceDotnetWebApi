using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductAttribute
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       [Required(ErrorMessage = "Fields is a required field.")]
        public required string Name { get; set; }// Example: "Color"
       [Required(ErrorMessage = "Fields is a required field.")]
        public required string Description { get; set; }

        public int ProductID { get; set; }
        public virtual  Product Product { get; set; }
        public virtual  ICollection<ProductAttributeValue> AttributeValues { get; set; }
    }

}
