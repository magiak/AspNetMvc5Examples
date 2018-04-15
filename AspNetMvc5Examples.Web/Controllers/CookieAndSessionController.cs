using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class CookieAndSessionController : Controller
    {
        private const string Key = "my-cookie";

        // cookie = per user on the client
        public ActionResult SaveCookie()
        {
            this.HttpContext.Response.Cookies[Key].Value = "Hello from cookie";
            this.HttpContext.Response.Cookies[Key].Expires = DateTime.Now.AddMinutes(5);
            return this.Content("Cookie Saved");
        }

        public ActionResult GetCookie()
        {
            return this.Content(this.HttpContext.Request.Cookies[Key].Value);
        }

        // Session = per user on the server
        public ActionResult SaveSession()
        {
            this.HttpContext.Session[Key] = "Hello from session";
            return this.Content("Session Saved");
        }

        public ActionResult GetSession()
        {
            return this.Content(this.HttpContext.Session[Key].ToString());
        }

        // TODO application and cache
    }
}