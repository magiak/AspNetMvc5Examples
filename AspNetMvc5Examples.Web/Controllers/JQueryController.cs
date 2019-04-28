using AspNetMvc5Examples.Business.ActionResults;
using AspNetMvc5Examples.Entities.ViewModels;
using AspNetMvc5Examples.Web.Filters;
using System;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class JQueryController : Controller
    {
        // GET: JQuery
        public ActionResult Index()
        {
            return this.View();
        }

        //[JsonNetFilter]
        public ActionResult Get()
        {
            var data = new MovieViewModel {
                Title = "Pelisky",
                ReleasedDate = new DateTime(1999, 4, 8)
            };

            var behavior = JsonRequestBehavior.AllowGet;

            //return new JsonNetResult { JsonRequestBehavior = behavior, Data = data };

            return this.Json(
                data,
                behavior);
        }

        public ActionResult Post(string title)
        {
            return this.Content(title);
        }
    }
}