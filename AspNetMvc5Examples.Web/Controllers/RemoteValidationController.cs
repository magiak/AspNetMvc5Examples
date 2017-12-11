namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;

    public class RemoteValidationController : Controller
    {
        // GET: RemoteValidation
        public JsonResult ValidateRemoteAttribute(string remoteAttribute)
        {
            if (remoteAttribute.StartsWith("a"))
            {
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }


            return this.Json("Remote attribute has to starts with A", JsonRequestBehavior.AllowGet);
        }
    }
}