using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommorce.Model;
using Ecommorce.Model.UserModel;
using Ecommorce.Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.AspNetCore.Authorization;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Application.Repository;
using NuGet.Protocol.Core.Types;
using Ecommorce.Application.IRepository;
using Ecommorce.Model.DTO;
using Ecommorce.Model.Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Azure;
using Ecommorce.Application.ILogger;

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
            try
            {

                var user = await _repository.Role.GetByIdAsync(2);

                var userrole = _repository.User.FindByCondition(u => u.Id == user.Id).Include(u => u.UserRoles).ThenInclude(u => u.RoleUserName);

                var userfollower = await _repository.User.FindByCondition(u => u.Id == user.Id).Include(u => u.Followers).ThenInclude(u => u.Following).ToListAsync();

                // var userfollowing = _repository.User.FindByCondition(u => u.Id == user.Id).Include(users => users.Following)
                //                    .ThenInclude(users => users.Following);

                return Ok(userfollower);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetUsers)}  action {ex} ");
                return StatusCode(500, "Internal server error");
            }


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
                    response = new ApiResponse<User>(result, true, "UserEmail and username ares alrready exist");
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

                var role = _repository.Role.GetByIdAsync(2);


                UserRole userRole = new UserRole();


                userRole.RoleId = role.Id;
                userRole.UserId = users.Id;
                userRole.UserRoleName = users;

                users.UserRoles.Add(userRole);



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
        [Authorize]
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
