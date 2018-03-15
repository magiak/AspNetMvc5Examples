using System;

namespace AspNetMvc5Examples.Web.ControllerFactory
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.SessionState;
    using Business.Logging;
    using Controllers;

    public class LoggingControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName == "logging")
            {
                ILoggingService loggingService = new LoggingService();
                return new LoggingController(loggingService);
            }

            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return  SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
        }
    }
}
