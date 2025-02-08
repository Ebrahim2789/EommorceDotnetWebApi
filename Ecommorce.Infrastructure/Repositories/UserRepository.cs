using Ecommorce.Application.IRepository;
using Ecommorce.Infrastructure.Extension;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Model;
using Ecommorce.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommorce.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

     
        public async Task<User> GetUserByEmailAsync(string email)
        {

            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);

        }

        public async Task<User?> ValidateUser(string UserName, string password)
        {
              await Task.Delay(100); // Simulates a delay, mimicking database latency.
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == UserName && u.Password == password); 

                                   
        }

        
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddAsyncs(User user) => await AddAsync(user);

        public async Task<string> GenerateUniqueOpenIdAysnc()
        {
            string openid;
            do
            {
                openid = new OpenIdGenerator().GenerateOpenId(20);

            }
            while (await _context.Users.AnyAsync(u => u.UserOpenId == openid));
            return openid;
        }
    }

}
