using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Areas.Administration.Controllers
{
    public class UserController : Controller
    {
        // GET: Administration/User
        public ActionResult Index()
        {
            return View();
        }
    }
}