namespace AspNetMvc5Examples.Business.Logging
{
    using Entities.DbContexts;
    using Entities.Models;

    public class DatabaseLoggingService : ILoggingService
    {
        private readonly ApplicationDbContext dbContext;

        public DatabaseLoggingService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Log(string message)
        {
            this.dbContext.Orders.Add(new Order() {Name = message});
            this.dbContext.SaveChanges();
        }
    }
}
