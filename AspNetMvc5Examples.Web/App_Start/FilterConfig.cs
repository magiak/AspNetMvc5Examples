using AspNetMvc5Examples.Business.Filters;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // filters.Add(new HandleErrorAttribute());

            //filters.Add(new AuthorizationFilter());
            //filters.Add(new ActionFilter());
            //filters.Add(new ResultFilter());
            //filters.Add(new ExceptionFilter());
        }
    }
}
