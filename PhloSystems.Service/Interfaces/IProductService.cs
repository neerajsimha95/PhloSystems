using PhloSystems.Domain.Dto;
namespace PhloSystems.Service.Contract;

using PhloSystems.Domain.RequestDto;

public interface IProductService
{
    Task<List<ProductDto>> GetProductsAsync(GetProductsInputModel input);
}
