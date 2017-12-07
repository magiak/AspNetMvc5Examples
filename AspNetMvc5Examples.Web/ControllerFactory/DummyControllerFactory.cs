namespace AspNetMvc5Examples.Web.ControllerFactory
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class DummyControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return Activator.CreateInstance(controllerType) as IController;
        }
    }
}