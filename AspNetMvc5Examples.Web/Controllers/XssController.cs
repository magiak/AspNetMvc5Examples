using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    using Models;

    public class XssController : Controller
    {
        // GET: Xss
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var viewModel = new XssViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(XssViewModel viewModel)
        {
            return this.View(viewModel);
        }
    }
}