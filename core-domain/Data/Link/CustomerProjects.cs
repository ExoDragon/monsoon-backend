using core_domain.Data.Actors;
using core_domain.Data.Entities;
namespace core_domain.Data.Link;

public class CustomerProjects
{
    public string CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public string ProjectId { get; set; }
    public Project? Project { get; set; }
}
