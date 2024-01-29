using core_applicationservice;
using core_domain.Data;
namespace core_infrastructure.Repository;

public interface IRepository<T> : IApplicationService<T> where T : DatabaseEntity
{
    
}
