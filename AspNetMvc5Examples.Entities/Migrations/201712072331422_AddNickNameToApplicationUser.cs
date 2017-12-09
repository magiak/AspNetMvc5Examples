namespace AspNetMvc5Examples.Entities.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddNickNameToApplicationUser : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.AspNetUsers", "NickName", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            this.DropColumn("dbo.AspNetUsers", "NickName");
        }
    }
}
