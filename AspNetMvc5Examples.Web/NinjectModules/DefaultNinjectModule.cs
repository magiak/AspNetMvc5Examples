using AspNetMvc5Examples.Business.Logging;
using AspNetMvc5Examples.Entities.DbContexts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace AspNetMvc5Examples.Web.NinjectModules
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            this.Bind<ILoggingService>().To<DatabaseLoggingService>();
        }
    }
}