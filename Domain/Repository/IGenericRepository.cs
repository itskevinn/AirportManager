using System.Linq.Expressions;
using Domain.Entities.Base;

namespace Domain.Repository
{
    public interface IGenericRepository<T> where T : DomainEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> FindAsync(object? id);
        Task<bool> ExistsAsync(object id);
        Task CreateAllAsync(IEnumerable<T> entities);

        T Find(
            Expression<Func<T, bool>>? filter = null,
            bool isTracking = false,
            string includeStringProperties = "");

        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool isTracking = false,
            string includeStringProperties = "");

        void ClearTracking();
    }
}