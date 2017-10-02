using System.Web.Mvc;

namespace AspNetMvc5Examples.Business.ActionResults
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