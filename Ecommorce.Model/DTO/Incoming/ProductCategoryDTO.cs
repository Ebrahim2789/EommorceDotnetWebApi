using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO.Incoming
{
    public class ProductCategoryDTO
    {
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Code { get; set; }
        [Required(ErrorMessage = "Fields is a required field.")]
        public required string Description { get; set; }

        public string? DisplayOrder { get; set; }
        [Required(ErrorMessage = "Fields is a required field.")]
        public bool IsPublished { get; set; }


        public int ProductID { get; set; }
    }
}
