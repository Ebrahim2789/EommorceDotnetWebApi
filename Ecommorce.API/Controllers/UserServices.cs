using Ecommorce.Application.Repository;
using Ecommorce.Model;
using Ecommorce.Model.Model;
using Ecommorce.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommorce.API.Controllers
{

// Use the Authenticated HTTP Client

// Inject the HttpClient with the AuthenticatedHttpClientHandler into your services or controllers.
public class MyService
{
    private readonly HttpClient _httpClient;

    public MyService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("AuthenticatedClient");
    }

    public async Task<string> GetProtectedDataAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5179/api/Cars");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}





    public class UserServices
    {
        private readonly IRepositoryManager _repository;
        public UserServices(IRepositoryManager repository)
        {
            _repository = repository;
        }


        public async Task AddUserWithFollowerAndRole(User user, int followerids, int roleids)
        {

            var role1 = _repository.Role.GetByIdAsync(roleids);
            var user2 =await _repository.User.GetByIdAsync(followerids);
            if (user == null||role1==null )
            {
                throw new ArgumentNullException("user");
            }
            var users = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                UserRoles = new List<UserRole>()
            };


            var userFollowers = new UserFollower();

        
            
            userFollowers.FollowingId = users.Id;
            userFollowers.FollowerId = user2.Id;

            userFollowers.Following = user;
            userFollowers.Follower = user2;

            UserRole userRole = new UserRole();

            userRole.RoleId = role1.Id;
            userRole.UserId = user.Id;
            userRole.UserRoleName = users;

            users.UserRoles.Add(userRole);
            users.Followers.Add(userFollowers);
           
            _repository.User.AddAsync(user);

        }


    }
}
