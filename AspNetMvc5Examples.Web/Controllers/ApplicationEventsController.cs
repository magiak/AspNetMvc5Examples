using System.Web.Mvc;
using AspNetMvc5Examples.Web.HttpHandlers;
using AspNetMvc5Examples.Web.HttpModules;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class ApplicationEventsController : Controller
    {
        // GET: ApplicationEvents
        public ActionResult Index()
        {
            var modules = this.HttpContext.ApplicationInstance.Modules.AllKeys; // 6

            var handlerType = typeof(WebConfigHttpHandler);
            var handlerAssemblyQualifiedName = typeof(WebConfigHttpHandler).AssemblyQualifiedName;

            var moduleType = typeof(PreApplicationStartHttpModule);
            var moduleAssemblyQualifiedName = typeof(PreApplicationStartHttpModule).AssemblyQualifiedName;

            return View();
        }
    }
}