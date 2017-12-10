using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Areas.RequestLifeCycle
{
    public class RequestLifeCycleAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "RequestLifeCycle";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RequestLifeCycle_default",
                "RequestLifeCycle/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}