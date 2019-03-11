using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AspNetMvc5Examples.Entities.DbContexts;
using AspNetMvc5Examples.Entities.Models;

namespace AspNetMvc5Examples.Web.Controllers
{
    [RoutePrefix("/api/movies")]
    public class MoviesApiController : ApiController
    {
        private readonly ApplicationDbContext context;

        public MoviesApiController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Movies
        public IQueryable<Movie> GetMovies()
        {
            return this.context.Movies;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = this.context.Movies.Find(id);
            if (movie == null)
            {
                return this.NotFound();
            }

            return this.Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != movie.Id)
            {
                return this.BadRequest();
            }

            this.context.Entry(movie).State = EntityState.Modified;

            try
            {
                this.context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.MovieExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MoviesAPI
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.context.Movies.Add(movie);
            this.context.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = this.context.Movies.Find(id);
            if (movie == null)
            {
                return this.NotFound();
            }

            this.context.Movies.Remove(movie);
            this.context.SaveChanges();

            return this.Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return this.context.Movies.Count(e => e.Id == id) > 0;
        }
    }
}