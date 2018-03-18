namespace AspNetMvc5Examples.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Web.Mvc;
    using AspNetMvc5Examples.Business.Filters;

    public class FilterController : Controller
    {
        [AuthorizationFilter]
        [ActionFilter]
        [ResultFilter]
        // [CustomActionFilter] // ActionFilterAttribute = easy way to implement ActionFilter and ResultFilter
        [ExceptionFilter]
        public ActionResult Index()
        {
            Debugger.Break(); // 3.
            return this.Content("Hello from FilterController.");
        }

        // GET: OutputCache
        [OutputCache(Duration = 10)]
        public ActionResult OutputCache()
        {
            return this.Content(DateTime.Now.ToString());
        }
    }
}