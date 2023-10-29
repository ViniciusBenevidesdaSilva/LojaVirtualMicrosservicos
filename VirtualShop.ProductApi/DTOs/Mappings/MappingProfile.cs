using AutoMapper;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.DTOs.Mappings;

/// <summary>
/// Mapeamento que relaciona as entidades com seus respectivos DTOs
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();

        CreateMap<ProductDTO, Product>();

        CreateMap<Product, ProductDTO>()
            .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

    }
}
