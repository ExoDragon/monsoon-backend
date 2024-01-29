using core_applicationservice.Data.Entities;
using core_domain.Data.Entities;
using core_infrastructure.Context;
namespace core_infrastructure.Repository.Data.Entities;

public class CompanyRepository : GenericRepository<Company>, ICompanyApplicationService
{
    public CompanyRepository(DatabaseEntityContext dbContext) : base(dbContext) {}
}
