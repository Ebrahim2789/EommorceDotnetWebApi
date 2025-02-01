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
        private readonly ApplicationDbContext _context;

        private readonly IConfiguration _configuration;

        private readonly IUserRepository _repository;

        public UsersController(ApplicationDbContext context, IConfiguration configuration, IUserRepository userRepository)
        {
            _context = context;
            _configuration = configuration;
            _repository = userRepository;

        }

        // GET: api/Users
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            //_repository.GetAllAsync();
                

            var user = await _context.Roles.FindAsync(2);
            var userrole = await _context.Users
                          .Include(u => u.UserRoles)
                          .ThenInclude(ur => ur.RoleUserName)
                          .FirstOrDefaultAsync(u => u.Id == user.Id);


            var userfollower = await _context.Users
                               .Include(users => users.Followers)
                               .ThenInclude(users => users.Follower)
                               .FirstOrDefaultAsync(u => u.Id == user.Id);

            var userfollowing = await _context.Users
                               .Include(users => users.Following)
                               .ThenInclude(users => users.Following)
                               .FirstOrDefaultAsync(u => u.Id == user.Id);

            return Ok(userfollower);

        }

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<User>> AddUser([FromBody] AddUserModel user)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == user.UserName || u.Email == user.Email))
            {
                return BadRequest("UserEmail and username ares alrready exist");
            }
            var users = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
            };
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return Ok(new { message = "users added successfully", usersId = users.Id });
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _repository.GetByIdAsync(id);

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

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _repository.AddAsync(user);
           

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _repository.Delete(user);

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }




    }
    public class AddUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
