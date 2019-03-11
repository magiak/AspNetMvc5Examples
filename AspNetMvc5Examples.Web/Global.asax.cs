namespace AspNetMvc5Examples.Web
{
    using System;
    using System.Globalization;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AspNetMvc5Examples.Business.AutoMapperProfiles;
    using AutoMapper;
    using Business.MyViewEngines;
    using Business.ValueProvider;

    public class MvcApplication : System.Web.HttpApplication // NinjectHttpApplication
    {
        // Nastaveni ninjectu je zakomentovano na radku 99
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

            //GlobalConfiguration.Configuration.Formatters
            //    .JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            //serializerSettings.Converters.Add(new IsoDateTimeConverter());
            //GlobalConfiguration.Configuration.Formatters[0] = new JsonNetFormatter(serializerSettings);

            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
            //    new JsonSerializerSettings
            //    {
            //        DateFormatHandling = DateFormatHandling.IsoDateFormat,
            //        DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
            //        Culture = CultureInfo.GetCultureInfo("cs-CZ")
            //    };

            // TODO
            //var a = ModelMetadataProviders.Current; CachedDataAnnotationsModelMetadataProvider

            //ModelMetadataProviders.Current = new MetadataProvider();

            //var provider = ModelValidatorProviders.Providers.FirstOrDefault(p => p.GetType() == typeof(DataAnnotationsModelValidatorProvider));
            //if (provider != null)
            //{
            //    ModelValidatorProviders.Providers.Remove(provider);
            //}

            //ModelValidatorProviders.Providers.Add(new LocalizableModelValidatorProvider());
        }
        
        protected void Application_Error()
        {
            this.HandleException();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            InitializeCultureInfo();
            SetFormats();
        }

        private void HandleException()
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

        private static void SetFormats()
        {
            var cultureInfo = CultureInfo.CurrentCulture;

            const int english = 1033;
            const int czech = 1029;
            const int slovak = 1051;

            switch (cultureInfo.LCID)
            {
                case english:
                    cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                    cultureInfo.NumberFormat = new NumberFormatInfo { NumberDecimalSeparator = "." };
                    break;
                case czech:
                    cultureInfo.DateTimeFormat.ShortDatePattern = "d.M.yyyy";
                    cultureInfo.NumberFormat = new NumberFormatInfo { NumberDecimalSeparator = "," };
                    break;
                case slovak:
                    cultureInfo.DateTimeFormat.ShortDatePattern = "d. M. yyyy";
                    cultureInfo.NumberFormat = new NumberFormatInfo { NumberDecimalSeparator = "," };
                    break;
            }

            // is the .NET representation of the default user locale of the system.
            // This controls default number and date formatting and the like.
            CultureInfo.CurrentCulture = cultureInfo;

            // refers to the default user interface language, a setting introduced in Windows 2000.
            // This is primarily regarding the UI localization/translation part of your app.
            CultureInfo.CurrentUICulture = cultureInfo;
        }

        //protected override void OnApplicationStarted()
        //{
        //    base.OnApplicationStarted();

        //    AreaRegistration.RegisterAllAreas();
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);

        //    AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile(new MovieProfile()));
        //}

        //protected override IKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();
        //    kernel.Load(Assembly.GetExecutingAssembly());
        //    kernel.Load(new DefaultNinjectModule());
        //    kernel.Load(new INinjectModule[] { new DefaultNinjectModule() });
        //    return kernel;
        //}
    }
}
