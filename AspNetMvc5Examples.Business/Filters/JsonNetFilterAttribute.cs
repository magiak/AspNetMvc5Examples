using AspNetMvc5Examples.Business.ActionResults;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Filters
{
    public class JsonNetFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is JsonResult == false)
            {
                return;
            }

            filterContext.Result = new JsonNetResult(
                (JsonResult)filterContext.Result);
        }
    }
}