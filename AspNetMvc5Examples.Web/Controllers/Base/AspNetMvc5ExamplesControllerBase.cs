using AspNetMvc5Examples.Web.ActionResults;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public abstract class AspNetMvc5ExamplesControllerBase : Controller
    {
        protected internal CustomContentResult CustomContent(string content)
        {
            return new CustomContentResult()
            {
                Content = content
            };
        }

        protected internal HtmlActionResult Html(string title, string body)
        {
            return new HtmlActionResult()
            {
                Title = title,
                Body = body
            };
        }

        protected internal DummyViewEngineActionResult DummyView(object model)
        {
            return new DummyViewEngineActionResult()
            {
                Model = model
            };
        }
    }
}