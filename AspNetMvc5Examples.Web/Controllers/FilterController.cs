﻿namespace AspNetMvc5Examples.Web.Controllers
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

        // GET: OutputCache
        [OutputCache(Duration = 10)]
        public ActionResult OutputCache()
        {
            return this.Content(DateTime.Now.ToString());
        }
    }
}