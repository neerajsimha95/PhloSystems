namespace PhloSystems.Controllers;

using Microsoft.AspNetCore.Mvc;
using PhloSystems.Domain.RequestDto;
using PhloSystems.Helpers;
using PhloSystems.Service.Contract;

[Route("api/[controller]")]
[ApiController]
[ApiKey]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;
    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;
    }
    //It will be used for getting the products
    [HttpGet("GetProducts")]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsInputModel input)
    {
        return Ok(await _productService.GetProductsAsync(input));
    }
}
