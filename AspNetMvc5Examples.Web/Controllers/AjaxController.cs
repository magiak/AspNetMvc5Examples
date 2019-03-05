namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AspNetMvc5Examples.Entities.DbContexts;
    using Models;

    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext context;

        public AjaxController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Ajax
        public ActionResult Index()
        {
            var viewModel = new SearchViewModel();
            return this.View(viewModel);
        }

        public PartialViewResult _AjaxPartial(SearchViewModel viewModel)
        {
            var titles = this.context.Movies
                .Where(m => m.Title.Contains(viewModel.Title))
                .Select(m => m.Title);

            return this.PartialView(model: string.Join(", ", titles));
        }
    }
}