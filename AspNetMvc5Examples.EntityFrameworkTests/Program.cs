namespace AspNetMvc5Examples.EntityFrameworkTests
{
    using System;
    using System.IO;
    using System.Linq;
    using Entities;
    using Entities.DbContexts;
    using Resources;

    class Program
    {
        static void Main(string[] args)
        {
            ChangeDataDirectoryToWebApplication();

            using (var context = new ApplicationDbContext())
            {
                Console.WriteLine(AspNetMvc5ExamplesResource.Program_Main_Started);
                context.Database.Log = Console.WriteLine;

                var order = new Order()
                {
                    Name = "My Order"
                };

                context.Orders.Add(order);
                context.SaveChanges();

                var orders = context.Orders.ToList();

                Console.WriteLine(AspNetMvc5ExamplesResource.Program_Main_PressAnyKeyToExit);
                Console.ReadKey();
            }
        }

        private static void ChangeDataDirectoryToWebApplication()
        {
            // Override DataDirectory variable used in App.config
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relative = @"..\..\..\AspNetMvc5Examples.Web\App_Data\";
            string absolute = Path.GetFullPath(Path.Combine(baseDirectory, relative));

            AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
        }
    }
}
