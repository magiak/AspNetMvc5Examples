namespace AspNetMvc5Examples.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableMyAspNetUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyAspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyAspNetUsers");
        }
    }
}
