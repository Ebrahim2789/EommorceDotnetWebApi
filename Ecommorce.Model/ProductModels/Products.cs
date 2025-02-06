using Ecommorce.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.ProductModels
{

    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string LinePrice { get; set; }
        [Required]
        public decimal CostPrice { get; set; }
        public bool StockEnable { get; set; }
        public int Stock { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string VideoUrl { get; set; }
        [Required]
        public bool IsPublished { get; set; }
        public string SKU { get; set; }
        public string Tags { get; set; }
        //public int ParentId { get; set; }
        //[ForeignKey(nameof(ParentId))]
        //public Product_Product Parent { get; set; }


        public int BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public virtual ProductBrand Brand { get; set; }

        public int CategroyId { get; set; }
        [ForeignKey(nameof(CategroyId))]
        public virtual ProductCategory Categroy { get; set; }

        public int PublisherId { get; set; }
        [ForeignKey(nameof(PublisherId))]
        public virtual ProductPublish Publisher { get; set; }

        public ICollection<ProductMedia> Medias { get; set; }


        public ICollection<ProductOption> Options { get; set; }

        public ICollection<ProductOptionData> OptionsData { get; set; }


        public ICollection<ProductAttribute> Attributes{ get; set; }

        public ICollection<ProductAttributeData> AttributesData { get; set; }

    }

}
