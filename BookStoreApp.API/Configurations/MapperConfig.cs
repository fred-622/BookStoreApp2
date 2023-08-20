using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Dtos.Author;

namespace BookStoreApp.API.Configurations
{
    // Vid 18
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorGetDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
        }
    }
}
