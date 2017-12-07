namespace AspNetMvc5Examples.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Business.MyViewEngines;
    using ControllerFactory;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(new LoggingControllerFactory());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ViewEngines.Engines.Add(new CustomViewEngine()); // Hi, from Views folder
            //ViewEngines.Engines.Insert(0, new CustomViewEngine()); // Hi, from CustomViews folder
        }
    }
}
