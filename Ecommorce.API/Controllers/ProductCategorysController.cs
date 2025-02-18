
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using global::Ecommorce.Application.ILogger;
using global::Ecommorce.Application.Repository;
using Ecommorce.Model.DTO.Incoming;
using AutoMapper;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategorysController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;
        private readonly IMapper _mapper;

        public ProductCategorysController(IRepositoryManager repository, ILoggerManger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("categories")]

        public async Task<ActionResult<ApiResponse<IEnumerable<ProductCategory>>>> ProductCategoryAll()
        {
            var productCategory = await _repository.ProductCategory.GetAllAsync();
            var response = new ApiResponse<IEnumerable<ProductCategory>>(productCategory, true, "ProductCategory retrieved successfully");
            return Ok(response);
        }



        [HttpGet("categories/{id}")]
        public async Task<ActionResult<ApiResponse<ProductCategory>>> GetProductCategory(int id)
        {
            var products = await _repository.ProductCategory.GetByIdAsync(id);




            var productCategoryDTO = _mapper.Map<ProductCategoryDTO>(products);



            var response = new ApiResponse<ProductCategoryDTO>(productCategoryDTO, true, "ProductCategory retrieved successfully");


            return Ok(response);
        }

        [HttpPost("categories")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductCategory>>>> AddProductCategory([FromBody] ProductCategoryDTO value)
        {



            if (value == null)
            {
                _logger.LogError("ProductCategoryDTO object sent from client is null.");

                return BadRequest("ProductCategoryDTO object is null");
            }
            var proProductCategoryEntity = _mapper.Map<Category>(value);

            var catgory = _repository.Category.AddAsync(proProductCategoryEntity);
            var product = _repository.Product.GetByIdAsync(value.ProductID);

            var productCategoryEntity = new ProductCategory
            {
                ProductID = value.ProductID,
                CategoryID = catgory.Id,
                Products = product.Result,
                Category = proProductCategoryEntity

            };

            //productCategoryEntity.CategoryID= proProductCategoryEntity.CategoryID;
            //productCategoryEntity.Category = proProductCategoryEntity;

            //productCategoryEntity.ProductID = product.Id;
            //productCategoryEntity.Products = product.Result;

            if (catgory != null)

            {
                try
                {
                    await _repository.ProductCategory.AddAsync(productCategoryEntity);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


            }



            var productBrandReturn = _mapper.Map<ProductCategoryDTO>(proProductCategoryEntity);


            var response = new ApiResponse<ProductCategoryDTO>(productBrandReturn, true, "ProductCategory added successfully");


            return Ok(response);

        }


        [HttpPut("categories/{id}")]
        public async Task<ActionResult<ApiResponse<ProductCategory>>> EditProductCategory(int id, [FromBody] ProductCategoryDTO value)
        {

            var products = await _repository.ProductCategory.GetByIdAsync(id);

            var productBrandEntity = _mapper.Map<ProductCategory>(value);


            if (products == null)
            {
                _logger.LogError("ProductCategoryDTO object sent from client is null.");

                return BadRequest("ProductCategoryDTO object is null");

            }


            _repository.ProductCategory.Update(productBrandEntity);


            var productBrandReturn = _mapper.Map<ProductCategoryDTO>(productBrandEntity);


            var response = new ApiResponse<ProductCategoryDTO>(productBrandReturn, true, "ProductCategory Updated successfully");
            return Ok(response);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProductCategory(int id)
        {
            var products = await _repository.ProductCategory.GetByIdAsync(id);

            if (products == null)
            {
                _logger.LogError("ProductCategory object sent from client is null.");

                return BadRequest("ProductCategory object is null");
            }
            _repository.ProductCategory.Delete(products);

            var response = new ApiResponse<bool>(true, true, "ProductCategory deleted successfully");
            return Ok(response);
        }
    }





}

