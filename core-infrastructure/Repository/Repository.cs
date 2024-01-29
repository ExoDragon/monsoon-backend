using System.Linq.Expressions;
using core_domain.Data;
using core_infrastructure.Context;
namespace core_infrastructure.Repository;

public abstract class Repository<T> : IRepository<T> where T : DatabaseEntity
{
    protected readonly DatabaseEntityContext DbContext;
    
    protected Repository(DatabaseEntityContext dbContext)
    {
        DbContext = dbContext;
    }
    
    public abstract Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] expressions);
    public abstract Task<IEnumerable<T>> GetAll();
    public abstract Task<T?> GetById(string id, params Expression<Func<T, object>>[] expressions);
    public abstract Task<T?> GetById(string id);
    public abstract Task<T> Create(T entity);
    public abstract Task<T> Update(T entity);
    public abstract Task<bool> Delete(T entity);
    public abstract Task<bool> Delete(string id);
}
