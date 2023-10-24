using System.Linq.Expressions;
using Domain.Entities.Base;
using Domain.Repository;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Base
{
    public sealed class GenericRepository<T> : IGenericRepository<T> where T : DomainEntity
    {
        private readonly PersistenceContext _context;

        public GenericRepository(PersistenceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), $"{nameof(context)} is unavailable");
        }

        public T Find(Expression<Func<T, bool>>? filter = null, bool isTracking = false,
            string includeStringProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeStringProperties))
            {
                query = includeStringProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            if (query.ToList().Count == 0) return null!;
            return (!isTracking) ? query.AsNoTracking().First() : query.First();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool isTracking = false,
            string includeStringProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeStringProperties))
            {
                query = includeStringProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync().ConfigureAwait(false);
            }

            return (!isTracking) ? query.AsNoTracking().AsQueryable() : query.AsQueryable();
        }

        public async Task<T?> FindAsync(object? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> ExistsAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id) != null;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity), $"{nameof(entity)} can not be null");
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task CreateAllAsync(IEnumerable<T> entities)
        {
            _ = entities ?? throw new ArgumentNullException(nameof(entities), $"{nameof(entities)} can not be null");
            _context.Set<T>().AddRange(entities);
            await _context.SaveChangesAsync();
        }


        public async Task<T> UpdateAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity), $"{nameof(entity)} can not be null");
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void ClearTracking()
        {
            _context.ChangeTracker.Clear();
        }
    }
}