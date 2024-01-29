using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace core_domain.Data.Entities;

public class Revision : DatabaseEntity
{
    [Required] public string Version { get; set; }
    
    //Relations
    public string ProjectId { get; set; }
    [ForeignKey("ProjectId")] public Project Project { get; set; }

    public List<Operation>? Operations { get; set; }
    public List<Order>? Orders { get; set; }
}
