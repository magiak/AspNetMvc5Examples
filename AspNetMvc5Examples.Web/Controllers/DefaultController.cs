namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;

    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}