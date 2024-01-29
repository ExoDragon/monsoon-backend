using System.Linq.Expressions;
using core_domain.Data;
using core_infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace core_infrastructure.Repository;

public abstract class GenericRepository<T> : Repository<T> where T : DatabaseEntity
{
    protected GenericRepository(DatabaseEntityContext dbContext) : base(dbContext)
    {
    }

    override public async Task<IEnumerable<T>> GetAll() => await DbContext.Set<T>().ToListAsync();
    override public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] expressions)
    {
        IQueryable<T> query = DbContext.Set<T>();
        query = expressions.Aggregate(query, (current, expression) => current.Include(expression));
        return await query.ToListAsync();
    }

    override public async Task<T?> GetById(string id) => await DbContext.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
    override public async Task<T?> GetById(string id, params Expression<Func<T, object>>[] expressions)
    {
        IQueryable<T?> query = DbContext.Set<T>();
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
        query = expressions.Aggregate(query, (current, expression) => current.Include(expression!));
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
        return await query.FirstOrDefaultAsync(t => t!.Id == id);
    }

    override public async Task<T> Create(T entity)
    {
        EntityEntry<T> newEntity = await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return newEntity.Entity;
    }
    
    override public async Task<T> Update(T entity)
    {
        EntityEntry entityEntry = DbContext.Update(entity);
        await DbContext.SaveChangesAsync();
        return (T) entityEntry.Entity;
    }
    
    override public async Task<bool> Delete(T entity)
    {
        T? foundEntity = await DbContext.Set<T>().FirstOrDefaultAsync(t => t.Id == entity.Id);
        if (foundEntity == null) return false;
        
        EntityEntry entityEntry = DbContext.Entry(entity);
        entityEntry.State = EntityState.Deleted;
            
        await DbContext.SaveChangesAsync();
        return true;
    }

    override public async Task<bool> Delete(string id)
    {
        T? entity = await DbContext.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
        if (entity == null) return false;
        
        EntityEntry entityEntry = DbContext.Entry(entity);
        entityEntry.State = EntityState.Deleted;
            
        await DbContext.SaveChangesAsync();
        return true;
    }
}
