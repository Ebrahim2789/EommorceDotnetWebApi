using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.UserModel
{
    [Index(nameof(Email), Name = "IX_Unique_Email", IsUnique = true)]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        //[InverseProperty(nameof(UserFollower.FollowerId))]
        public ICollection<UserFollower>? Followers { get; set; } = new List<UserFollower>();

        //[InverseProperty(nameof(UserFollower.FollowingId))]
        public ICollection<UserFollower>? Following { get; set; } = new List<UserFollower>();

        [InverseProperty(nameof(UserRole.UserRoleName))]
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
