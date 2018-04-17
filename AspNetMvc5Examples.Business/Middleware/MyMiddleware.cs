using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMvc5Examples.Business.Middleware
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class MyMiddleware
    {
        private readonly AppFunc next;

        public MyMiddleware(AppFunc next)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            this.next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            

            return this.next(environment);
        }

    }
}
