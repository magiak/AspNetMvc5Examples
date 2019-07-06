using System;

namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AspNetMvc5Examples.Entities.DbContexts;
    using AspNetMvc5Examples.Entities.Models;
    using AspNetMvc5Examples.Entities.ViewModels;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class AutoMapperController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoMapperController(
            ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var viewModel = new MovieViewModel()
            {
                Id = 5,
                Title = "Pelisky"
            };

            var model = this.mapper.Map<Movie>(viewModel);
            return this.Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult IndexStatic()
        {
            var viewModel = new MovieViewModel()
            {
                Id = 5,
                Title = "Pelisky"
            };

            var model = Mapper.Map<Movie>(viewModel);
            return this.Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProjectToTest()
        {
            var movies = this.context.Movies
                .ProjectTo<MovieViewModel>();

            return this.Json(movies, JsonRequestBehavior.AllowGet);
        }
    }
}