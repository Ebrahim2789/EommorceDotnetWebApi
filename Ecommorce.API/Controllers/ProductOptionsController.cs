using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ecommorce.API.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class ProductOptionsController : ControllerBase
        {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;

        public ProductOptionsController(IRepositoryManager repository, ILoggerManger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("Option")]
            public IEnumerable<string> ProductOptionAll()
            {
                return new string[] { "value1", "value2" };
            }

          


            [HttpGet("Option/{id}")]
            public string GetProductOption(int id)
            {
                return "value";
            }

            [HttpPost("Option")]
            public void AddProductOption([FromBody] ProductOptionDTO value)
            {





            }


            [HttpPut("Option/{id}")]
            public void EditProductOption(int id, [FromBody] ProductOptionDTO value)
            {
            }


            [HttpDelete("{id}")]
            public void DeleteProductOption(int id)
            {

            }
        


        public class ProductOptionDTO
        {
       
            public string Name { get; set; }
            public string Description { get; set; }
            public int DisplayType { get; set; }

        }
    }

}
