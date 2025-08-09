
using System.Linq.Expressions;
using AutoMapper;
using Ecommorce.Application.Extensions;
using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Ecommorce.Model.DTO.Incoming;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.RequestFeatures;
using Ecommorce.Model.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ecommorce.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;
        private readonly IDataShaper<ProductDTO> _dataShaper;
        private readonly IMapper _mapper;
        public ProductsController(IRepositoryManager repository, IDataShaper<ProductDTO> dataShaper, ILoggerManger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _dataShaper = dataShaper;
            _mapper = mapper;
        }



        [HttpGet("customer")]

        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> CoustomerGetProductList(string openid)
        {
            var products = await _repository.Product.GetAllAsync();
            var response = new ApiResponse<IEnumerable<Product>>(products, true, "Products retrieved successfully");
            return Ok(response);
        }

        [HttpGet("merchant")]

        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> MerchantGetProductList(string openid)
        {
            var products = await _repository.Product.GetAllAsync();
            var response = new ApiResponse<IEnumerable<Product>>(products, true, "Products retrieved successfully");
            return Ok(response);
        }



        [HttpGet("FilterProductsAsync")]
        public async Task<IActionResult> FilterProductsAsync([FromQuery] FiltersParameters productParameters)
        {
            var products = await _repository.Product.FilterProductsAsync(10, productParameters, false);
            // var products = await _repository.Product.GetByIdAsync(11);
            var response = new ApiResponse<IEnumerable<Product>>(products, true, $"{products} Products retrieved successfully");
            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(products.MetaData));

            return Ok(response);
            // var productsDto = _mapper.Map<IEnumerable<ProductDTO>>(products);

            // return Ok(_dataShaper.ShapeData(productsDto, productParameters.Fields));

        }

        [HttpGet("GetProductGridAsnyc")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetProductGridAsnyc([FromQuery] ProductParameters productParameters)
        {
            var products = await _repository.Product.GetProductsAsync(10, productParameters, false);

            var response = new ApiResponse<IEnumerable<Product>>(products, true, $"{products} Products retrieved successfully");
            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(products.MetaData));

            return Ok(response);



        }

        [HttpGet("grid")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetProductGrid([FromQuery] ProductParameters productParameters)
        {



            var products = await _repository.Product.GetProductsAsync(10, productParameters, false);



            //var products = await _repository.Product.GetGridAsync(productParameters,
            //                                                      orderBy: q => q.OrderBy(p => p.Name),
            //                                                      includes: p => p.ProductCategories,
            //                                                      p => p.ProductAttributes,
            //                                                      p => p.Brand);
            //  var response = new ApiResponse<IEnumerable<Product>>(products, true, $"{products.TotalCount} Products retrieved successfully");



            // Usage:
            var conditions = new List<Expression<Func<Product, bool>>>
                    {
                        u => true,

                    };

            var product2 = _repository.Product.FindIncluding(conditions,      p => p.ProductCategories,
                    p=>p.ProductAttributes,
                    p=>p.Brand);

            var response = new ApiResponse<IEnumerable<Product>>(products, true, $" Products retrieved successfully");





            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetProducts()
        {
            var products = await _repository.Product.GetAllAsync();
            var response = new ApiResponse<IEnumerable<Product>>(products, true, "Products retrieved successfully");
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetProductById(int id)
        {


            var product = await _repository.Product.GetByIdAsync(id);


            var products = await _repository.Product.FindByCondition(p => p.Id == product.Id).Include(p => p.ProductCategories)
            .Include(p => p.ProductAttributes).Include(p => p.Brand).Include(p => p.ProductOptions)
            .ToListAsync();



            //  .Include(p => p.ProductCategories).ThenInclude(p => P.ProductAttributes).FirstOrDefaultAsync(p => p.Id == id);


            if (product == null)
            {
                var errorResponse = new ApiResponse<bool>(false, false, "Product not found");
                return NotFound(errorResponse);
            }

            var response = new ApiResponse<IEnumerable<Product>>(products, true, "Product retrieved successfully");

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Product>>> AddProduct(Product product)
        {



            if (product == null) return null;

            var brand = await _repository.ProductBrand.GetByIdAsync(product.BrandId);
            var publish = await _repository.Publish.GetByIdAsync(product.PublisherId);
            var pcatgory = product.ProductCategories;
            //pcatgory.

            product.Brand = brand;
            product.BrandId = brand.Id;

            product.PublisherId = publish.PublisherID;
            product.Publisher = publish;
            //product.ProductCategories= pcatgory;

            var createdProduct = _repository.Product.AddAsync(product);


            if (createdProduct.Id != null)
            {

                var attribute = new ProductAttribute { ProductID = product.Id, Name = "Color", Description = "this for this" };
                //  var value = new ProductAttributeValue {AttributeID = attribute.Id, Name="", Value = "Red" , Description=""};


                // await _repository.ProductAttributeValue.AddAsync(value);

                //  var data = new ProductAttributeData { ValueID = value.Id, Name = "Image", Value = "red-shirt.jpg" };

                //await  _repository.ProductAttributeData.AddAsync(data);
                try
                {
                    await _repository.ProductAttribute.AddAsync(attribute);
                }
                catch (Exception ex)
                {
                    var errorResponse = new ApiResponse<bool>(false, false, "Product not found");
                    return NotFound(errorResponse);

                }



            }


            var response = new ApiResponse<object>(createdProduct, true, "Product added successfully");

            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, response);
        }
        [HttpPost("Publisher")]
        public async Task<ActionResult<ApiResponse<Publisher>>> AddPublisher(Publisher product)
        {



            if (product == null) return null;



            var createdProduct = _repository.Publish.AddAsync(product);


            var response = new ApiResponse<Publisher>(product, true, "Product added successfully");

            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Product>>> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                var errorResponse = new ApiResponse<bool>(false, false, "Product not found");

                return BadRequest(errorResponse);
            }

            var result = await _repository.Product.GetByIdAsync(id);


            if (result == null)
            {
                var errorResponse = new ApiResponse<bool>(false, false, "Product not found");
                return NotFound(errorResponse);
            }

            _repository.Product.Update(product);

            var response = new ApiResponse<Product>(product, true, "Product updated successfully");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProduct(int id)
        {

            var product = await _repository.Product.GetByIdAsync(id);

            if (product == null)
            {
                var errorResponse = new ApiResponse<bool>(false, false, "Product not found");
                return NotFound(errorResponse);

            }
            _repository.Product.Delete(product);

            var response = new ApiResponse<bool>(true, true, "Product deleted successfully");
            return Ok(response);

        }



        [HttpPost("PublishProduct")]

        public async Task<ActionResult<ApiResponse<Product>>> PublishProduct(Product product)
        {
            //public async Task<ActionResult<ApiResponse<ProductPublish>>> PublishProduct(PublishProductDTO product)
            //{
            var createdProduct = _repository.Product.AddAsync(product);
            var data = await _repository.Product.GetByIdAsync(createdProduct.Id);

            var response = new ApiResponse<Product>(data, true, "Product added successfully");

            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, response);
        }
    }



}