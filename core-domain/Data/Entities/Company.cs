using System.ComponentModel.DataAnnotations;
using core_domain.Data.Actors;
namespace core_domain.Data.Entities;

public class Company : DatabaseEntity
{
    [Required, StringLength(255)] public string Name { get; set; }
    [Required, StringLength(255)] public string Street { get; set; }
    [Required, StringLength(255)] public string HouseNumber { get; set; }
    [Required, StringLength(255)] public string PostalCode { get; set; }
    [Required, StringLength(255)] public string City { get; set; }

    //Relations
    public List<Customer>? Customers { get; set; }
}
