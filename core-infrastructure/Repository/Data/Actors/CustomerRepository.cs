using core_applicationservice.Data.Actor;
using core_domain.Data.Actors;
using core_infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace core_infrastructure.Repository.Data.Actors;

public class CustomerRepository : GenericRepository<Customer>, ICustomerApplicationService
{
    public CustomerRepository(DatabaseEntityContext dbContext) : base(dbContext) {}

    public async Task<Customer?> GetOneByEmail(string email) => await DbContext.Set<Customer>().FirstOrDefaultAsync(t => t.Email == email);
}
