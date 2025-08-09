using AutoMapper;
using Ecommorce.Model.ProductModels;
using Microsoft.AspNetCore.Mvc;
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

   
        public int ProductMediaID { get; set; }
        public int ProductOptionsID { get; set; }
        public int ProductAttributesID { get; set; }

    }



    public class ProductDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Code { get; set; }
        public string? ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string? LinePrice { get; set; }
        public required decimal CostPrice { get; set; }
        public bool StockEnable { get; set; }
        public int Stock { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        public required string ThumbnailImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public required bool IsPublished { get; set; }
        public string? SKU { get; set; }
        public string? Tags { get; set; }
        public required int BrandId { get; set; }
        public required int PublisherId { get; set; }

        // Related collections
        public List<int>? ProductCategoryIds { get; set; }  // IDs of selected categories
        public List<string>? ProductMediaUrls { get; set; } // URLs for images/videos
        public List<ProductOptionDto>? ProductOptions { get; set; } // Product option details
    }

    public class UpdateProductDto: ProductDto
    {
        public int Id { get; set; }
       
    }

    public class ProductOptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }


    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Mapping Product -> ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductCategoryIds, opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.CategoryID).ToList()))
                .ForMember(dest => dest.ProductMediaUrls, opt => opt.MapFrom(src => src.ProductMedia.Select(pm => pm.Media).ToList()))
                .ForMember(dest => dest.ProductOptions, opt => opt.MapFrom(src => src.ProductOptions));

            // Mapping CreateProductDto -> Product
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.ProductCategories, opt => opt.Ignore())
                .ForMember(dest => dest.ProductMedia, opt => opt.Ignore())
                .ForMember(dest => dest.ProductOptions, opt => opt.Ignore());

            // Mapping UpdateProductDto -> Product (for PATCH or PUT updates)
            CreateMap<UpdateProductDto, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Only update non-null fields
        }
    }

}




//[ApiController]
//[Route("api/products")]
//public class ProductController : ControllerBase
//{
//    private readonly IMapper _mapper;
//    private readonly IProductService _productService; // Assume you have a service handling business logic

//    public ProductController(IMapper mapper, IProductService productService)
//    {
//        _mapper = mapper;
//        _productService = productService;
//    }

//    // GET: api/products/{id}
//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetProduct(int id)
//    {
//        var product = await _productService.GetProductByIdAsync(id);
//        if (product == null) return NotFound();

//        var productDto = _mapper.Map<ProductDto>(product);
//        return Ok(productDto);
//    }

//    // POST: api/products
//    [HttpPost]
//    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createDto)
//    {
//        if (!ModelState.IsValid) return BadRequest(ModelState);

//        var product = _mapper.Map<Product>(createDto);
//        var createdProduct = await _productService.CreateProductAsync(product);

//        var productDto = _mapper.Map<ProductDto>(createdProduct);
//        return CreatedAtAction(nameof(GetProduct), new { id = productDto.Id }, productDto);
//    }

//    // PUT: api/products/{id}
//    [HttpPut("{id}")]
//    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateDto)
//    {
//        if (!ModelState.IsValid) return BadRequest(ModelState);

//        var existingProduct = await _productService.GetProductByIdAsync(id);
//        if (existingProduct == null) return NotFound();

//        _mapper.Map(updateDto, existingProduct);
//        await _productService.UpdateProductAsync(existingProduct);

//        return NoContent();
//    }
//}
