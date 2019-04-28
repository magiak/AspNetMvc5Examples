using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using AspNetMvc5Examples.Entities.DbContexts;
using AspNetMvc5Examples.Entities.Models;

namespace AspNetMvc5Examples.Web.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using AspNetMvc5Examples.Entities.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Movie>("MoviesODataApi");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class MoviesODataApiController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/MoviesODataApi
        [EnableQuery]
        public IQueryable<Movie> GetMoviesODataApi()
        {
            return db.Movies;
        }

        // GET: odata/MoviesODataApi(5)
        [EnableQuery]
        public SingleResult<Movie> GetMovie([FromODataUri] int key)
        {
            return SingleResult.Create(db.Movies.Where(movie => movie.Id == key));
        }

        // PUT: odata/MoviesODataApi(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Movie> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie movie = db.Movies.Find(key);
            if (movie == null)
            {
                return NotFound();
            }

            patch.Put(movie);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(movie);
        }

        // POST: odata/MoviesODataApi
        public IHttpActionResult Post(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            db.SaveChanges();

            return Created(movie);
        }

        // PATCH: odata/MoviesODataApi(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Movie> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie movie = db.Movies.Find(key);
            if (movie == null)
            {
                return NotFound();
            }

            patch.Patch(movie);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(movie);
        }

        // DELETE: odata/MoviesODataApi(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Movie movie = db.Movies.Find(key);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int key)
        {
            return db.Movies.Count(e => e.Id == key) > 0;
        }
    }
}
