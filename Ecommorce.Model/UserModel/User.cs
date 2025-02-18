using Ecommorce.Model.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommorce.Model.UserModel
{
    [Index(nameof(Email), Name = "IX_Unique_Email", IsUnique = true)]
    public class User : Common
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }
        public required string UserOpenId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime LastLoginOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = false;
        public bool IsDelete { get; set; } = false;
        //[InverseProperty(nameof(UserFollower.FollowerId))]
        public ICollection<UserFollower>? Followers { get; set; } = new List<UserFollower>();

        //[InverseProperty(nameof(UserFollower.FollowingId))]
        public ICollection<UserFollower>? Following { get; set; } = new List<UserFollower>();

        [InverseProperty(nameof(UserRole.UserRoles))]
      
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
