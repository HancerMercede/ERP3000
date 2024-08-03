using ERP3000.Entities.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP3000.Entities;

public class Product
{
    public string? ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Tax { get; set; }
   
}
