using AspNetMvc5Examples.Entities.Models;
using AspNetMvc5Examples.Entities.ViewModels;
using AutoMapper;

namespace AspNetMvc5Examples.Business.AutoMapperProfiles
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            // Movies
            this.CreateMap<Movie, MovieViewModel>()
                .ReverseMap();

            // https://automapper.readthedocs.io/en/latest/Getting-started.html
            // .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour)) 
            // .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value * 100))
            // .ValueTransformers.Add<string>(val => val + "!!!");
        }
    }
}
