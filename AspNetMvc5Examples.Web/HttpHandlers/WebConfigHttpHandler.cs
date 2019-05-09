using System.Web;

namespace AspNetMvc5Examples.Web.HttpHandlers
{
    public class WebConfigHttpHandler : IHttpHandler
    {
        // Gets a value indicating whether another request can use the IHttpHandler instance.
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Hello from HTTP handler registered in web.config");
        }
    }
}