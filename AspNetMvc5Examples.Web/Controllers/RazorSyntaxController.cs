using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class RazorSyntaxController : Controller
    {
        // GET: RazorSyntax
        public ActionResult Examples()
        {
            return this.View();
        }
    }
}