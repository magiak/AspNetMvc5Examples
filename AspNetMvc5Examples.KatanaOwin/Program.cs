namespace AspNetMvc5Examples.KatanaOwin
{
    using System;
    using Microsoft.Owin.Hosting;
    using Owin;

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8080"))
            {
                Console.WriteLine("Started");

                // Now you can open http://localhost:8080/ in web browser :)

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
