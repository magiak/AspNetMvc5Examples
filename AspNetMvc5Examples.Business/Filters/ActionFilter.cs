namespace AspNetMvc5Examples.Business.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class ActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debugger.Break(); // 2.
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debugger.Break(); // 4.
        }
    }
}
