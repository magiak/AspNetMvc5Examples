namespace AspNetMvc5Examples.Business.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class ResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debugger.Break(); // 5.
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debugger.Break(); // 6.
        }
    }
}
