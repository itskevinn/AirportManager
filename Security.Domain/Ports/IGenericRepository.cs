using System.Linq.Expressions;

namespace Security.Domain.Ports;

public interface IGenericRepository<TEntity>
{
    Task<TEntity> CreateAsync(TEntity entity);
    void Update(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(object? id);

    void Delete(TEntity entity);
    Task<TEntity?> FindAsync(object? id);
    Task<bool> ExistsAsync(object id);
    Task CreateAllAsync(IEnumerable<TEntity> entities);
    TEntity? FindBy(Expression<Func<TEntity, bool>>? filter = null,
        bool isTracking = false,
        string includeStringProperties = "");
    Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>>? filter = null,
        bool isTracking = false,
        string includeStringProperties = "");

    Task<IQueryable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool isTracking = false,
        string includeStringProperties = "");
}