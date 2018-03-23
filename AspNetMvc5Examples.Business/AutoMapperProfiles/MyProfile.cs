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
            this.CreateMap<Movie, MovieViewModel>().ReverseMap();
        }
    }
}
