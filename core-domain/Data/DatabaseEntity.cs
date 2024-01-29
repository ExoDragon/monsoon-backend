using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace core_domain.Data;

public class DatabaseEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    [Required] public DateTime DateCreated { get; set; }
    [Required] public DateTime DateUpdated { get; set; }
    [Required] public DateTime DateDeleted { get; set; }

    [Required] public bool Deleted { get; set; }
}