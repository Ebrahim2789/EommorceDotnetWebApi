using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.ProductModels
{
    public class ProductVariation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VariationId { get; set; }
        public required string Name { get; set; }

        [Required]
        public required string Code { get; set; }

        public decimal Price { get; set; }
        public required string LinePrice { get; set; }
        [Required]
        public decimal CostPrice { get; set; }

        public int Stock { get; set; }

        [Required]
        public required string SKU { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
