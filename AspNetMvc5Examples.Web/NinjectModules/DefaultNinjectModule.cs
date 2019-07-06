using System.Reflection;
using AspNetMvc5Examples.Business.AutoMapperProfiles;
using AspNetMvc5Examples.Business.Logging;
using AspNetMvc5Examples.Entities.DbContexts;
using AutoMapper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace AspNetMvc5Examples.Web.NinjectModules
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            // AutoMapper
            var mapperConfiguration = CreateConfiguration();
            this.Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            // This teaches Ninject how to create automapper instances say if for instance
            // MyResolver has a constructor with a parameter that needs to be injected
            this.Bind<IMapper>().ToMethod(ctx =>
                 new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));


            // DI configuration
            this.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            //this.Bind<ILoggingService>().To<LoggingService>();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddMaps(typeof(MyProfile).Assembly);

                //cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            return config;
        }
    }
}