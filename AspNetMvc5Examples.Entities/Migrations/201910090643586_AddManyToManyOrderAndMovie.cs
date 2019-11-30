namespace AspNetMvc5Examples.Entities.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddManyToManyOrderAndMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderMovies",
                c => new
                {
                    Order_Id = c.Int(nullable: false),
                    Movie_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Order_Id, t.Movie_Id })
                .ForeignKey("dbo.Order", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Movie_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.OrderMovies", "Order_Id", "dbo.Order");
            DropIndex("dbo.OrderMovies", new[] { "Movie_Id" });
            DropIndex("dbo.OrderMovies", new[] { "Order_Id" });
            DropTable("dbo.OrderMovies");
        }
    }
}
