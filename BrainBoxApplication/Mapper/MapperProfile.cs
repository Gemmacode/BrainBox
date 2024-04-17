using AutoMapper;
using BrainBoxApplication.Data.DTO;
using BrainBoxApplication.Models.Entity;

namespace BrainBoxApplication.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            
            CreateMap<Cart, CartDto>().ReverseMap();
            
        }
    }
}
