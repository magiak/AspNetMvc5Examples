using AspNetMvc5Examples.Entities.DbContexts;
using AspNetMvc5Examples.Entities.Enums;
using AspNetMvc5Examples.Entities.Models;
using AspNetMvc5Examples.Entities.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        private List<MovieViewModel> movies = new List<MovieViewModel>()
        {
            new MovieViewModel{ Id = 1, Title = "Homer", ReleasedDate = new DateTime(2017, 1, 1), },
            new MovieViewModel{ Id = 2, Title = "Pelisky", ReleasedDate = new DateTime(2017, 2, 1) },
            new MovieViewModel{ Id = 3, Title = "Pelisky", ReleasedDate = new DateTime(2017, 2, 1) },
            new MovieViewModel{ Id = 4, Title = "Pelisky 2", ReleasedDate = new DateTime(2018, 1, 1) }
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
            var movies = this.context.Movies;
             //.ProjectTo<MovieViewModel>();
            return this.Json(movies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return this.View(this.movies);
        }

        // GET: Movies
        // [Route("movies/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        public ActionResult Released(int year, int month)
        {
            var count = this.movies
                .Where(m => m.ReleasedDate.Year == year)
                .Where(m => m.ReleasedDate.Month == month)
                .Count();

            return this.Content($"Year={year} Month={month} => count {count}");
        }

        [OutputCache(Duration = 10)]

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
                //var movie = new Movie()
                //{
                //    Title = viewModel.Title
                //};

                var movie = Mapper.Map<Movie>(viewModel);

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
        public ActionResult DeleteOne(int id)
        {
            var entity = this.context.Movies
                .SingleOrDefault(x => x.Id == id);

            // OR
            // var entity = new Movie { Id = id };

            this.context.Movies.Remove(entity);
            this.context.SaveChanges();

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string[] array)
        {
            var entities = this.context.Movies
                .Where(x => array.Contains(x.Title));
            
            this.context.Movies.RemoveRange(entities);
            this.context.SaveChanges();

            return this.Json(array, JsonRequestBehavior.AllowGet);
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


        public ActionResult Edit(int id)
        {
            return this.Content(id.ToString());
        }
    }
}