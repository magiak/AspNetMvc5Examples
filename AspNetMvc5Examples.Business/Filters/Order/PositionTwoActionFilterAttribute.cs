using System.Diagnostics;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Business.Filters
{
    public class PositionTwoActionFilterAttribute : ActionFilterAttribute, IPositionFilter
    {
        public int Position => 2;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debugger.Break();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Debugger.Break();
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Debugger.Break();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //Debugger.Break();
        }
    }
}