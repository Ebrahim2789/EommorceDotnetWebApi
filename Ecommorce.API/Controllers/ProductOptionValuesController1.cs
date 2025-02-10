using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionValuesController1 : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManger _logger;

        public ProductOptionValuesController1(IRepositoryManager repository, ILoggerManger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("optionvalues/{id}/option")]
        public IEnumerable<string> GetProductOptionValueByOptionId()
        {
            return new string[] { "value1", "value2" };
        }

 
        [HttpGet("{id}")]
        public string GetProductOptionValue(int id)
        {
            return "value";
        }

 
        [HttpPost]
        public void AddProductOptionValue([FromBody] ProductOptionValueDTO value)
        {
        }

  
        [HttpPut("optionvalues/{id} ")]
        public void EditProductOptionValue(int id, [FromBody] ProductOptionValueDTO value)
        {
        }


        [HttpDelete("optionvalues/{id} ")]
        public void DeleteProductOptionValue(int id)
        {
        }
    }

    public class ProductOptionValueDTO
    {
        public int OptionId { get; set; }

        public string Value { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
        public bool IsDisplay { get; set; }
    }
}
