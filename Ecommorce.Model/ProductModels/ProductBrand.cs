using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommorce.Model.ProductModels
{
    public class ProductBrand : Common
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        public required string Name { set; get; }
        [Required(ErrorMessage = "Code is a required field.")]
        public required string Code { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        public required string Description { get; set; }
        [Required(ErrorMessage = "IsPublished is a required field.")]
        public bool IsPublished { get; set; }


        public virtual ICollection<Product>? Products { get; set; }
    }

}
