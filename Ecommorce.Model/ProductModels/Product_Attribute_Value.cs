using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class ProductAttributeValue
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public virtual ProductAttribute Attribute { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }




    }

}
