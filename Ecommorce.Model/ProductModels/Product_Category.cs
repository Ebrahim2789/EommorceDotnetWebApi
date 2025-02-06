using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductCategory : Common
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
   
        public string Thumbnail { get; set; }
        public string DisplayOrder { get; set; }
        public bool IsPublished { get; set; }

        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual ProductCategory ParentCategory { get; set; }
        public ICollection<ProductCategory> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }

        




    }

}
