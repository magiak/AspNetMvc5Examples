namespace AspNetMvc5Examples.Web.Controllers
{
    using System;
    using System.Net;
    using System.Web.Http;
    using System.Web.Mvc;

    public class HandleErrorsController : Controller
    {
        // GET: HandleErrors
        public ActionResult ExceptionAction()
        {
            throw new Exception();
        }

        public ActionResult BadRequestAction()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
        }

        public ActionResult UnauthorizedAction()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Unauthorized");
        }

        public ActionResult InternalServerErrorAction()
        {
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "InternalServerError");
        }
    }
}