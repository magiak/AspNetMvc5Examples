namespace AspNetMvc5Examples.Entities.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
            : this("dbo")
        {
        }

        public OrderConfiguration(string schema)
        {
            this.ToTable(nameof(Order), schema);

            this.HasKey(e => e.Id);

            this.Property(p => p.Name).HasMaxLength(64);
            this.HasMany(o => o.Movies).WithMany(m => m.Orders);
        }
    }
}
