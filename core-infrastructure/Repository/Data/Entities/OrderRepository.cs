using core_applicationservice.Data.Entities;
using core_domain.Data.Entities;
using core_infrastructure.Context;
namespace core_infrastructure.Repository.Data.Entities;

public class OrderRepository : GenericRepository<Order>, IOrderApplicationService
{
    public OrderRepository(DatabaseEntityContext dbContext) : base(dbContext) {}
}
