namespace AspNetMvc5Examples.Business.ModelBinding
{
    using System.Web.Mvc;

    public class MyModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
