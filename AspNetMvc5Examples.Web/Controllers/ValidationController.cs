namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;
    using AspNetMvcExamples.Business.FlashMessages;
    using Models;

    public class ValidationController : Controller
    {
        // GET: Validation
        public ActionResult Create()
        {
            var viewModel = new ValidationViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ValidationViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Home")
                    .WithSuccessAlert("Validation entity has been created");
            }

            return this.View(viewModel);
        }
    }
}