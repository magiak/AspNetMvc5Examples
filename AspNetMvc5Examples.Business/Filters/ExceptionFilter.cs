namespace AspNetMvc5Examples.Business.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Debugger.Break(); // 7.
            Debug.WriteLine("ExceptionFilter.OnException");
        }
    }
}
