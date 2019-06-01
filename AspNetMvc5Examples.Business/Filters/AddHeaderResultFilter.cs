namespace AspNetMvc5Examples.Business.Filters
{
    using System;
    using System.Web.Mvc;

    public class AddHeaderResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("X-MyHeader", DateTime.Today.ToShortDateString());
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}
