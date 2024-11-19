namespace PhloSystems.Controllers;

using Microsoft.AspNetCore.Mvc;
using PhloSystems.Domain.RequestDto;
using PhloSystems.Domain.ResponseDto;
using PhloSystems.Helpers;
using PhloSystems.Models;
using PhloSystems.Service.Contract;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorResponse), 400)]
[ProducesResponseType(typeof(ErrorResponse), 404)]
[ProducesResponseType(typeof(ErrorResponse), 500)]
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
    /// <summary>
    /// Gets the list of products on the basis of passed filters.
    /// </summary>
    /// <param name="MinPrice">The product MinPrice.</param>
    /// <param name="MaxPrice">The product MaxPrice.</param>
    /// <param name="Size">The product Size.</param>
    /// <param name="Highlight">The product description Highlight.</param>
    /// <returns>The product list or an error code.</returns>
    [HttpGet("GetProducts")]
    [ProducesResponseType(typeof(Product), 200)] // Success
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsInputModel input)
    {
        try
        {
            var response = await _productService.GetProductsAsync(input);
            if (response == null)
            {
                return NotFound(new ErrorResponse
                {
                    ErrorCode = "404",
                    ErrorMessage = $"No Products Found"
                });
            }
            return Ok(response);
        }
        catch
        {
            return BadRequest(new ErrorResponse
            {
                ErrorCode = "500",
                ErrorMessage = $"An error occurred while retrieving the products."
            });
        }
    }
}
