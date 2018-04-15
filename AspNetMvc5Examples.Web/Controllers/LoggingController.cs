using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Routing;
    using Business.Logging;

    public class LoggingController : Controller
    {
        private readonly ILoggingService loggingService;

        public LoggingController(ILoggingService loggingService)
        {
            this.loggingService = loggingService;
        }

        protected override void Execute(RequestContext requestContext)
        {
            this.loggingService.Log("");
            requestContext.HttpContext.Response.Write("Hello from logging controller");
        }
    }
}