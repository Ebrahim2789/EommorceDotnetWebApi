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
    public class ProductAttributesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;

        private readonly IMapper _mapper;

        public ProductAttributesController(IRepositoryManager repository, ILoggerManger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("attributes")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductAttribute>>>> ProductAttributeAll()
        {
            var productsbrand = await _repository.ProductAttribute.GetAllAsync();
            var response = new ApiResponse<IEnumerable<ProductAttribute>>(productsbrand, true, "ProductAttribute retrieved successfully");
            return Ok(response);
        }




        [HttpGet("attributes/{id}")]
        public async Task<ActionResult<ApiResponse<ProductAttribute>>> GetProductAttribute(int id)
        {
            var products = await _repository.ProductAttribute.GetByIdAsync(id);


            var companiesDto = _mapper.Map<ProductAttributeDTO>(products);



            var response = new ApiResponse<ProductAttributeDTO>(companiesDto, true, "ProductAttribute retrieved successfully");


            return Ok(response);
        }

        [HttpPost("attributes")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductAttribute>>>> AddProductAttribute([FromBody] ProductAttributeDTO value)
        {


            if (value == null)
            {
                _logger.LogError("ProductAttribute object sent from client is null.");

                return BadRequest("ProductAttribute object is null");
            }
            var productBrandEntity = _mapper.Map<ProductAttribute>(value);


            if (value.ProductId != null)
            {

                var attribute = new ProductAttribute { ProductID = value.ProductId, Name = "Color", Description = "this for this" };

                try
                {
                    await _repository.ProductAttribute.AddAsync(attribute);

                    var values = new ProductAttributeValue { AttributeID = attribute.Id, Name = "", Value = "Red", Description = "" };


                    await _repository.ProductAttributeValue.AddAsync(values);

                    var data = new ProductAttributeData { ValueID = values.Id, Name = "Image", Value = "red-shirt.jpg" };

                    await _repository.ProductAttributeData.AddAsync(data);
                }
                catch (Exception ex)
                {
                    var errorResponse = new ApiResponse<bool>(false, false, "Product not found");
                    return NotFound(errorResponse);

                }


            }

            //await _repository.ProductAttribute.AddAsync(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductAttributeDTO>(productBrandEntity);


            var response = new ApiResponse<ProductAttributeDTO>(productBrandReturn, true, "ProductAttribute added successfully");


            return Ok(response);


        }


        [HttpPut("attributes/{id}")]
        public async Task<ActionResult<ApiResponse<ProductAttribute>>> EditProductAttribute(int id, [FromBody] ProductAttributeDTO value)
        {
            var products = await _repository.ProductAttribute.GetByIdAsync(id);

            var productBrandEntity = _mapper.Map<ProductAttribute>(value);


            if (products == null)
            {
                _logger.LogError("ProductAttribute object sent from client is null.");

                return BadRequest("ProductAttribute object is null");

            }


            _repository.ProductAttribute.Update(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductAttributeDTO>(productBrandEntity);


            var response = new ApiResponse<ProductAttributeDTO>(productBrandReturn, true, "ProductAttribute Updated successfully");
            return Ok(response);
        }


        [HttpDelete("attributes/{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProductAttribute(int id)
        {
            var products = await _repository.ProductAttribute.GetByIdAsync(id);

            if (products == null)
            {
                _logger.LogError("ProductAttribute object sent from client is null.");

                return BadRequest("ProductAttribute object is null");
            }
            _repository.ProductAttribute.Delete(products);

            var response = new ApiResponse<bool>(true, true, "ProductAttribute deleted successfully");
            return Ok(response);

        }



    }

}
