﻿namespace PhloSystems.Models;
public class Product
{
    public string? Title { get; set; }
    public int Price { get; set; }
    public List<string>? Sizes { get; set; }
    public string? Description { get; set; }
}
public class Response
{
    public List<Product>? Products { get; set; }
    public ApiKeys? ApiKeys { get; set; }
}
public class ApiKeys
{
    public string? Primary { get; set; }
    public string? Secondary { get; set; }
}

