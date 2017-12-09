namespace AspNetMvc5Examples.Entities.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
            : this("dbo")
        {
        }

        public ApplicationUserConfiguration(string schema)
        {
            this.Property(p => p.NickName).HasMaxLength(64);
        }
    }
}
