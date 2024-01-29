using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core_domain.Data.Actors;
using core_domain.Enums;
namespace core_domain.Data.Entities;

public class Order : DatabaseEntity
{
    [Required] public OrderStatusEnum OrderStatus { get; set; }
    
    //Relations
    public string CustomerId { get; set; }
    [ForeignKey("CustomerId")] public Customer Customer { get; set; }

    public string RevisionId { get; set; }
    [ForeignKey("RevisionId")] public Revision Revision { get; set; }
}