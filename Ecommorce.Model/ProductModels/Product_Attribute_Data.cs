using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductAttributeData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
        public int ProductId { get; set; }
        public Product ProductsData { get; set; }
        public string Value { get; set; }
        public bool IsDisplay { get; set; }


    }

}
