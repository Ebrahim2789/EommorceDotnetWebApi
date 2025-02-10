namespace Ecommorce.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using global::Ecommorce.Application.ILogger;
    using global::Ecommorce.Application.Repository;

    // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

    namespace Ecommorce.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductCategorysController : ControllerBase
        {
            private readonly IRepositoryManager _repository;
            private readonly ILoggerManger _logger;

            public ProductCategorysController(IRepositoryManager repository, ILoggerManger logger)
            {
                _repository = repository;
                _logger = logger;
            }

            [HttpGet("categories")]
            public IEnumerable<string> ProductCategoryAll()
            {
                return new string[] { "value1", "value2" };
            }


            [HttpGet("categories/{id}")]
            public string GetProductCategory(int id)
            {
                return "value";
            }

            [HttpPost("categories")]
            public void AddProductCategory([FromBody] ProductCategoryDTO value)
            {





            }


            [HttpPut("categories/{id}")]
            public void EditProductCategory(int id, [FromBody] ProductCategoryDTO value)
            {
            }


            [HttpDelete("{id}")]
            public void DeleteProductCategory(int id)
            {

            }
        }





        public class ProductCategoryDTO
        {


            public string Name { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }

            public string Thumbnail { get; set; }
            public string DisplayOrder { get; set; }
            public bool IsPublished { get; set; }
        }

    }

}