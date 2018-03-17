namespace AspNetMvc5Examples.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Mvc;
    using Business.ModelBinding;
    using Models;
    using Newtonsoft.Json;

    public class ModelBindingController : Controller
    {
        public ActionResult BasicMapping()
        {
            return View();
        }

        #region Basic Binding
        public ActionResult BindToString(string value)
        {
            Debugger.Break();
            return this.Content(value);
        }

        public ActionResult BindToInt(int value)
        {
            Debugger.Break();
            return this.Content(value.ToString());
        }

        public ActionResult BindToDateTime(DateTime value)
        {
            Debugger.Break();
            return this.Content(value.ToLongDateString());
        }

        public ActionResult BindToViewModel(ModelBinderViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            Debugger.Break();
            return this.Content(json);
        }

        public ActionResult BindToChildViewModel(ModelBinderViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            Debugger.Break();
            return this.Content(json);
        }

        // Black list
        public ActionResult BindToViewModelExclude([Bind(Exclude = nameof(ModelBinderViewModel.Name))]ModelBinderViewModel viewModel)
        {
            var data = this.HttpContext.Request.Form;
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            Debugger.Break();
            return this.Content(json);
        }

        // White list
        public ActionResult BindToViewModelInclude([Bind(Include = nameof(ModelBinderViewModel.Name))]ModelBinderViewModel viewModel)
        {
            var data = this.HttpContext.Request.Form;
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            Debugger.Break();
            return this.Content(json);
        }
        #endregion

        #region Array Binding

        public ActionResult BindToValueTypeList()
        {
            var list = new List<int> { 1, 2, 3 };

            return this.View(list);
        }

        [HttpPost]
        public ActionResult BindToValueTypeList(List<int> list)
        {
            if(list == null)
            {
                return new EmptyResult();
            }

            return this.Content(string.Join(",", list));
        }

        public ActionResult BindToReferenceTypeList()
        {
            var list = new List<ModelBinderArrayViewModel>
            {
                new ModelBinderArrayViewModel { Value = "1. value" },
                new ModelBinderArrayViewModel { Value = "2. value" },
                new ModelBinderArrayViewModel { Value = "3. value" },
            };

            return this.View(list);
        }

        [HttpPost]
        public ActionResult BindToReferenceTypeList(List<ModelBinderChildViewModel> list)
        {
            return this.Content(string.Join(",", list.Select(x => x.ChildName)));
        }

        public ActionResult BindToReferenceTypeNonSequentialList()
        {
            var list = new List<ModelBinderArrayViewModel>
            {
                new ModelBinderArrayViewModel { Index = "1index", Value = "1. value" },
                new ModelBinderArrayViewModel { Index = "2index", Value = "2. value" },
                new ModelBinderArrayViewModel { Index = "3index", Value = "3. value" },
            };

            return this.View(list);
        }

        [HttpPost]
        public ActionResult BindToReferenceTypeNonSequentialList(IEnumerable<ModelBinderArrayViewModel> list)
        {
            return this.Content(string.Join(",", list.Select(x => x.Value)));
        }

        public PartialViewResult _ModelBinderArrayViewModel()
        {
            var viewModel = new ModelBinderArrayViewModel();

            return this.PartialView(viewModel);
        }
        #endregion

        #region View Model Binding
        // This action prepares data for JsonModelBinder
        public ActionResult BindToChild()
        {
            return this.View(new ModelBinderViewModel());
        }

        [HttpPost]
        public ActionResult BindToChild(ModelBinderViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
                return this.Content(json);
            }

            return this.View(viewModel);
        }

        #endregion

        #region Custom Model Binding
        public ActionResult JsonModelBinder()
        {
            var viewModel = new JsonViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult JsonModelBinder([ModelBinder(typeof(JsonModelBinder))] ModelBinderViewModel viewModel)
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
        #endregion
    }
}