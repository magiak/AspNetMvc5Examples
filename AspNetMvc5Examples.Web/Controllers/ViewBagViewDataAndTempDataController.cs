using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class ViewBagViewDataAndTempDataController : Controller
    {
        public ActionResult ViewBagAction()
        {
            this.ViewBag.MyObject = "Hello, from view bag";
            return this.View();
        }

        public ActionResult ViewDataAction()
        {
            this.ViewData["MyObject"] = "Hello, from view data";
            //this.ViewBag.MyObject = "Hello, from view bag"; override value set to ViewData!
            return this.View();
        }

        public ActionResult TempDataAction()
        {
            this.TempData["MyObject"] = "Hello, from temp data"; // try with viewdata
            return this.RedirectToAction("TempDataAction2");
        }

        public ActionResult TempDataAction2()
        {
            return this.Content(this.TempData["MyObject"].ToString());
        }
    }
}