﻿using AutoMapper;
using SuperShopping.ProductAPI.DTO;
using SuperShopping.ProductAPI.Models;

namespace SuperShopping.ProductAPI.Infrastructure;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, ProductCreationDTO>().ReverseMap();
        CreateMap<Product, ProductUpdateDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Category, CategoryCreationDTO>().ReverseMap();
        CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
    }
}
