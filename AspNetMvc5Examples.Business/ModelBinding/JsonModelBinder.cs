namespace AspNetMvc5Examples.Business.ModelBinding
{
    using System;
    using System.Web.Mvc;
    using Newtonsoft.Json;

    public class JsonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var value = bindingContext.ValueProvider.GetValue("Json");

                return JsonConvert.DeserializeObject(value.AttemptedValue, bindingContext.ModelType);
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Error", "Can not bind value to model");
                return null;
            }
        }
    }
}
