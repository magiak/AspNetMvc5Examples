using AspNetMvc5Examples.Entities.IdentityManagers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetMvc5Examples.Business.Middleware
{
    public class MyOwinMiddleware : OwinMiddleware
    {
        public static string AuthenticationKey = "MyAspNet.ApplicationCookie";
        private static string LoginPage = "/myaccount/login";
        private static string RegisterPage = "/myaccount/register";
        private static string LogoutCallbackPath = "/account/logoff";
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

            if (path == LogoutCallbackPath)
            {
                context.Response.Cookies.Delete(
                    AuthenticationKey,
                    new CookieOptions { Expires = DateTime.Today.AddDays(-1), });

                await this.next.Invoke(context);
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

            var userManager = context.GetUserManager<ApplicationUserManager>();
            var signInManager = context.Get<ApplicationSignInManager>();

            var status = signInManager.PasswordSignIn(userName, password, true, false);
            if(status != SignInStatus.Success)
            {
                context.Response.Redirect(LoginPage);
                return;
            }

            var applicationUser = await userManager.FindByNameAsync(userName);
            var identity = await applicationUser.GenerateUserIdentityAsync(userManager);
            context.Request.User = new ClaimsPrincipal(identity);

            // USING DB CONTEXT
            // KEY: AspNet.Identity.Owin:AspNetMvc5Examples.Entities.DbContexts.ApplicationDbContext, AspNetMvc5Examples.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null, AspNetMvc5Examples.Entities.DbContexts.ApplicationDbContext]}
            //var key = $"AspNet.Identity.Owin:{typeof(ApplicationDbContext).AssemblyQualifiedName}";
            //var dbContext = context.Get<ApplicationDbContext>(key);

            //var user = dbContext.MyAspNetUsers.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            //var applicationUser = dbContext.Users.FirstOrDefault(x => x.UserName == userName);

            //if (user == null)
            //{
            //    context.Response.Redirect(LoginPage);
            //    return;
            //}

            // OR Generic user
            //context.Request.User = new GenericPrincipal(
            //    new GenericIdentity(user.UserName)
            //    , new string[] { });

            // OR Claims user
            //context.Request.User =
            //    new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim("UserName", user.UserName) }, "Basic"));

            await this.next.Invoke(context);
        }
    }
}
