using core_domain.Data;
using core_domain.Data.Actors;
using core_domain.Data.Entities;
namespace core_domainservices.Data.Actors;

public interface ICustomerDomainService : IDomainService<Customer>
{
    public Task<Customer?> GetOneByEmail(string email);
}
