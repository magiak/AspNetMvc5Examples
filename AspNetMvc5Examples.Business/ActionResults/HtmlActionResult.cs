using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Business.ActionResults
{
    public class HtmlActionResult : ActionResult
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title>");
            sb.Append(this.Title);
            sb.Append("</title>");
            sb.Append("</head>");
            sb.Append("<body>");

            if (this.Body != null)
            {
                sb.Append(this.Body);
            }

            sb.Append("</body>");
            sb.Append("</html>");

            response.Write(sb.ToString());
        }
    }
}