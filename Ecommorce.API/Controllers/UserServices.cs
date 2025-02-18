using Ecommorce.Application.Repository;
using Ecommorce.Model;
using Ecommorce.Model.Model;
using Ecommorce.Model.UserModel;
using Microsoft.AspNetCore.Mvc;


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

            var role1 = await _repository.Role.GetAllAsync();
            var user2 = await _repository.User.GetByIdAsync(followerids);
            if (user == null || role1 == null)
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
                UserRoles = new List<UserRole>(),
                UserOpenId = await _repository.User.GenerateUniqueOpenIdAysnc(),
            };


            var userFollowers = new UserFollower();

            userFollowers.FollowingId = users.Id;
            userFollowers.FollowerId = user2.Id;

            userFollowers.Following = user;
            userFollowers.Follower = user2;

            foreach (var roleid in role1)
            {
                users.UserRoles.Add(new UserRole
                {
                    RoleId = roleid.Id,
                    RoleName = roleid,
                    UserRoles = users

                });
            }


            users.Followers.Add(userFollowers);

            await _repository.User.AddAsync(user);

        }


    }
}
