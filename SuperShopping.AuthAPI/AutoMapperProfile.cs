
using AutoMapper;
using SuperShopping.AuthAPI.Models;
using SuperShopping.AuthAPI.Models.DTO;

namespace SuperShopping.AuthAPI;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
