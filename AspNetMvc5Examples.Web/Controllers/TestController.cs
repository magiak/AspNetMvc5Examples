using System;

namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}