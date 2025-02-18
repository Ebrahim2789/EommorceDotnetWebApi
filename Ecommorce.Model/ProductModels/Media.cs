using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class Media
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaID { get; set; }
        public required string MediaType { get; set; }
        public required string MediaName { get; set; }
        public required string ImageUrl { get; set; }
        public int DisplayOrder { get; set; }
        public virtual  ICollection<ProductMedia> ProductMedia { get; set; }


    }
}