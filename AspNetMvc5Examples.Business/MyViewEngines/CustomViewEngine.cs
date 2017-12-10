using System.Web.Mvc;

namespace AspNetMvc5Examples.Business.MyViewEngines
{
    public class CustomViewEngine : RazorViewEngine
    {
        private readonly string[] viewLocationFormats =
        {
            "~/CustomViews/{1}/{0}.cshtml",
            "~/CustomViews/Shared/{0}.cshtml",
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml",
        };

        private readonly string[] partialViewLocationFormats =
        {
            "~/CustomViews/{1}/{0}.cshtml",
            "~/CustomViews/Shared/{0}.cshtml",
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml",
        };

        public CustomViewEngine()
        {
            this.ViewLocationFormats = this.viewLocationFormats;
            this.PartialViewLocationFormats = this.partialViewLocationFormats;
        }
    }
}
