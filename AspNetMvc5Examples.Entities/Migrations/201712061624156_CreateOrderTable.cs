namespace AspNetMvc5Examples.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOrderTable : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);

            this.AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            this.AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            this.DropTable("dbo.Order");
        }
    }
}
