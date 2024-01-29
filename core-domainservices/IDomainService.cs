using System.Linq.Expressions;
namespace core_domain.Data;

public interface IDomainService<T> where T : DatabaseEntity
{
    public Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] expressions);
    public Task<IEnumerable<T>> GetAll();
    public Task<T?> GetById(string id, params Expression<Func<T, object>>[] expressions);
    public Task<T?> GetById(string id);
    public Task<T> Create(T entity);
    public Task<T> Update(T entity);
    public Task<bool> Delete(T entity);
    public Task<bool> Delete(string id);
}
