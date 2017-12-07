namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;

    //[Authorize]
    public class AuthorizationAttributeController : Controller
    {
        // GET: AuthorizationAttribute
        public ActionResult Public()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult Secret()
        {
            return this.View();
        }

        //[AllowAnonymous]
        public ActionResult AllowAnonymous()
        {
            return this.View();
        }
    }
}