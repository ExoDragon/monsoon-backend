using System.ComponentModel.DataAnnotations;
using core_domain.Data.Link;
namespace core_domain.Data.Entities;

public class Project : DatabaseEntity
{
    [Required, StringLength(255)] public string Name { get; set; }
    
    //Relations
    public List<Revision> Revisions { get; set; }
    public List<CustomerProjects> CustomerProjects { get; set; }
}
