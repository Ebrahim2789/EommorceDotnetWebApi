using Ecommorce.API.Extentions.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace Ecommorce.API.Controllers
{
    [ServiceFilter(typeof(GlobalFilterExample))]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [ServiceFilter(typeof(GlobalFilterExample))]
        public IEnumerable<string> Get()
        {
            return new string[] { "example", "data" };
        }

    }
}
