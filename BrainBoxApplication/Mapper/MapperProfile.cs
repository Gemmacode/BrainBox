using AutoMapper;
using BrainBoxApplication.Data.DTO;
using BrainBoxApplication.Entity;

namespace BrainBoxApplication.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
