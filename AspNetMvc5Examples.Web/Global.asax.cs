namespace AspNetMvc5Examples.Web
{
    using System;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Business.ModelBinding;
    using Business.ValueProvider;
    using ControllerFactory;
    using Models;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(new LoggingControllerFactory());

            ValueProviderFactories.Factories.Insert(0, new MyValueProviderFactory());

            //var binder = new DayMonthYearModelBinder();
            //ModelBinders.Binders.Add(typeof(DateTime), binder);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            //ViewEngines.Engines.Add(new CustomViewEngine()); // Hi, from Views folder
            //ViewEngines.Engines.Insert(0, new CustomViewEngine()); // Hi, from CustomViews folder
        }
    }
}
