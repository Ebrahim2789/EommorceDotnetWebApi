using Ecommorce.Model.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Application.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<(IEnumerable<T> Data, int TotalCount)> GetGridAsync(RequestParameters requestParameters, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetGridIncluding(Expression<Func<T, bool>> pradicte , params Expression<Func<T, bool>>[] includes);

         IQueryable<T>  FindIncluding(List<Expression<Func<T, bool>>> conditions, params Expression<Func<T, object>>[] includes);
        IQueryable<T> FindByConditions(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }

}
