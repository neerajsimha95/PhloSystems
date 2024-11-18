﻿namespace PhloSystems.Domain.RequestDto;

public class GetProductsInputModel
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? Size { get; set; }
    public string? Highlight { get; set; }
}
