using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommorce.Model.ProductModels
{
    public class Publisher
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherID { get; set; }


        public DateTime PublishTimeFrom { get; set; }= DateTime.Now;
        public DateTime PublishTimeTo { get; set; }=DateTime.Now;
        public int DisplayOrder { get; set; } = 1;
        public bool IsDisplay { get; set; }=false;

        public  ICollection<Product>? Products { get; set; }=new List<Product>();


    }

}
