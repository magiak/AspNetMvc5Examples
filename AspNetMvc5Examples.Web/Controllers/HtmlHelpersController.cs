namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using AspNetMvcExamples.Business.FlashMessages;
    using Models;

    public class HtmlHelpersController : Controller
    {
        // GET: EditorAndDisplayTemplates
        public ActionResult EditorAndDisplayTemplates()
        {
            var viewModel = new EditorAndDisplayTemplatesViewModel();
            this.InitializeViewModel(viewModel);
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult EditorAndDisplayTemplates(EditorAndDisplayTemplatesViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Home")
                    .WithSuccessAlert("Entity has been created");
            }

            this.InitializeViewModel(viewModel);
            return this.View(viewModel);
        }

        public void InitializeViewModel(EditorAndDisplayTemplatesViewModel viewModel)
        {
            viewModel.Price = 42;
            viewModel.MonthItems = GetMonthSelectListItems().ToList();
        }

        public static IEnumerable<SelectListItem> GetMonthSelectListItems()
        {
            for (int i = 1; i <= 12; i++)
            {
                yield return new SelectListItem
                {
                    Value = i.ToString(),
                    Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)
                };
            }
        }
    }
}