using AspNetMvc5Examples.Entities.DbContexts;
using AspNetMvc5Examples.Entities.Enums;
using AspNetMvc5Examples.Entities.Models;
using AspNetMvc5Examples.Entities.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        private List<Movie> moviesDatabase = new List<Movie>()
        {
            new Movie(){ Id = 1, Title = "Homer" },
            new Movie(){ Id = 2, Title = "Pelisky" }
        };

        private MovieViewModel viewModel = new MovieViewModel
        {
            Id = 1,
            Title = "My Movie",
            Genre = Genre.Comedy,
            ReleasedDate = DateTime.Today,
        };

        private readonly ApplicationDbContext context;
        
        public ActionResult AutoMapperTest()
        {
            var movies = this.context.Movies.Select(x => Mapper.Map<Movie, MovieViewModel>(x));
            return this.Json(movies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return this.View(this.viewModel);
        }

        // GET: Movies
        public ActionResult Released(int year, int month)
        {
            return this.Content($"Year={year} Month={month}");
        }

        public ActionResult Details(int id)
        {
            return this.View(this.context.Movies.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult Create()
        {
            return this.View(new MovieViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                var movie = new Movie()
                {
                    Title = viewModel.Title
                };

                this.context.Set<Movie>().Add(movie);
                this.context.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(viewModel);
        }

        public ActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Delete(string[] array)
        {
            return this.Json(array, JsonRequestBehavior.AllowGet);
            //return this.View("Index");
        }

        [HttpGet]
        [Route("api/movies/{id}")]
        public ActionResult Get(int id)
        {
            return this.Json(this.moviesDatabase.FirstOrDefault(x => x.Id == id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("api/movies")]
        public ActionResult GetAll()
        {
            return this.Json(this.moviesDatabase, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("api/movies/{*ids}")]
        public ActionResult Get(int[] ids)
        {
            return this.Json(this.moviesDatabase.FirstOrDefault(x => ids.Any(y => y == x.Id)), JsonRequestBehavior.AllowGet);
        }

        // Test binding
        //public ActionResult Details(int? id, string name)
        //{
        //    if (id == null)
        //    {
        //        return this.Content($"Name={name}");
        //    }

        //    return this.Content($"Id={id}");
        //}
    }
}