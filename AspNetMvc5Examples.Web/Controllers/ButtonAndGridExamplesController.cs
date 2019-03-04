namespace AspNetMvc5Examples.Web.Controllers
{
    using AspNetMvc5Examples.Entities.DbContexts;
    using System.Linq;
    using System.Web.Mvc;

    public class ButtonAndGridExamplesController : Controller
    {
        private readonly ApplicationDbContext context;

        public ButtonAndGridExamplesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Index(string title)
        {
            this.ViewBag.Message = title;
            return this.View();
        }

        public ActionResult GridView()
        {
            var movies = this.context.Movies.ToList();
            return this.View(movies);
        }
    }
}