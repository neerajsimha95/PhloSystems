namespace PhloSystems.Domain.Dto;

public class ProductFiltersDto
{
    public int MinimumPrice { get; set; }
    public int MaximumPrice { get; set; }
    public List<string>? Sizes { get; set; }
    private string[] commonWords = new string[10];
    public string[] CommonWords
    {
        get { return commonWords; }
        set { commonWords = value; }
    }
}
