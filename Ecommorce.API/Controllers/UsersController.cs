
using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Ecommorce.Model.DTO;
using Ecommorce.Model.Shared;
using Ecommorce.Model.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManger _logger;
        public UsersController(IRepositoryManager repository, ILoggerManger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {

            var user = await _repository.User.GetByIdAsync(1);

            var userrole = await _repository.User.FindByCondition(users => users.Email == user.Email).Include(users => users.UserRoles)
                 .ThenInclude(ur => ur.RoleName).FirstOrDefaultAsync(u => u.Email == user.Email);




            //var userfollower = await _repository.User.FindByCondition(u => u.Id == user.Id).Include(u => u.Followers).ThenInclude(u => u.Following).ToListAsync();

            // var userfollowing = _repository.User.FindByCondition(u => u.Id == user.Id).Include(users => users.Following)
            //                    .ThenInclude(users => users.Following);

            return Ok(userrole);



        }

        [HttpPost("add")]
        //[Authorize]
        public async Task<ActionResult<ApiResponse<User>>> AddUser([FromBody] RegisterDTO user)
        {
            try
            {

                var response = new ApiResponse<User>();
                var result = await _repository.User.GetUserByEmailAsync(user.Email);

                if (result != null)
                {
                    response = new ApiResponse<User>(result, true, "UserEmail and username Ares alrready exist");
                    return BadRequest(response);
                }
                var users = new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    UserOpenId = await _repository.User.GenerateUniqueOpenIdAysnc(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    UserRoles = new List<UserRole>()
                };

                var roleids = await _repository.Role.GetAllAsync();


                List<int> r = [1, 2, 3];


                foreach (var roleid in roleids)
                {
                    users.UserRoles.Add(new UserRole
                    {
                        RoleId = roleid.Id,
                        RoleName = roleid,
                        UserRoles = users

                    });
                }


                await _repository.User.AddAsync(users);
                response = new ApiResponse<User>(users, true, "User added Successfuly ");


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(AddUser)}  action {ex} ");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var response = new ApiResponse<User>();
                var user = await _repository.User.GetByIdAsync(id);

                if (user == null)
                {
                    response = new ApiResponse<User>(user, true, "User not found");
                    return BadRequest(response);
                }


                response = new ApiResponse<User>(user, true, "User not found");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetUsers)}  action {ex} ");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            try
            {
                var response = new ApiResponse<User>();
                if (id != user.Id)
                {

                    response = new ApiResponse<User>(user, true, "User not found");
                    return BadRequest(response);
                }
                var isSuccess = await _repository.User.GetByIdAsync(id);
                if (isSuccess == null)
                {
                    response = new ApiResponse<User>(user, true, "User not found");
                    return BadRequest(response);
                }

                _repository.User.Update(user);
                response = new ApiResponse<User>(user, true, "User Updated seccessfuly");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(PutUser)}  action {ex} ");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                await _repository.User.AddAsync(user);


                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(PostUser)}  action {ex} ");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _repository.User.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                _repository.User.Delete(user);

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(DeleteUser)}  action {ex} ");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
