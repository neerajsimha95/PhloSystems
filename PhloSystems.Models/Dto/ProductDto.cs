namespace PhloSystems.Domain.Dto;

public class ProductDto
{
    public string? Title { get; set; }
    public int Price { get; set; }
    public List<string>? Sizes { get; set; }
    public string? Description { get; set; }
}
