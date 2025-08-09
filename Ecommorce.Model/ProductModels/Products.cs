using Ecommorce.Model.OrderModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommorce.Model.ProductModels
{

    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]

        public required string Name { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        public required string Description { get; set; }
        [Required(ErrorMessage = "Code is a required field.")]
        public required string Code { get; set; }
        public string? ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string? LinePrice { get; set; }
        [Required]
        public decimal CostPrice { get; set; }
        public bool StockEnable { get; set; }
        public int Stock { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        [Required]
        public string? ThumbnailImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        [Required(ErrorMessage = "IsPublished is a required field.")]
        public bool IsPublished { get; set; }
        public string ? SKU { get; set; }
        public string? Tags { get; set; }

        //public int VariationsId { get; set; }
        //public virtual ProductVariation? Variations { get; set; }
        public int BrandId { get; set; }
        public virtual  ProductBrand? Brand { get; set; }
        public int PublisherId { get; set; }
        public virtual  Publisher? Publisher { get; set; }

 


        public virtual  ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual  ICollection<ProductMedia>? ProductMedia { get; set; }
        public virtual  ICollection<ProductOption>? ProductOptions { get; set; }
        public virtual  ICollection<ProductAttribute> ProductAttributes { get; set; }


        public virtual ICollection<OrderItem>? OrderDetails { get; set; }


    }

}
