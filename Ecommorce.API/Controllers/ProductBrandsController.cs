using AutoMapper;
using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Ecommorce.Model.DTO.Incoming;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.Shared;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;
        private readonly IMapper _mapper;

        public ProductBrandsController(IRepositoryManager repository, ILoggerManger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("brands")]

        public async Task<ActionResult<ApiResponse<IEnumerable<ProductBrand>>>> ProductBrandAll()
        {
            var productsbrand = await _repository.ProductBrand.GetAllAsync();
            var response = new ApiResponse<IEnumerable<ProductBrand>>(productsbrand, true, "Products retrieved successfully");
            return Ok(response);
        }



        [HttpGet("brands/{id}")]

        public async Task<ActionResult<ApiResponse<ProductBrand>>> GetProductBrand(int id)
        {
            var products = await _repository.ProductBrand.GetByIdAsync(id);


            var companiesDto = _mapper.Map<ProductBrandDTO>(products);



            var response = new ApiResponse<ProductBrandDTO>(companiesDto, true, "ProductBrand retrieved successfully");
          
            
            return Ok(response);
        }

        [HttpPost("brands")]

        public async Task<ActionResult<ApiResponse<IEnumerable<ProductBrandDTO>>>> AddProductBrand([FromBody] ProductBrandDTO value)
        {

            if (value == null)
            {
                _logger.LogError("ProductBrandDTO object sent from client is null.");

                return BadRequest("ProductBrandDTO object is null");
            }
            var productBrandEntity = _mapper.Map<ProductBrand>(value);

               await  _repository.ProductBrand.AddAsync(productBrandEntity);

           
            var productBrandReturn = _mapper.Map<ProductBrandDTO>(productBrandEntity);

        
            var response = new ApiResponse<ProductBrandDTO>(productBrandReturn, true, "Products added successfully");
           
            
            return Ok(response);


        }


        [HttpPut("brands/{id}")]

        public async Task<ActionResult<ApiResponse<ProductBrand>>> EditProductBrand(int id, [FromBody] ProductBrandDTO value)
        {
            var products = await _repository.ProductBrand.GetByIdAsync(id);

            var productBrandEntity = _mapper.Map<ProductBrand>(value);
            productBrandEntity.Id = id;

            if (products==null)
            {
                _logger.LogError("ProductBrandDTO object sent from client is null.");

                return BadRequest("ProductBrandDTO object is null");

            }


             _repository.ProductBrand.Update(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductBrandDTO>(productBrandEntity);


            var response = new ApiResponse<ProductBrandDTO>(productBrandReturn, true, "Products Updated successfully");
            return Ok(response);
        }

 
        [HttpDelete("{id}")]

        public async Task<ActionResult<ApiResponse<bool>>> DeleteProductBrand(int id)
        {
            var products = await _repository.ProductBrand.GetByIdAsync(id);

            if (products == null)
            {
                _logger.LogError("ProductBrandDTO object sent from client is null.");

                return BadRequest("ProductBrandDTO object is null");
            }
            _repository.ProductBrand.Delete(products);

            var response = new ApiResponse<bool>(true, true, "ProductBrand deleted successfully");
            return Ok(response);

        }
    }



}
