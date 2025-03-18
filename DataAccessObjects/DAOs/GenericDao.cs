using BusinessObjects.Commons;
using DataAccessObjects.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.DAOs
{
    public class GenericDAO<T> : IGenericDAO<T> where T : class
    {
        private readonly FindingHealthcareSystemContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericDAO(FindingHealthcareSystemContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<PaginatedList<T>> GetPagedListAsync(
            Expression<Func<T, bool>> filter,
            int pageIndex,
            int pageSize,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await PaginatedList<T>.CreateAsync(query, pageIndex, pageSize);
        }

        public IQueryable<T> GetFilteredQuery(Dictionary<string, object?> filters, List<string>? includes = null)
        {
            IQueryable<T> query = _dbSet;

            // Apply Includes (Joins) for multiple tables
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            foreach (var filter in filters)
            {
                var parameter = Expression.Parameter(typeof(T), "entity");
                var property = typeof(T).GetProperty(filter.Key);

                if (property != null && filter.Value != null)
                {
                    var propertyExpression = Expression.Property(parameter, property);
                    var filterValue = Expression.Constant(filter.Value.ToString(), typeof(string));

                    if (property.PropertyType == typeof(string))
                    {
                        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var containsExpression = Expression.Call(propertyExpression, containsMethod, filterValue);

                        var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
                        query = query.Where(lambda);
                    }
                    else
                    {
                        var equalityExpression = Expression.Equal(propertyExpression, filterValue);
                        var lambda = Expression.Lambda<Func<T, bool>>(equalityExpression, parameter);
                        query = query.Where(lambda);
                    }
                }
            }

            return query;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
