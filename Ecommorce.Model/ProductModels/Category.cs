using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Code { get; set; }
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Description { get; set; }

        public string? Thumbnail { get; set; }
        public string? DisplayOrder { get; set; }
        [Required(ErrorMessage = "Fields is a required field.")]
        public bool IsPublished { get; set; }

        public virtual  ICollection<ProductCategory>? Categories { get; set; }
    }
}

