using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;

        public ProductBrandsController(IRepositoryManager repository, ILoggerManger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("brands")]
        public IEnumerable<string> ProductBrandAll()
        {
            return new string[] { "value1", "value2" };
        }
 
        [HttpGet("customer")]
        public IEnumerable<string> CoustomerGetProductList( string openid)
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("merchant")]
        public IEnumerable<string> MerchantGetProductList(string openid)
        {
            return new string[] { "value1", "value2" };
        }
        


        [HttpGet("brands/{id}")]
        public string GetProductBrand(int id)
        {
            return "value";
        }

        [HttpPost("brands")]
        public void AddProductBrand([FromBody] ProductBrandDTO value)
        {

  



        }


        [HttpPut("brands/{id}")] 
        public void EditProductBrand(int id, [FromBody] ProductBrandDTO value)
        {
        }

 
        [HttpDelete("{id}")]
        public void DeleteProductBrand(int id)
        {

        }
    }


    public class ProductBrandDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
         public string Description { get; set; }
            public bool IsPublished { get; set; }
    }
}
