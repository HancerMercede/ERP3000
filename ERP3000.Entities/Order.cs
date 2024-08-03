using ERP3000.Entities.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP3000.Entities;

public class Order
{ 
    public Guid OrderId { get; set; }
    public Guid? ClientId { get; set; }
    public decimal Tax { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
   
}

