using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.ActionResults
{
    public class CustomContentResult : ContentResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            this.Content = this.Content.Replace(".", ".<br />");
            base.ExecuteResult(context);
        }
    }
}