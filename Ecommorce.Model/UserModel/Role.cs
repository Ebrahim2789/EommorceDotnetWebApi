using Ecommorce.Model.NewFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.UserModel
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [InverseProperty(nameof(UserRole.RoleUserName))]
        public IEnumerable<UserRole>? UsersRoles { get; set; }= new List<UserRole>();

        public virtual ICollection<CoreRoleMenu> RoleMenus { get; set; }
    }
}
