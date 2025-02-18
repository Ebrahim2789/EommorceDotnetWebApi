using AutoMapper;
using Ecommorce.API.Extentions.ActionFilters;
using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Ecommorce.Model.DTO.Incoming;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommorce.API.Controllers
{
    //[ServiceFilter(typeof(GlobalFilterExample))]
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
        //[ServiceFilter(typeof(GlobalFilterExample))]
        public async Task<ActionResult<ApiResponse<ProductBrand>>> GetProductBrand(int id)
        {
            var products = await _repository.ProductBrand.GetByIdAsync(id);

            if (products == null)
            {
                _logger.LogInfo($"products with id: {id} doesn't exist in the database.");
                return NotFound();
            }

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

            await _repository.ProductBrand.AddAsync(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductBrandDTO>(productBrandEntity);


            var response = new ApiResponse<ProductBrandDTO>(productBrandReturn, true, "Products added successfully");


            return Ok(response);


        }


        [HttpPut("{id}")]
        public IActionResult UpdateProductBrandDTO(int id, [FromBody] ProductBrandDTO productBrand)
        {
            if (productBrand == null)
            {
                _logger.LogError("productBrand object sent from client is null.");
                return BadRequest("productBrand object is null");
            }
            var productBrandEntity = _repository.ProductBrand.GetByIdAsync(id);
            if (productBrandEntity == null)
            {
                _logger.LogInfo($"productBrand with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(productBrand, productBrandEntity);
            _repository.Save();
            return NoContent();
        }



        [HttpPut("updatebrands/{id}")]
        public IActionResult UpdateProductBrandForProduct(int productID, int id, [FromBody] ProductBrandDTO productBrand)
        {
            if (productBrand == null)
            {
                _logger.LogError("ProductBrandDTO object sent from client is null.");
                return BadRequest("ProductBrandDTO object is null");
            }
            var product = _repository.ProductBrand.GetByIdAsync(productID);
            if (product == null)
            {
                _logger.LogInfo($"product with id: {productID} doesn't exist in the  database.");
                return NotFound();
            }
            var productBrandEntity = _repository.ProductBrand.GetByIdAsync(productID);
            if (productBrandEntity == null)
            {
                _logger.LogInfo($"ProductBrand with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var productBrandEntitys = _mapper.Map<ProductBrand>(productBrand);

            //_mapper.Map(productBrand, productBrandEntity);
            _repository.ProductBrand.Update(productBrandEntitys);
            _repository.Save();
            return NoContent();
        }



        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateProductBrandForProduct(int productID, int id, [FromBody] JsonPatchDocument<ProductBrandDTO> patchDoc)
        {
            if (patchDoc == null)
            {


                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }
            var product = _repository.ProductBrand.GetByIdAsync(productID);
            if (product == null)
            {
                _logger.LogInfo($"product with id: {productID} doesn't exist in the   database.");
                return NotFound();
            }
            var productBrandEntity = _repository.ProductBrand.GetByIdAsync(productID);
            if (productBrandEntity == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var productBrandToPatch = _mapper.Map<ProductBrandDTO>(productBrandEntity);

            patchDoc.ApplyTo(productBrandToPatch);

            _mapper.Map(productBrandToPatch, productBrandEntity);
            _repository.Save();
            return NoContent();
        }



        [HttpPut("brands/{id}")]

        public async Task<ActionResult<ApiResponse<ProductBrand>>> EditProductBrand(int id, [FromBody] ProductBrandDTO value)
        {
            var products = await _repository.ProductBrand.GetByIdAsync(id);

            if (products == null)
            {
                _logger.LogError("ProductBrandDTO object sent from client is null.");

                return BadRequest("ProductBrandDTO object is null");

            }

            var productBrandEntity = _mapper.Map<ProductBrand>(value);
            _mapper.Map(value, products);
            //_repository.ProductBrand.Update(products);

            _repository.Save();

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
