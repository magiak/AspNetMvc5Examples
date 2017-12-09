namespace AspNetMvc5Examples.Web.Controllers.Base
{
    using System.Web.Mvc;
    using Business.ActionResults;

    public abstract class AspNetMvc5ExamplesControllerBase : Controller
    {
        protected internal LineBreaksContentResult LineBreaksContent(string content)
        {
            return new LineBreaksContentResult()
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