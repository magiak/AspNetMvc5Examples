namespace AspNetMvc5Examples.Entities.DbContexts
{
    using System;
    using System.Data.Entity;
    using System.Reflection;
    using Configurations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<MyAspNetUser> MyAspNetUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(
                Assembly.GetExecutingAssembly());

            // OR
            //modelBuilder.Configurations.Add(new OrderConfiguration());

            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }
    }
}