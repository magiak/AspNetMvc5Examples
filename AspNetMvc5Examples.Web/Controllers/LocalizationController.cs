using System.Globalization;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class LocalizationController : Controller
    {
        // GET: Localization
        public ActionResult Index()
        {
            var localizedValueFromServer = Resources.AspNetMvc5ExamplesResource.Name;
            return View(model: localizedValueFromServer);
        }

        //[HttpPost]
        public ActionResult ChangeCulture(string lang)
        {
            CultureInfo ci = new CultureInfo(lang);

            this.HttpContext.Session["Lang"] = ci;
            return this.RedirectToAction("Index");
        }
    }
}