namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;
    using Business.Logging;
    using Ninject;

    public class NinjectController : Controller
    {
        private readonly ILoggingService loggingService;

        [Inject]
        public ILoggingService LoggingService { get; set; }


        public NinjectController(ILoggingService loggingService)
        {
            this.loggingService = loggingService;
        }

        // GET: Ninject
        public ActionResult Index()
        {
            this.loggingService.Log("Hello from ninject index");
            this.LoggingService.Log("Hello from ninject index2");
            return View();
        }
    }
}