namespace AspNetMvc5Examples.Business.ValueProvider
{
    using System.Web.Mvc;
    public class MyValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new MyValueProvider(controllerContext);
        }
    }
}
