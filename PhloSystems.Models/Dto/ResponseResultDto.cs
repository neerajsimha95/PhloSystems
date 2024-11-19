namespace PhloSystems.Domain.Dto;

public class ResponseResultDto
{
    public List<ProductDto>? Products { get; set; }
    public ProductFiltersDto? ProductFilter { get; set; }
}
