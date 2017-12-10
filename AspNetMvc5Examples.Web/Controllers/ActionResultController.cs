using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    using Base;

    public class ActionResultController : AspNetMvc5ExamplesControllerBase
    {
        public ActionResult EmptyAction()
        {
            return new EmptyResult();
        }

        public ActionResult ContentAction()
        {
            return this.Content("Hello from MVC application. <br /> This is awesome ContentActionResult!");
        }

        public ActionResult HttpNotFoundAction()
        {
            return this.HttpNotFound();
        }

        public ActionResult LineBreaksContentAction()
        {
            return this.LineBreaksContent("Hello from MVC application. This is awesome ContentActionResult!");
        }

        public ActionResult HtmlAction(string title = null, string body = null)
        {
            return this.Html(title, body);
        }

        public ActionResult ViewEngineAction()
        {
            return this.DummyView(new { Title = "ASP.NET MVC 5" });
        }

        public ActionResult CustomViewEngine()
        {
            return this.View();
        }
    }
}