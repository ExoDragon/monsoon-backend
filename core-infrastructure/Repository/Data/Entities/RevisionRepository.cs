using core_applicationservice.Data.Entities;
using core_domain.Data.Entities;
using core_infrastructure.Context;
namespace core_infrastructure.Repository.Data.Entities;

public class RevisionRepository : GenericRepository<Revision>, IRevisionApplicationService
{
    public RevisionRepository(DatabaseEntityContext dbContext) : base(dbContext) {}
}
