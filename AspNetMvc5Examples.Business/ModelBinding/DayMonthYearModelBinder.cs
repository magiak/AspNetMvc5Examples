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
                var modelName = bindingContext.ModelName;
                var yearResult = bindingContext.ValueProvider.GetValue($"{modelName}.Year");
                var monthResult = bindingContext.ValueProvider.GetValue($"{modelName}.Month");
                var dayResult = bindingContext.ValueProvider.GetValue($"{modelName}.Day");

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
