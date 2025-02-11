
using Ecommorce.Application.ILogger;
using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecommorce.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;

        public ProductsController(IRepositoryManager repository, ILoggerManger logger)
        {
            _repository = repository;
            _logger = logger;
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



        [HttpGet("grid")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Product>>>> GetProductGrid()
        {
            var products = await _repository.Product.GetAllAsync();
            var response = new ApiResponse<IEnumerable<Product>>(products, true, "Products retrieved successfully");
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
        public async Task<ActionResult<ApiResponse<Product>>> GetProductById(int id)
        {
            var product = await _repository.Product.GetByIdAsync(id);
            if (product == null)
            {
                var errorResponse = new ApiResponse<bool>(false, false, "Product not found");
                return NotFound(errorResponse);
            }

            var response = new ApiResponse<Product>(product, true, "Product retrieved successfully");
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Product>>> AddProduct(Product product)
        {

            var createdProduct = _repository.Product.AddAsync(product);
            var data = await _repository.Product.GetByIdAsync(createdProduct.Id);

            var response = new ApiResponse<Product>(data, true, "Product added successfully");

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