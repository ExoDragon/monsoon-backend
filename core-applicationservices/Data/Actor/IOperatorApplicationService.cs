using core_domain.Data.Actors;
using core_domainservices.Data.Actors;
namespace core_applicationservice.Data.Actor;

public interface IOperatorApplicationService : IApplicationService<Operator>, IOperatorDomainService
{
    
}
