using Ecommorce.Model;
using Ecommorce.Model.Model;
using Ecommorce.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommorce.API.Controllers
{
    public class UserServices
    {
        private readonly ApplicationDbContext _contex;
        

        public UserServices(ApplicationDbContext context)
        {
            _contex = context;
        }

        public async Task AddUserWithFollowerAndRole(User user, int followerids, int roleids)
        {

            var role1 = _contex.Roles.Find(roleids);
            var user2 = _contex.Users.Find(followerids);
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

            //{ 

            //FollowerId=1,
            //FollowingId=users.Id

            //};
            userFollowers.Follower = user2;
            userFollowers.FollowingId = users.Id;
            userFollowers.FollowerId = user2.Id;
            userFollowers.Following = user;

            UserRole userRole = new UserRole();

            userRole.RoleUserName = role1;
            userRole.RoleId = role1.Id;
            userRole.UserId = user.Id;
            userRole.UserRoleName = users;

            users.UserRoles.Add(userRole);
            users.Followers.Add(userFollowers);
           
 
            _contex.Users.Add(users);

            await _contex.SaveChangesAsync();

        }


        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {



            return await _contex.Users.
                Include(users => users.UserRoles)
                .ThenInclude(ur=>ur.RoleUserName)
                .Include(users => users.Followers)
                .ToListAsync();
        }
    }
}
