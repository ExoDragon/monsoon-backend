using core_applicationservice.Data.Actor;
using core_domain.Data.Actors;
using core_infrastructure.Context;
namespace core_infrastructure.Repository.Data.Actors;

public class OperatorRepository : GenericRepository<Operator>, IOperatorApplicationService
{
    public OperatorRepository(DatabaseEntityContext dbContext) : base(dbContext) {}
}
