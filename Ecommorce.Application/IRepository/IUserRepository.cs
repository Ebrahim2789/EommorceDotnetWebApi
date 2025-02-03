using Ecommorce.Application.Repository;
using Ecommorce.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Application.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User?> ValidateUser(string UserName, string password);
 



    }

}
