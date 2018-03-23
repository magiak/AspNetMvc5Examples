using AspNetMvc5Examples.Entities.Models;
using AspNetMvc5Examples.Entities.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> DatabaseMovies { get; set; } = new List<Movie>();
        public MoviesController()
        {
            this.DatabaseMovies.AddRange(new[]
            {
                new Movie(){ Id = 1, Title = "Homer" },
                new Movie(){ Id = 1, Title = "Pelisky" }
            });
        }

        public ActionResult AutoMapperTest()
        {
            var movies = this.DatabaseMovies.Select(x => Mapper.Map<Movie, MovieViewModel>(x));
            return this.Json(movies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var movies = new { };
            return this.Json(movies);
        }

        // GET: Movies
        public ActionResult Released(int year, int month)
        {
            return this.Content($"Year={year} Month={month}");
        }

        public ActionResult Details(int? id, string name)
        {
            if (id == null)
            {
                return this.Content($"Name={name}");
            }

            return this.Content($"Id={id}");
        }
    }
}