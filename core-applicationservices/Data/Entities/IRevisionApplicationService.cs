using core_domain.Data.Entities;
using core_domainservices.Data.Entities;
namespace core_applicationservice.Data.Entities;

public interface IRevisionApplicationService : IApplicationService<Revision>, IRevisionDomainService
{
    
}
