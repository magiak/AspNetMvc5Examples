namespace AspNetMvc5Examples.Entities.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DbContexts;
    using IdentityManagers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        //  This method will be called after migrating to the latest version.
        protected override void Seed(ApplicationDbContext context)
        {
            // 1.
            var hasher = new PasswordHasher();
            var passwordHash = hasher.HashPassword("heslo"); // returns "ABc36JHO0H9mwmUGMToH/ZgRXQQ4oai6s260lRVmlLPItQnniVDdGDmn+ILFjqLhHQ=="

            context.Users.AddOrUpdate(new ApplicationUser
            {
                Email = "lukaskmochit@gmail.com",
                PasswordHash = passwordHash,
                UserName = "Lukas Kmoch",
                NickName = "MCP"
            });

            if (!context.Users.Any())
            {
                // 2.
                var user = new ApplicationUser
                {
                    UserName = "lukaskmochit@gmail.com",
                    Email = "lukaskmochit@gmail.com",
                    NickName = "MCP"
                };

                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                userManager.Create(user, "heslo");

                // 2. DO NOT USE - This solution requires OWIN reference and it can not be used from package manager console
                //var user = new ApplicationUser
                //{
                //    UserName = "lukaskmochit@gmail.com",
                //    Email = "lukaskmochit@gmail.com",
                //    NickName = "MCP"
                //};

                //var wrapper = new HttpContextWrapper(HttpContext.Current) as HttpContextBase;
                //var userManager = wrapper.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //var result = await this.UserManager.CreateAsync(user, "heslo");
            }
        }
    }
}
