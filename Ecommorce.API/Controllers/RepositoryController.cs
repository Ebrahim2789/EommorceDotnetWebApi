
using Ecommorce.Application.Repository;
using Ecommorce.Model.Shared;
using Ecommorce.Model.UserModel;
using Microsoft.AspNetCore.Mvc;

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public RepositoryController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<User>>>> GetUsers()
        {
            var user = await _repository.User.GetAllAsync();

            var response = new ApiResponse<IEnumerable<User>>(user, true, "user retrieved successfully");

            return Ok(response);
        }

    }


}
