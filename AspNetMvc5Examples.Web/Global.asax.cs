using AspNetMvc5Examples.Business.MyViewEngines;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AspNetMvc5Examples.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Add(new CustomViewEngine()); // Hi, from Views folder
            //ViewEngines.Engines.Insert(0, new CustomViewEngine()); // Hi, from CustomViews folder
        }
    }
}
