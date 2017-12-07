namespace AspNetMvc5Examples.Entities.Configurations
{
    using System.Data.Entity.ModelConfiguration;

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
        }
    }
}
