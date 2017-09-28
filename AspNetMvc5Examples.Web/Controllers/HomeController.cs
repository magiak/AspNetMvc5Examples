using AspNetMvc5Examples.Web.ActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class HomeController : AspNetMvc5ExamplesControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EmptyAction()
        {
            return new EmptyResult();
        }

        public ActionResult ContentAction()
        {
            return Content("Hello from MVC application. <br /> This is awesome ContentActionResult!");
        }

        public ActionResult CustomContentAction()
        {
            return CustomContent("Hello from MVC application. <br /> This is awesome ContentActionResult!");
        }

        public ActionResult HtmlAction(string title = null, string body = null)
        {
            return Html(title, body);
        }

        public ActionResult ViewEngineAction()
        {
            return DummyView(new { Title = "ASP.NET MVC 5" });
        }
    }
}