﻿namespace ERP3000.DTOs;

public class ProductUpdateDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Tax { get; set; }


}
