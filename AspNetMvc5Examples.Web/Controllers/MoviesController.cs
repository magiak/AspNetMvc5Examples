using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class MoviesController : Controller
    {
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