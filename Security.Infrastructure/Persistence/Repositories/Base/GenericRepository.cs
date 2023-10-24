using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Security.Domain.Entity.Base;
using Security.Domain.Ports;
using Security.Infrastructure.Persistence.Context;

namespace Security.Infrastructure.Persistence.Repositories.Base;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : DomainEntity
{
    private readonly SecurityContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(SecurityContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        try
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity), $"{nameof(entity)} can not be null");
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
     
    }

    public virtual void Update(TEntity entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity), $"{nameof(entity)} can not be null");
        _context.Entry(entity).State = EntityState.Modified;
        _context.ChangeTracker.Clear();
        _dbSet.Update(entity);
        _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity), $"{nameof(entity)} can not be null");
        var entityToDelete = await _dbSet.FindAsync(entity);
        if (entityToDelete != null) Delete(entityToDelete);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(object? id)
    {
        _ = id ?? throw new ArgumentNullException(nameof(id), $"{nameof(id)} can not be null");
        var entityToDelete = await _dbSet.FindAsync(id);
        if (entityToDelete != null) Delete(entityToDelete);
        await _context.SaveChangesAsync();
    }

    public virtual void Delete(TEntity entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity), $"{nameof(entity)} can not be null");
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _dbSet.Remove(entity);
        _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> FindAsync(object? id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> ExistsAsync(object id)
    {
        return await _dbSet.FindAsync(id) != null;
    }

    public virtual async Task CreateAllAsync(IEnumerable<TEntity> entities)
    {
        _ = entities ?? throw new ArgumentNullException(nameof(entities), $"{nameof(entities)} can not be null");
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>>? filter = null,
        bool isTracking = false,
        string includeStringProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = includeStringProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        var result = await query.FirstOrDefaultAsync();
        return result ?? null;
    }

    public virtual TEntity? FindBy(Expression<Func<TEntity, bool>>? filter = null,
        bool isTracking = false,
        string includeStringProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = includeStringProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        var result = query.FirstOrDefault();
        return result ?? null;
    }

    public virtual Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool isTracking = false,
        string includeStringProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(includeStringProperties))
        {
            query = includeStringProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        query = orderBy != null ? orderBy(query) : query;

        return Task.FromResult(isTracking ? query.AsTracking() : query.AsNoTracking());
    }
}