using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace AspNetMvc5Examples.KatanaOwin.Components
{
    using System.IO;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class MyWelcomePageComponent
    {
        private readonly AppFunc next;

        private readonly string html = "<html>" +
                                       "<body>" +
                                       "Hello from MyWelcomePageComponent </br>" +
                                       "<img src='http://blog.kudoybook.com/wp-content/uploads/images/Zilina_10536.jpg' >" +
                                       "</body>" +
                                       "</html>";

        public MyWelcomePageComponent(AppFunc next)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            this.next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;

            if (environment["owin.RequestPath"] as string == "/")
            {
                using (var writer = new StreamWriter(response))
                {
                    return writer.WriteAsync(this.html);
                }
            }

            return this.next(environment);
        }


        public Task InvokeWithOwinContext(IDictionary<string, object> environment)
        {
            IOwinContext context = new OwinContext(environment);

            if (context.Request.Path.Value == "/")
            {
                return context.Response.WriteAsync(this.html);
            }

            return this.next(environment);
        }
    }
}
