[assembly: System.Web.PreApplicationStartMethod(typeof(AspNetMvc5Examples.Web.MvcApplication), "PreApplicationStart")]
namespace AspNetMvc5Examples.Web
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.WebPages;
    using AspNetMvc5Examples.Business.AutoMapperProfiles;
    using AspNetMvc5Examples.Business.ModelBinding;
    using AspNetMvc5Examples.Web.HttpModules;
    using AspNetMvc5Examples.Web.NinjectModules;
    using AutoMapper;
    using Business.MyViewEngines;
    using Business.ValueProvider;
    using Ninject;
    using Ninject.Modules;

    public class MvcApplication : HttpApplication // NinjectHttpApplication
    {
        public static void PreApplicationStart()
        {
            Debug.WriteLine("PreApplicationStart");
            HttpApplication.RegisterModule(typeof(PreApplicationStartHttpModule));
        }

        // Uncomment
        //protected override void OnApplicationStarted()
        //{
        //    base.OnApplicationStarted();
        // + CreateKernel

        protected void Application_Start()
        {
            Debug.WriteLine("Application_Start");
            //ControllerBuilder.Current.SetControllerFactory(new LoggingControllerFactory());

            ValueProviderFactories.Factories.Insert(0, new MyValueProviderFactory());

            //var binder = new DayMonthYearModelBinder();
            //ModelBinders.Binders.Add(typeof(DateTime), binder);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetViewEngines();

            Mapper.Initialize(cfg => cfg.AddProfile(new MyProfile()));

            SetFormatters();
            SetMetadataProviders();
            SetCustomDisplayMode();
        }
        
        protected void Application_Error()
        {
            this.HandleException();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_AcquireRequestState"); // 4

            InitializeCultureInfo();
            SetFormats();
        }
        
        protected void Application_BeginRequest()
        {
            Debug.WriteLine("Application_BeginRequest"); // 1
        }

        protected void Application_MapRequestHandler()
        {
            Debug.WriteLine("Application_MapRequestHandler"); // 2
        }

        protected void Application_PostMapRequestHandler()
        {
            Debug.WriteLine("Application_PostMapRequestHandler"); // 3
        }

        //protected void Application_AcquireRequestState()
        //{
        //    Debug.WriteLine(""); // 4
        //}

        protected void Application_PreRequestHandlerExecute()
        {
            Debug.WriteLine("Application_PreRequestHandlerExecute"); // 5
        }

        // 6 - ApplicationEventsController.Index

        protected void Application_PostRequestHandlerExecute()
        {
            Debug.WriteLine("Application_PostRequestHandlerExecute"); // 7
        }

        protected void Application_EndRequest()
        {
            Debug.WriteLine("Application_EndRequest"); // 8
        }

        #region Set services
        private void SetViewEngines()
        {
            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new RazorViewEngine());

            //ViewEngines.Engines.Add(new CustomViewEngine()); // Hi, from Views folder
            ViewEngines.Engines.Insert(0, new CustomViewEngine()); // Hi, from CustomViews folder
        }

        private void SetFormatters()
        {
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
        }

        private void SetMetadataProviders()
        {
            // TODO [MetadataType]
            // ViewData.ModelMetadata.AdditionalValues atd

            // Model metadata providers
            // CachedDataAnnotationsModelMetadataProvider
            //ModelMetadataProviders.Current = new LocalizableDataAnnotationsModelMetadataProvider();

            //// Model validator providers
            //var providers = ModelValidatorProviders.Providers.ToList();

            //var dataErrorProvider = ModelValidatorProviders.Providers
            //    .FirstOrDefault(p => p.GetType() == typeof(DataErrorInfoModelValidatorProvider));
            //if (dataErrorProvider != null)
            //{
            //    ModelValidatorProviders.Providers.Remove(dataErrorProvider);
            //}
            //ModelValidatorProviders.Providers.Add(new CustomDataErrorInfoModelValidatorProvider());

            //// Model validator providers
            //var clientDataProvider = ModelValidatorProviders.Providers
            //    .FirstOrDefault(p => p.GetType() == typeof(ClientDataTypeModelValidatorProvider));
            //if (clientDataProvider != null)
            //{
            //    ModelValidatorProviders.Providers.Remove(clientDataProvider);
            //}
            //ModelValidatorProviders.Providers.Add(new CustomClientDataTypeModelValidatorProvider());

            // OLD //////////////////////////////////////////////////////////////////////////////////////////////////
            //DataAnnotationsModelValidatorProvider

            // TODO
            //var a = ModelMetadataProviders.Current;
            // CachedDataAnnotationsModelMetadataProvider
            // https://github.com/aspnet/AspNetWebStack/blob/master/src/System.Web.Mvc/CachedDataAnnotationsModelMetadataProvider.cs

            //ModelMetadataProviders.Current = new MetadataProvider();
            //ModelMetadataProviders.Current = new LocalizableDataAnnotationsModelMetadataProvider( );

            //var providers = ModelValidatorProviders.Providers.ToList();
            // DataAnnotationsModelValidatorProvider
            // DataErrorInfoModelValidatorProvider, ClientDataTypeModelValidatorProvider
            // https://github.com/aspnet/AspNetWebStack/blob/master/src/System.Web.Mvc/DataErrorInfoModelValidatorProvider.cs


            //var provider = ModelValidatorProviders.Providers.FirstOrDefault(p => p.GetType() == typeof(DataAnnotationsModelValidatorProvider));
            //if (provider != null)
            //{
            //    ModelValidatorProviders.Providers.Remove(provider);
            //}

            //ModelValidatorProviders.Providers.Add(new LocalizableModelValidatorProvider());

            // http://prideparrot.com/blog/archive/2012/9/creating_custom_modelvalidatorprovider
            // https://weblogs.asp.net/srkirkland/adding-client-validation-to-dataannotations-datatype-attribute
        }

        private void SetMetadataProviderAPI()
        {
            // GlobalConfiguration.Configuration.Services.Add(
            //    typeof(ModelValidatorProvider), new CustomModelValidatorProvider());
        }

        private void SetCustomDisplayMode()
        {
            // Query String: language
            var supportedLanguages = new[] { "cs-CZ", "en-US" };
            foreach(var lang in supportedLanguages)
            {
                DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode(lang)
                {
                    ContextCondition = context =>
                        context.Request.QueryString.AllKeys.Contains("language") &&
                        context.Request.QueryString["language"] == lang
                });
            }

            // User Agent
            //DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("mobile")
            //{
            //    //ContextCondition = (context => context.Request.UserAgent
            //    //    .IndexOf("mobile", StringComparison.OrdinalIgnoreCase) >= 0)
            //    ContextCondition = context => true
            //});

            // Accept-Language
            //DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("cs-CZ")
            //{
            //    ContextCondition = context =>
            //        context.Request.Headers.AllKeys.Contains("Accept-Language") &&
            //        context.Request.Headers["Accept-Language"].Contains("cs-CZ") // "en-US,en;q=0.9,cs;q=0.8,cs-CZ;q=0.7"
            //});
        }
        #endregion

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
