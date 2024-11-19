namespace PhloSystems.Helpers;

using AutoMapper;
using PhloSystems.Domain.Dto;
using PhloSystems.Models;
using System.Text.RegularExpressions;

public class PhloSystemsMapper : Profile
{
    public PhloSystemsMapper()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<ProductFiltersDto, List<ProductDto>>().ReverseMap()
            .ForMember(dest => dest.MinimumPrice, opt => opt.MapFrom(src => src.Min(p => p.Price)))
            .ForMember(dest => dest.MaximumPrice, opt => opt.MapFrom(src => src.Max(p => p.Price)))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.SelectMany(x=>x.Sizes).Distinct().ToList()))
            .ForMember(dest => dest.CommonWords, opt => opt.MapFrom(src => ExtractCommonWords(src))); ;
    }
    private static List<string> ExtractCommonWords(IEnumerable<ProductDto> products)
    {
        var stopWords = new HashSet<string> { "the", "and", "a", "of", "to" };
        var wordFrequency = new Dictionary<string, int>();

        foreach (var product in products)
        {
            if (!string.IsNullOrEmpty(product.Description))
            {
                var words = Regex.Split(product.Description.ToLower(), @"\W+")
                                 .Where(w => w.Length > 0 && !stopWords.Contains(w));

                foreach (var word in words)
                {
                    if (wordFrequency.ContainsKey(word))
                    {
                        wordFrequency[word]++;
                    }
                    else
                    {
                        wordFrequency[word] = 1;
                    }
                }
            }
        }

        return wordFrequency
            .OrderByDescending(kv => kv.Value)
            .Take(10)
            .Select(kv => kv.Key)
            .ToList();
    }
}
