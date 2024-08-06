﻿namespace ERP3000.DTOs;

public class ProductDto
{
    public string? ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Tax { get; set; }
}
