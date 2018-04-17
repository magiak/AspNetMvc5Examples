using AspNetMvc5Examples.Entities.DbContexts;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvc5Examples.Business.Middleware
{
    public class MyOwinMiddleware : OwinMiddleware
    {
        public static string AuthenticationKey = "MyAspNet.ApplicationCookie";
        private static string LoginPage = "/myaccount/login";
        private static string RegisterPage = "/myaccount/register";
        private readonly OwinMiddleware next;

        public MyOwinMiddleware(OwinMiddleware next) : base(next)
        {
            this.next = next;
        }

        public override async Task Invoke(IOwinContext context)
        {
            var path = context.Request.Environment["owin.RequestPath"].ToString().ToLower();
            var cookie = context.Request.Cookies[AuthenticationKey];
            if (cookie == null && path != LoginPage && path != RegisterPage)
            {
                context.Response.Redirect(LoginPage);
                return;
            }

            if (path == LoginPage || path == RegisterPage)
            {
                await this.next.Invoke(context);
                return;
            }

            // Get UserName and password from cookie
            var userName = cookie.Split(':')[0];
            var password = cookie.Split(':')[1];

            // KEY: AspNet.Identity.Owin:AspNetMvc5Examples.Entities.DbContexts.ApplicationDbContext, AspNetMvc5Examples.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null, AspNetMvc5Examples.Entities.DbContexts.ApplicationDbContext]}
            var key = $"AspNet.Identity.Owin:{typeof(ApplicationDbContext).AssemblyQualifiedName}";
            var dbContext = context.Get<ApplicationDbContext>(key);

            var user = dbContext.MyAspNetUsers.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if(user == null)
            {
                context.Response.Redirect(LoginPage);
                return;
            }

            await this.next.Invoke(context);
        }
    }
}
