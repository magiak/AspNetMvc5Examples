namespace AspNetMvc5Examples.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;

    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            var viewModel = new SearchViewModel();
            return this.View(viewModel);
        }

        public PartialViewResult _AjaxPartial(string name)
        {
            string surname = "Unknown";
            if (name == "Lukáš")
            {
                surname = "Kmoch";
            }

            return this.PartialView(model: surname);
        }
    }
}