using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Ecommorce.Model.ProductModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeValuesController1 : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;

        public ProductAttributeValuesController1(IRepositoryManager repository, ILoggerManger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("attributevalues/{id}/option")]
        public IEnumerable<string> GetProductAttributeValueByAttributeId()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{id}")]
        public string GetProductAttributeValue(int id)
        {
            return "value";
        }


        [HttpPost]
        public void AddProductAttributeValue([FromBody] ProductAttributeValuesDTO value)
        {
        }


        [HttpPut("attributevalues/{id} ")]
        public void EditProductAttributeValue(int id, [FromBody] ProductAttributeValuesDTO value)
        {
        }

     
        [HttpDelete("attributevalues/{id} ")]
        public void DeleteProductAttributeValue(int id)
        {
        }
    }

    public class ProductAttributeValuesDTO
    {


        public int AttributeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
    }

}
