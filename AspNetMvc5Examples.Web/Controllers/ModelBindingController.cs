namespace AspNetMvc5Examples.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Mvc;
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

        public ActionResult BindToViewModel(ModelBindingViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            return this.Content(json);
        }

        public ActionResult BindToChildViewModel(ModelBindingViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            return this.Content(json);
        }

        // Black list
        public ActionResult BindToViewModelExclude([Bind(Exclude = nameof(ModelBindingViewModel.Name))]ModelBindingViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            return this.Content(json);
        }

        // White list
        public ActionResult BindToViewModelInclude([Bind(Include = nameof(ModelBindingViewModel.Name))]ModelBindingViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            return this.Content(json);
        }
        #endregion

        public ActionResult Create()
        {
            return this.View(new ModelBindingViewModel());
        }
        
        [HttpPost]
        public ActionResult Create(ModelBindingViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
                return this.Content(json);
            }

            return this.View(viewModel);
        }

        #region Value Provider

        public ActionResult ValueProvider()
        {


            Debugger.Break();
            return new EmptyResult();
        }
        #endregion
    }
}