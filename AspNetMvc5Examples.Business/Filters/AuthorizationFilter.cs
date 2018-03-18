namespace AspNetMvc5Examples.Business.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class AuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Debugger.Break(); // 1.
            Debug.WriteLine("AuthorizationFilter.OnAuthorization");
        }
    }
}
