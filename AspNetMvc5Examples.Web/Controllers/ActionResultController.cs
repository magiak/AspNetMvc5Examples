using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class ActionResultController : AspNetMvc5ExamplesControllerBase
    {
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

        public ActionResult Index()
        {
            return View();
        }
    }
}