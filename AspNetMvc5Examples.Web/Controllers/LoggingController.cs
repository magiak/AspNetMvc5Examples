using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Routing;
    using Business.Logging;

    public class LoggingController : IController
    {
        private readonly ILoggingService loggingService;

        public LoggingController(ILoggingService loggingService)
        {
            this.loggingService = loggingService;
        }

        public void Execute(RequestContext requestContext)
        {
            this.loggingService.Log("");
            HttpContext.Current.Response.Write("Hello from logging controller");
        }
    }
}