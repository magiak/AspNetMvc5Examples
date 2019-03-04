namespace AspNetMvc5Examples.KatanaOwin
{
    using System;
    using Components;
    using Owin;

    public class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void Configuration(IAppBuilder app) // renamed from ConfigureAuth
        {
            // 1.
            //app.Run(ctx =>
            //{
            //    return ctx.Response
            //        .WriteAsync("Hello, World!");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response
            //        .WriteAsync("Hello, World, Again!");
            //    //    only the first delegate will run.
            //});

            // 2.
            //app.UseWelcomePage(); // https://github.com/aspnet/AspNetKatana/blob/dev/src/Microsoft.Owin.Diagnostics/WelcomePageMiddleware.cs

            // 3.
            //app.Use<EmptyComponent>(); // The class 'AspNetMvc5Examples.KatanaOwin.EmptyComponent' does not have a constructor taking 1 arguments.

            // 4.
            //app.Use<WrongConstructorComponent>(); //  No conversion available between System.Func`2[System.Collections.Generic.IDictionary`2[System.String,System.Object],System.Threading.Tasks.Task] and ....

            // 5.
            //app.Use<MyWelcomePageComponent>(); // Or app.UseMyWelcomePage();

            // 6.
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Handling request.");
            //    //Console.WriteLine("Handling request.");
            //    await next();
            //    await context.Response.WriteAsync("Finished handling request.");
            //    //Console.WriteLine("Finished handling request.");
            //});

            //app.Run(async context =>
            //{
            //    //Console.WriteLine("Hello, World!");
            //    await context.Response.WriteAsync("Hello, World!");
            //});

            // 7. Implementation in .NET Core
            // https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.Core/Builder/MvcApplicationBuilderExtensions.cs

            // 8. Startup.Auth.cs -> ConfigureAuth

            // 9. BONUS :)
            //app.Map("/maptest", HandleMapTest); // http://localhost:8080/maptest
        }

        private static void HandleMapTest(IAppBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test Successful");
            });
        }
    }
}
