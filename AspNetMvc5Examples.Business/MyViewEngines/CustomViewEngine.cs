using System.Web.Mvc;

namespace AspNetMvc5Examples.Business.MyViewEngines
{
    public class CustomViewEngine : RazorViewEngine
    {
        private string[] viewLocationFormats = new[]
        {
            "~/CustomViews/{1}/{0}.cshtml",
            "~/CustomViews/Shared/{0}.cshtml",
        };

        private string[] partialViewLocationFormats = new[]
        {
            "~/CustomViews/{1}/{0}.cshtml",
            "~/CustomViews/Shared/{0}.cshtml",
        };

        public CustomViewEngine()
        {
            ViewLocationFormats = viewLocationFormats;
            PartialViewLocationFormats = partialViewLocationFormats;
        }

    }
}
