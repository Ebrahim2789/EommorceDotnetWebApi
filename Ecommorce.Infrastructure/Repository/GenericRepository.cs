using Ecommorce.Application.Repository;
using Ecommorce.Model;
using Ecommorce.Model.Model;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;


namespace Ecommorce.Infrastructure.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async void Update(T entity)
        {

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            //_dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _context.SaveChanges();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }



        public async Task<(IEnumerable<T> Data, int TotalCount)> GetGridAsync(RequestParameters requestParameters, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
              foreach (var include in includes)
            {
                query = query.Include(include);
            }
            int totalCount = await query.CountAsync();

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            var data = await query.Skip((requestParameters.PageNumber - 1) * requestParameters.PageSize).Take(requestParameters.PageSize).ToListAsync();

            return (data, totalCount);
        }

        public IQueryable<T> FindByConditions(Expression<Func<T, bool>> predicate)
        {


            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;

        }



        public IQueryable<T>  FindIncluding(List<Expression<Func<T, bool>>> conditions, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            // Apply includes
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            // Apply conditions
            foreach (var condition in conditions)
            {
                query = query.Where(condition);
            }

            return query;
        }

        public IQueryable<T> GetGridIncluding(Expression<Func<T, bool>> pradicte, params Expression<Func<T, bool>>[] includes)
        {

            IQueryable<T> query = _dbSet;
            if (pradicte != null)
            {
                query = query.Where(pradicte);
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
