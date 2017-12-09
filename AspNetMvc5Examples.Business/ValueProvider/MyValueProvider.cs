namespace AspNetMvc5Examples.Business.ValueProvider
{
    using System;
    using System.Globalization;
    using System.Web;
    using System.Web.Mvc;

    public class MyValueProvider : IValueProvider
    {
        private readonly ControllerContext controllerContext;

        public MyValueProvider(ControllerContext controllerContext)
        {
            this.controllerContext = controllerContext;
        }

        public bool ContainsPrefix(string prefix)
        {
            return "Child.ChildName".Equals(prefix, StringComparison.OrdinalIgnoreCase);
        }

        public ValueProviderResult GetValue(string key)
        {
            // I have to check ContainsPrefix again
            if (this.ContainsPrefix(key))
            {
                var value = this.controllerContext.HttpContext.Request.Form[key];
                if (value != null && value.Equals("value provider", StringComparison.OrdinalIgnoreCase))
                {
                    var newValue = "Child name from value provider";
                    return new ValueProviderResult(newValue, newValue, CultureInfo.CurrentCulture);
                }
            }

            return null;
        }
    }
}
