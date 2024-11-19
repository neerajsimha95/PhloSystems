using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhloSystems.Controllers;
using PhloSystems.Domain.Dto;
using PhloSystems.Domain.RequestDto;
using PhloSystems.Models;
using PhloSystems.Service.Contract;

namespace PhloSystems.Tests;

public class ProductControllerTests
{
    private readonly IProductService _productServiceFake;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        // Arrange: Create a fake product service
        _productServiceFake = A.Fake<IProductService>();
        _controller = new ProductController(_productServiceFake,null);
    }

    [Fact]
    public async Task GetAllProducts_ReturnsOkResult_WithListOfProducts()
    {
        // Arrange: Set up mocked service behavior
        var fakeProducts = new ResponseResultDto
        {
            Products = new List<ProductDto>
            {
                new ProductDto{Title="Test A",Price=10,Description="Test Description",Sizes=new List<string>{"small","large"}}
            },
            ProductFilter=A.Dummy<ProductFiltersDto>(),
        };
        var dataStore = A.Fake<IProductService>();
        var productInput = new GetProductsInputModel();
        A.CallTo(() => _productServiceFake.GetProductsAsync(productInput)).Returns(Task.FromResult(fakeProducts));

        // Act: Call the action
        var actionResult= await _controller.GetProducts(productInput);

        // Assert: Check the result
        var okResult=Assert.IsType<OkObjectResult>(actionResult);
        var returnedProducts = Assert.IsType<ResponseResultDto>(okResult.Value);
        Assert.Equal(1, returnedProducts?.Products?.Count); // Check the product count
    }
}