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
    public class ProductAttributeValuesController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;
        private readonly IMapper _mapper;

        public ProductAttributeValuesController(IRepositoryManager repository, ILoggerManger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductAttributeValue>>>> GetProductAttributeValueByAttributeId()
        {
            var productsbrand = await _repository.ProductAttributeValue.GetAllAsync();
            var response = new ApiResponse<IEnumerable<ProductAttributeValue>>(productsbrand, true, "ProductAttribute retrieved successfully");
            return Ok(response);
        }


        [HttpGet("attributevalues/{id}")]
        public async Task<ActionResult<ApiResponse<ProductAttributeValue>>> GetProductAttributeValue(int id)
        {
            var products = await _repository.ProductAttributeValue.GetByIdAsync(id);


            var companiesDto = _mapper.Map<ProductAttributeValuesDTO>(products);



            var response = new ApiResponse<ProductAttributeValuesDTO>(companiesDto, true, "ProductAttribute retrieved successfully");


            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductAttributeValue>>>> AddProductAttributeValue([FromBody] ProductAttributeValuesDTO value)
        {
            if (value == null)
            {
                _logger.LogError("ProductAttributeValue object sent from client is null.");

                return BadRequest("ProductAttributeValue object is null");
            }
            var productAttribute=   _repository.ProductAttribute.GetByIdAsync(value.AttributeId);

            var productBrandEntity = _mapper.Map<ProductAttributeValue>(value);
            // productBrandEntity.Attribute = productAttribute.Result;

            await _repository.ProductAttributeValue.AddAsync(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductAttributeValuesDTO>(productBrandEntity);


            var response = new ApiResponse<ProductAttributeValuesDTO>(productBrandReturn, true, "ProductAttributeValue added successfully");


            return Ok(response);
        }


        [HttpPut("attributevalues/{id} ")]
        public async Task<ActionResult<ApiResponse<ProductAttributeValue>>> EditProductAttributeValue(int id, [FromBody] ProductAttributeValuesDTO value)
        {
            var products = await _repository.ProductAttributeValue.GetByIdAsync(id);

            var productBrandEntity = _mapper.Map<ProductAttributeValue>(value);
          

            if (products == null)
            {
                _logger.LogError("ProductAttributeValue object sent from client is null.");

                return BadRequest("ProductAttributeValue object is null");

            }


            _repository.ProductAttributeValue.Update(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductAttributeValuesDTO>(productBrandEntity);


            var response = new ApiResponse<ProductAttributeValuesDTO>(productBrandReturn, true, "ProductAttribute Updated successfully");
            return Ok(response);
        }

     
        [HttpDelete("attributevalues/{id} ")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProductAttributeValue(int id)
        {
            var products = await _repository.ProductAttributeValue.GetByIdAsync(id);

            if (products == null)
            {
                _logger.LogError("ProductAttributeValue object sent from client is null.");

                return BadRequest("ProductAttributeValue object is null");
            }
            _repository.ProductAttributeValue.Delete(products);

            var response = new ApiResponse<bool>(true, true, "ProductAttributeValue deleted successfully");
            return Ok(response);
        }
    }



}
