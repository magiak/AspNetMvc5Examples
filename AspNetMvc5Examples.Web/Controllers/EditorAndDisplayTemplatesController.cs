namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;

    public class EditorAndDisplayTemplatesController : Controller
    {
        // GET: EditorAndDisplayTemplates
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            return View();
        }
    }
}