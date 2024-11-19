namespace PhloSystems.Service.Contract;

using PhloSystems.Domain.RequestDto;
using PhloSystems.Domain.Dto;

public interface IProductService
{
    Task<ResponseResultDto> GetProductsAsync(GetProductsInputModel input);
}
