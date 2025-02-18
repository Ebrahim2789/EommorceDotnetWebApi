using Ecommorce.Model.Shared;
using Ecommorce.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.NewFolder
{
    public class CoreRoleMenu:Common
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual  Role Role { get; set; }
        public int MenuId { get; set; }

        public virtual  CoreMenu Menu { get; set; }

    }
}
