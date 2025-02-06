using Ecommorce.Model.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommorce.Model.ProductModels
{
    public class ProductPublish : Common
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime PublishTimeFrom { get; set; }
        public DateTime PublishTimeTo { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplay { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Publisher { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
