using System.ComponentModel.DataAnnotations;
namespace core_domain.Data.Actors;

public class Operator : DatabaseEntity
{
    [Required] public string UserId { get; set; }
    [Required, StringLength(255)] public string FullName { get; set; }
    public string? ImageUrl { get; set; }
}
