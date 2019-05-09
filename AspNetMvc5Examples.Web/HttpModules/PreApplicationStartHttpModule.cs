using System.Web;

namespace AspNetMvc5Examples.Web.HttpModules
{
    public class PreApplicationStartHttpModule : IHttpModule
    {
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            // attach to an event
        }

        public PreApplicationStartHttpModule() { }
    }
}