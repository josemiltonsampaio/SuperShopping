using AutoMapper;
using SuperShopping.CartAPI.DTO;
using SuperShopping.CartAPI.Models;

namespace SuperShopping.CartAPI.Infrasctructure;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, ProductCreationDTO>().ReverseMap();
        CreateMap<CartHeader, CartDTO>().ReverseMap();
        CreateMap<CartHeader, CartCreationDTO>().ReverseMap();
        CreateMap<CartItem, CartItemDTO>().ReverseMap();
        CreateMap<CartItem, CartItemCreationDTO>().ReverseMap();
    }
}
