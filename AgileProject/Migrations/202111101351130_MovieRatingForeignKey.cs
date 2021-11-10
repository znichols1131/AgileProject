namespace AgileProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieRatingForeignKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Ratings");
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 240),
                        Description = c.String(nullable: false, maxLength: 240),
                    })
                .PrimaryKey(t => t.MovieId);
            
            AlterColumn("dbo.Ratings", "RatingId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Ratings", "RatingId");
            CreateIndex("dbo.Ratings", "RatingId");
            AddForeignKey("dbo.Ratings", "RatingId", "dbo.Movies", "MovieId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "RatingId", "dbo.Movies");
            DropIndex("dbo.Ratings", new[] { "RatingId" });
            DropPrimaryKey("dbo.Ratings");
            AlterColumn("dbo.Ratings", "RatingId", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Movies");
            AddPrimaryKey("dbo.Ratings", "RatingId");
        }
    }
}
