﻿using System;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class CookieAndSessionController : Controller
    {
        private const string Key = "my-cookie";

        // cookie = per user on the client
        public ActionResult SaveCookie()
        {
            this.HttpContext.Response.Cookies[Key].Value = "Hello from Cookie";
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
            this.HttpContext.Session[Key] = "Hello from Session";
            return this.Content("Session Saved");
        }

        public ActionResult GetSession()
        {
            return this.Content(this.HttpContext.Session[Key].ToString());
        }

        // Cache is shared between users and can be expired
        public ActionResult SaveCache()
        {
            this.HttpContext.Cache[Key] = "Hello from Cache";
            return this.Content("Cache Saved");
        }

        public ActionResult GetCache()
        {
            return this.Content(this.HttpContext.Cache[Key].ToString());
        }

        // Application is shared between users and can NOT be expired 
        public ActionResult SaveApplication()
        {
            this.HttpContext.Application[Key] = "Hello from Application";
            return this.Content("Application Saved");
        }

        public ActionResult GetApplication()
        {
            return this.Content(this.HttpContext.Application[Key].ToString());
        }
    }
}