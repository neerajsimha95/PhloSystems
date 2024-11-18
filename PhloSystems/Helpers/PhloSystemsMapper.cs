namespace PhloSystems.Helpers;

using AutoMapper;
using PhloSystems.Domain.Dto;
using PhloSystems.Models;

public class PhloSystemsMapper : Profile
{
    public PhloSystemsMapper()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<ProductDto, Product>().ReverseMap();
    }
}
