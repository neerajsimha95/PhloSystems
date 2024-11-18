namespace PhloSystems.Service.Concrete;

using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PhloSystems.Domain.Dto;
using PhloSystems.Domain.RequestDto;
using PhloSystems.Models;
using PhloSystems.Service.Contract;
using PhloSystems.Service.Helpers;
using System.Text.Json;

public class ProductService : IProductService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ProductService> _logger;
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _httpClientFactory;
    public ProductService(IMapper mapper, ILogger<ProductService> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _mapper = mapper;
        _logger = logger;
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;

    }
    public async Task<List<ProductDto>> GetProductsAsync(GetProductsInputModel input)
    {
        try
        {
            List<Product> products = new List<Product>();
            var endpoint = _configuration.GetSection("ThirdPartyAPIs")["ProductsEndpoint"];
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentException("Endpoint is required to run this api. Please configure the endpoint.");
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation(jsonResponse.ToString());
                var parsedResponse = JsonSerializer.Deserialize<Response>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                if (parsedResponse != null)
                {
                    products = ApplyFilters(input, parsedResponse.Products);
                }
            }
            return _mapper.Map<List<ProductDto>>(products);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError($"Request failed with exception : {e}");
            throw;
        }
    }
    private List<Product> ApplyFilters(GetProductsInputModel input, List<Product>? products)
    {
        if (!string.IsNullOrEmpty(input.Highlight))
        {
            products = products?.ConvertAll(product =>
                      new Product
                      {
                          Title = product.Title,
                          Price = product.Price,
                          Sizes = product.Sizes,
                          Description = HighlightDescription(product.Description, input.Highlight),
                      });
        }
        return products.WhereIf(input.MinPrice.HasValue, e => e.Price >= input.MinPrice)
            .WhereIf(input.MaxPrice.HasValue, e => e.Price <= input.MaxPrice)
            .WhereIf(!string.IsNullOrEmpty(input.Size), e => e.Sizes.Any(x => input.Size.Split(",").Contains(x))).ToList();
    }
    private string HighlightDescription(string? description, string highlight)
    {
        if (!string.IsNullOrEmpty(highlight) && !string.IsNullOrEmpty(description))
        {
            foreach (var item in highlight.Split(","))
            {
                description = description.Replace(item, $"<em>{item}</em>");
            }
        }
        return description;
    }
}

