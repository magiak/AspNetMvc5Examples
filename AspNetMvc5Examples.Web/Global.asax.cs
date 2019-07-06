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
    using Ninject.Web.Common;

    public class MvcApplication : NinjectHttpApplication // HttpApplication
    {
        public static void PreApplicationStart()
        {
            Debug.WriteLine("PreApplicationStart"); // 1
            HttpApplication.RegisterModule(typeof(PreApplicationStartHttpModule));
        }


        // HttpApplication
        // protected void Application_Start()
        // {

        // NinjectHttpApplication
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            Debug.WriteLine("Application_Start"); // 2
            //ControllerBuilder.Current.SetControllerFactory(new LoggingControllerFactory());

            ValueProviderFactories.Factories.Insert(0, new MyValueProviderFactory());

            var binder = new DayMonthYearModelBinder();
            //ModelBinders.Binders.Add(typeof(DateTime), binder);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetViewEngines();

            SetFormatters();
            SetMetadataProviders();
            SetCustomDisplayMode();

            // Initialize obsolete static AutoMapper (instance mapper is initialized inside DefaultNinjectModule)
            Mapper.Initialize(x => { x.AddProfile<MyProfile>(); });
        }
        
        protected void Application_Error()
        {
            this.HandleException();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_AcquireRequestState"); // 7

            InitializeCultureInfo();
            // SetFormats(); // throws exception
        }
        
        protected void Application_BeginRequest()
        {
            // The BeginRequest event signals the creation of any given new request.
            Debug.WriteLine("Application_BeginRequest"); // 4
        }

        protected void Application_MapRequestHandler()
        {
            // Occurs when the handler is selected to respond to the request
            Debug.WriteLine("Application_MapRequestHandler"); // 5
        }

        protected void Application_PostMapRequestHandler()
        {
            // Occurs when ASP.NET has mapped the current request to the appropriate event handler.
            Debug.WriteLine("Application_PostMapRequestHandler"); // 6
        }

        //protected void Application_AcquireRequestState()
        //{
        //    // Occurs when ASP.NET acquires the current state (for example, session state) that is associated with the current request.
        //    Debug.WriteLine(""); // 7
        //}

        protected void Application_PreRequestHandlerExecute()
        {
            // Occurs just before ASP.NET starts executing an event handler
            Debug.WriteLine("Application_PreRequestHandlerExecute"); // 8
        }

        // MvcHandler.BeginProcessRequest

        // ApplicationEventsController.Index // 6

        protected void Application_PostRequestHandlerExecute()
        {
            // Occurs when the ASP.NET event handler (for example, a page or an XML Web service) finishes execution.
            Debug.WriteLine("Application_PostRequestHandlerExecute"); // 9
        }

        protected void Application_EndRequest()
        {
            // Occurs as the last event in the HTTP pipeline chain of execution when ASP.NET responds to a request.
            Debug.WriteLine("Application_EndRequest"); // 10
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
                    // Exception thrown: Instance is read-only.
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

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            // Another options
            // kernel.Load(new DefaultNinjectModule());
            // kernel.Load(new INinjectModule[] { new DefaultNinjectModule() });

            return kernel;
        }
    }
}
