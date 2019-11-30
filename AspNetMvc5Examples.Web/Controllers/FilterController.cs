namespace AspNetMvc5Examples.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Web.Mvc;
    using Business.Filters;

    public class FilterController : Controller
    {
        [AuthorizationFilter]
        [CustomActionFilter]
        [ResultFilter]
        [ExceptionFilter]
        // [BaseCustomActionFilter] // ActionFilterAttribute = easy way to implement CustomActionFilter and ResultFilter
        public ActionResult Index()
        {
            Debugger.Break(); // 3.
            // throw new Exception("This will be catched by ExceptionFilter");
            return this.Content("Hello from FilterController.");
        }

        [PositionOneActionFilter]
        [PositionTwoActionFilter]
        public ActionResult Position()
        {
            return this.Content("Hello from FilterController.");
        }

        // GET: OutputCache
        [OutputCache(Duration = 10)]
        // [OutputCache(CacheProfile = "Long")] // defined in web.config (https://prashantbrall.wordpress.com/2013/09/29/using-output-cache-profile-in-asp-net-mvc/)
        public ActionResult OutputCache()
        {
            return this.Content(DateTime.Now.ToString());
        }

        [MyActionFilter]
        public ActionResult Test()
        {
            return this.Content("Hello wordl");
        }

        public ActionResult Test2()
        {
            return this.Content("Hello world 2");
        }
    }
}