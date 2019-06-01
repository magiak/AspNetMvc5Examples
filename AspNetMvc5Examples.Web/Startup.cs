using System.Diagnostics;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetMvc5Examples.Web.Startup))]
namespace AspNetMvc5Examples.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Debug.WriteLine("Startup"); // 3
            this.ConfigureAuth(app);
        }
    }
}
