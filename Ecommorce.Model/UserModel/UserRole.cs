using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommorce.Model.UserModel
{
    public class UserRole
    {
        public int Id { get; set; }

        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public required Role RoleName { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public  User UserRoles { get; set; }  
    }
}


