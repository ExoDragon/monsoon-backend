using System.ComponentModel.DataAnnotations.Schema;
namespace core_domain.Data.Entities;

public class Operation : DatabaseEntity
{
    
    //Relations
    public string RevisionId { get; set; }
    [ForeignKey("RevisionId")] public Revision Revision { get; set; }
}
