using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.UserModel
{
    public class UserFollower
    {

        public int FollowerId { get; set; }
        //[ForeignKey(nameof(FollowerId))]
        public User Follower { get; set; }

        public int? FollowingId { get; set; }
        //[ForeignKey(nameof(FollowingId))]
        public User? Following { get; set; }

        public DateTime? FollowingDate { get; set; }= DateTime.Now;
    }
}
