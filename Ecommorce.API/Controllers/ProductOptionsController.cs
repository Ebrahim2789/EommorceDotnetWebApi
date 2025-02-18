using AutoMapper;
using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Ecommorce.Model.DTO.Incoming;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecommorce.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;
        private readonly IMapper _mapper;

        public ProductOptionsController(IRepositoryManager repository, ILoggerManger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("Option")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductOption>>>> ProductOptionAll()
        {
            var productsbrand = await _repository.ProductOption.GetAllAsync();
            var response = new ApiResponse<IEnumerable<ProductOption>>(productsbrand, true, "ProductOption retrieved successfully");
            return Ok(response);
        }




        [HttpGet("Option/{id}")]
        public async Task<ActionResult<ApiResponse<ProductOption>>> GetProductOption(int id)
        {
            var product = await _repository.ProductOption.GetByIdAsync(id);
            if (product == null)
            {
                var errorResponse = new ApiResponse<bool>(false, false, "ProductOption not found");
                return NotFound(errorResponse);
            }

            var response = new ApiResponse<ProductOption>(product, true, "PProductOptionroduct retrieved successfully");
            return Ok(response);
        }

        [HttpPost("Option")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductBrand>>>> AddProductOption([FromBody] ProductOptionDTO value)
        {


            if (value == null)
            {
                _logger.LogError("ProductOption object sent from client is null.");

                return BadRequest("ProductOption object is null");
            }
            var productBrandEntity = _mapper.Map<ProductOption>(value);

            await _repository.ProductOption.AddAsync(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductOptionDTO>(productBrandEntity);


            var response = new ApiResponse<ProductOptionDTO>(productBrandReturn, true, "ProductOption added successfully");


            return Ok(response);



        }


        [HttpPut("Option/{id}")]
        public async Task<ActionResult<ApiResponse<ProductBrand>>> EditProductOption(int id, [FromBody] ProductOptionDTO value)
        {

            var products = await _repository.ProductOption.GetByIdAsync(id);

            var productBrandEntity = _mapper.Map<ProductOption>(value);


            if (products == null)
            {
                _logger.LogError("ProductOption object sent from client is null.");

                return BadRequest("ProductOption object is null");

            }


            _repository.ProductOption.Update(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductOptionDTO>(productBrandEntity);


            var response = new ApiResponse<ProductOptionDTO>(productBrandReturn, true, "ProductOption Updated successfully");
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProductOption(int id)
        {
            var products = await _repository.ProductOption.GetByIdAsync(id);

            if (products == null)
            {
                _logger.LogError("ProductOption object sent from client is null.");

                return BadRequest("ProductOption object is null");
            }
            _repository.ProductOption.Delete(products);

            var response = new ApiResponse<bool>(true, true, "ProductOption deleted successfully");
            return Ok(response);
        }




    }

}
