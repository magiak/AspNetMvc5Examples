using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class DisplayModeProviderController : Controller
    {
        // TODO .NET Core ViewLocationExpanders
        public ActionResult Index()
        {
            return this.View();
        }
    }
}