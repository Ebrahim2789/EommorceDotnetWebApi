using Ecommorce.Model.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Incoming
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Name is a required field.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        public required string Description { get; set; }
        [Required(ErrorMessage = "Code is a required field.")]
        public required string Code { get; set; }
        public decimal Price { get; set; }
 
        public decimal CostPrice { get; set; }

        [Required]
        public string? ThumbnailImageUrl { get; set; }

        [Required(ErrorMessage = "IsPublished is a required field.")]
        public bool IsPublished { get; set; }

        public int BrandId { get; set; }
   
        public int PublisherId { get; set; }
   
        public int  ProductCategoriesID { get; set; }
        public int ProductMediaID { get; set; }
        public int ProductOptionsID { get; set; }
        public int ProductAttributesID { get; set; }

    }
}
