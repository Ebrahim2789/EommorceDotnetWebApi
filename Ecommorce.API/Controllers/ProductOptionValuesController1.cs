using AutoMapper;
using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Ecommorce.Model.DTO.Incoming;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionValuesController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;
        private readonly IMapper _mapper;

        public ProductOptionValuesController(IRepositoryManager repository, ILoggerManger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("optionvalues/{id}/option")]

        public async Task<ActionResult<ApiResponse<IEnumerable<ProductOptionValue>>>> GetProductOptionValueByOptionId()
        {
            var productsbrand = await _repository.ProductOptionValue.GetAllAsync();
            var response = new ApiResponse<IEnumerable<ProductOptionValue>>(productsbrand, true, "ProductOption retrieved successfully");
            return Ok(response);
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProductOptionValue>>> GetProductOptionValue(int id)
        {
            var product = await _repository.ProductOptionValue.GetByIdAsync(id);
            if (product == null)
            {
                var errorResponse = new ApiResponse<bool>(false, false, "ProductOptionValue not found");
                return NotFound(errorResponse);
            }

            var response = new ApiResponse<ProductOptionValue>(product, true, "ProductOptionValue retrieved successfully");
            return Ok(response);
        }

 
        [HttpPost]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductOptionValue>>>> AddProductOptionValue([FromBody] ProductOptionValueDTO value)
        {
            if (value == null)
            {
                _logger.LogError("ProductOptionValue object sent from client is null.");

                return BadRequest("ProductOptionValue object is null");
            }
            var productBrandEntity = _mapper.Map<ProductOptionValue>(value);

            await _repository.ProductOptionValue.AddAsync(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductOptionValueDTO>(productBrandEntity);


            var response = new ApiResponse<ProductOptionValueDTO>(productBrandReturn, true, "ProductOption added successfully");


            return Ok(response);
        }

  
        [HttpPut("optionvalues/{id} ")]
        public async Task<ActionResult<ApiResponse<ProductOptionValue>>> EditProductOptionValue(int id, [FromBody] ProductOptionValueDTO value)
        {
            var products = await _repository.ProductOptionValue.GetByIdAsync(id);

            var productBrandEntity = _mapper.Map<ProductOptionValue>(value);
            productBrandEntity.Id = id;

            if (products == null)
            {
                _logger.LogError("ProductOption object sent from client is null.");

                return BadRequest("ProductOption object is null");

            }


            _repository.ProductOptionValue.Update(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductOptionValueDTO>(productBrandEntity);


            var response = new ApiResponse<ProductOptionValueDTO>(productBrandReturn, true, "ProductOption Updated successfully");
            return Ok(response);
        }


        [HttpDelete("optionvalues/{id} ")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProductOptionValue(int id)
        {
            var products = await _repository.ProductOptionValue.GetByIdAsync(id);

            if (products == null)
            {
                _logger.LogError("ProductOptionValue object sent from client is null.");

                return BadRequest("ProductOptionValue object is null");
            }
            _repository.ProductOptionValue.Delete(products);

            var response = new ApiResponse<bool>(true, true, "ProductOptionValue deleted successfully");
            return Ok(response);
        }
    }

 
}
