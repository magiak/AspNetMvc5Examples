namespace AspNetMvc5Examples.KatanaOwin
{
    using System;
    using Microsoft.Owin.Hosting;
    using Owin;
    using Resources;

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8081"))
            {
                Console.WriteLine(AspNetMvc5ExamplesResource.Program_Main_Started);

                // Now you can open http://localhost:8081/ in web browser :)

                Console.WriteLine(AspNetMvc5ExamplesResource.Program_Main_PressAnyKeyToExit);
                Console.ReadKey();
            }
        }
    }
}
