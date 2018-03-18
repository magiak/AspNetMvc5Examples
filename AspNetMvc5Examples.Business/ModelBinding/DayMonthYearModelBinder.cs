namespace AspNetMvc5Examples.Business.ModelBinding
{
    using System;
    using System.Web.Mvc;

    public class DayMonthYearModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var yearResult = bindingContext.ValueProvider.GetValue("Year");
                var monthResult = bindingContext.ValueProvider.GetValue("Month");
                var dayResult = bindingContext.ValueProvider.GetValue("Day");

                int year = int.Parse(yearResult.AttemptedValue);
                int month = int.Parse(monthResult.AttemptedValue);
                int day = int.Parse(dayResult.AttemptedValue);

                return new DateTime(year, month, day);
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Error", "Can not bind value to model");
                return null;
            }
        }
    }
}
