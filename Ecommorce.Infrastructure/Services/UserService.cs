using Ecommorce.Application.Repository;
using Ecommorce.Model.UserModel;

namespace Ecommorce.Infrastructure.Services
{
    public class UserService
    {
        private readonly IGenericRepository<User> _userRepository;
        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }



    }

}
