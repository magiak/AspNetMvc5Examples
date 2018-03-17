namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;

    public class RemoteValidationController : Controller
    {
        // GET: RemoteValidation
        public JsonResult ValidateRemoteAttribute(string remoteAttribute)
        {
            if (remoteAttribute.ToLower().StartsWith("h"))
            {
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }

            return this.Json("Value has to starts with character 'H'", JsonRequestBehavior.AllowGet);
        }
    }
}