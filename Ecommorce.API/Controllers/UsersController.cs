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

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public UsersController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var user = await _repository.Role.GetByIdAsync(2);

            var userrole = _repository.User.FindByCondition(u => u.Id == user.Id).Include(u => u.UserRoles).ThenInclude(u => u.RoleUserName);

            var userfollower = await _repository.User.FindByCondition(u => u.Id == user.Id).Include(u => u.Followers).ThenInclude(u => u.Follower).ToListAsync();

            // var userfollowing = _repository.User.FindByCondition(u => u.Id == user.Id).Include(users => users.Following)
            //                    .ThenInclude(users => users.Following);

            return Ok(userfollower);

        }

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<User>> AddUser([FromBody] AddUserModel user)
        {
           var result=  await _repository.User.FindByCondition(u => u.UserName == user.UserName || u.Email == user.Email).ToListAsync();
           
            if (result!=null)
            {
                return BadRequest("UserEmail and username ares alrready exist");
            }
            var users = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
            };
            await _repository.User.AddAsync(users);

            return Ok(new { message = "users added successfully", usersId = users.Id });
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _repository.User.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }



            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            var isSuccess = await _repository.User.GetByIdAsync(id);
            if (isSuccess == null) return BadRequest("User not found");

            _repository.User.Update(user);

            return Ok("");
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _repository.User.AddAsync(user);


            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repository.User.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _repository.User.Delete(user);

            return NoContent();
        }






    }
    public class AddUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
