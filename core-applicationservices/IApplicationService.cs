using core_domain.Data;
namespace core_applicationservice;

public interface IApplicationService<T> : IDomainService<T> where T : DatabaseEntity
{
    
}
