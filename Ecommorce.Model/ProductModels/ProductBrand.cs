using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductBrand : Common
    {
        public int Id { get; set; }
        [Required]
        public string Name { set; get; }
        [Required]
     

        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsPublished { get; set; }


        public ICollection<Product> Products { get; set; }
    }

}
