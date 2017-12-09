namespace AspNetMvc5Examples.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Mvc;
    using Business.ModelBinding;
    using Models;
    using Newtonsoft.Json;

    public class ModelBindingController : Controller
    {
        #region Basic binding
        public ActionResult BindToString(string value)
        {
            return this.Content(value);
        }

        public ActionResult BindToInt(int value)
        {
            return this.Content(value.ToString());
        }

        public ActionResult BindToDateTime(DateTime value)
        {
            return this.Content(value.ToLongDateString());
        }

        public ActionResult BindToViewModel(ModelBinderViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            return this.Content(json);
        }

        public ActionResult BindToChildViewModel(ModelBinderViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            return this.Content(json);
        }

        // Black list
        public ActionResult BindToViewModelExclude([Bind(Exclude = nameof(ModelBinderViewModel.Name))]ModelBinderViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            return this.Content(json);
        }

        // White list
        public ActionResult BindToViewModelInclude([Bind(Include = nameof(ModelBinderViewModel.Name))]ModelBinderViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            return this.Content(json);
        }
        #endregion

        public ActionResult Create()
        {
            return this.View(new ModelBinderViewModel());
        }
        
        [HttpPost]
        public ActionResult Create(ModelBinderViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
                return this.Content(json);
            }

            return this.View(viewModel);
        }

        public ActionResult CreateJson()
        {
            var viewModel = new JsonViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateJson([ModelBinder(typeof(JsonModelBinder))] ModelBinderViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                Debugger.Break();

                var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
                return this.Content(json);
            }

            return this.View(this.HttpContext.Request.Form[nameof(JsonViewModel.Json)]);
        }

        public ActionResult CreateDayMonthYear()
        {
            var viewModel = new DayMonthYearViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateDayMonthYear([ModelBinder(typeof(DayMonthYearModelBinder))]DateTime date)
        {
            if (this.ModelState.IsValid)
            {
                Debugger.Break();

                return this.Content(date.ToShortDateString());
            }

            var viewModel = new DayMonthYearViewModel()
            {
                Day = date.Day,
                Month = date.Month,
                Year = date.Year
            };

            return this.View(viewModel);
        }
    }
}