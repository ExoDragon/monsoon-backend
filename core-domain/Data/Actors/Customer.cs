using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core_domain.Data.Entities;
using core_domain.Data.Link;
using core_domain.Enums;
namespace core_domain.Data.Actors;

public class Customer : DatabaseEntity
{
    [Required] public string UserId { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required, StringLength(255), EmailAddress] public string Email { get; set; }
    [StringLength(255), Phone]  public string? PhoneNumber { get; set; }
    public GenderEnum Gender { get; set; }

    //Relations
    public string CompanyId { get; set; }
    [ForeignKey("CompanyId")] public Company Company { get; set; }

    public List<Order> Orders { get; set; }
    public List<CustomerProjects> CustomerProjects { get; set; }
}
