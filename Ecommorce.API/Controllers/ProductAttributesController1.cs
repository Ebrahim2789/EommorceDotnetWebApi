using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributesController1 : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;

        public ProductAttributesController1(IRepositoryManager repository, ILoggerManger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("attributes")]
        public IEnumerable<string> ProductAttributeAll()
        {
            return new string[] { "value1", "value2" };
        }




        [HttpGet("attributes/{id}")]
        public string GetProductAttribute(int id)
        {
            return "value";
        }

        [HttpPost("attributes")]
        public void AddProductAttribute([FromBody] ProductAttributeDTO value)
        {





        }


        [HttpPut("attributes/{id}")]
        public void EditProductAttribute(int id, [FromBody] ProductAttributeDTO value)
        {
        }


        [HttpDelete("attributes/{id}")]
        public void DeleteProductAttribute(int id)
        {

        }



        public class ProductAttributeDTO
        {

            public string Name { get; set; }
            public string Description { get; set; }
 

        }
    }

}
