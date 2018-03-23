﻿namespace AspNetMvc5Examples.Web
{
    using System;
    using System.Globalization;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AspNetMvc5Examples.Business.AutoMapperProfiles;
    using AspNetMvc5Examples.Business.ModelBinding;
    using AutoMapper;
    using Business.MyViewEngines;
    using Business.ValueProvider;
    using ControllerFactory;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //ControllerBuilder.Current.SetControllerFactory(new LoggingControllerFactory());

            ValueProviderFactories.Factories.Insert(0, new MyValueProviderFactory());

            //var binder = new DayMonthYearModelBinder();
            //ModelBinders.Binders.Add(typeof(DateTime), binder);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new RazorViewEngine());

            //ViewEngines.Engines.Add(new CustomViewEngine()); // Hi, from Views folder
            ViewEngines.Engines.Insert(0, new CustomViewEngine()); // Hi, from CustomViews folder

            Mapper.Initialize(cfg => cfg.AddProfile(new MyProfile()));

            MvcApplication.InitializeCultureInfo();
        }

        protected void Application_Error()
        {
            this.HandleExeption();
        }

        private void HandleExeption()
        {
            var exception = this.Server.GetLastError();
            HttpException httpException = exception as HttpException;

            // skip 404 http exceptions
            if (httpException != null && httpException.GetHttpCode() == 404)
            {
                return;
            }

            if (httpException != null)
            {
                Console.WriteLine($"HttpException occured: {httpException.ErrorCode} {httpException.Message}");
            }
            else
            {
                Console.WriteLine($"Exception occured: {exception.Message}");
            }
        }

        private static void InitializeCultureInfo()
        {
            if (HttpContext.Current?.Session == null)
            {
                return;
            }


            if (HttpContext.Current.Session["Lang"] == null)
            {
                return;
            }

            CultureInfo cultureInfo;
            var culture = HttpContext.Current.Session["Lang"];
            if (culture != null)
            {
                cultureInfo = (CultureInfo)culture;


                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;
            }
        }
    }
}
