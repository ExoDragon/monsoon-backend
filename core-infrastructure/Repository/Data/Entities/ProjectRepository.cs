using core_applicationservice.Data.Entities;
using core_domain.Data.Entities;
using core_infrastructure.Context;
namespace core_infrastructure.Repository.Data.Entities;

public class ProjectRepository : GenericRepository<Project>, IProjectApplicationService
{
    public ProjectRepository(DatabaseEntityContext dbContext) : base(dbContext) {}
}
