namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;

    public class PartialViewAndActionController : Controller
    {
        // GET: PartialViewAndAction
        public ActionResult Index()
        {
            return this.View();
        }

        [ChildActionOnly]
        public PartialViewResult _Action()
        {
            string viewModel = "Action";
            return this.PartialView(model: viewModel);
        }
    }
}