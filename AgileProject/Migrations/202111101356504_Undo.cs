namespace AgileProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Undo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "RatingId", "dbo.Movies");
            DropIndex("dbo.Ratings", new[] { "RatingId" });
            DropPrimaryKey("dbo.Ratings");
            AddColumn("dbo.Ratings", "Movie_MovieId", c => c.Int());
            AlterColumn("dbo.Ratings", "RatingId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Ratings", "RatingId");
            CreateIndex("dbo.Ratings", "Movie_MovieId");
            AddForeignKey("dbo.Ratings", "Movie_MovieId", "dbo.Movies", "MovieId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.Ratings", new[] { "Movie_MovieId" });
            DropPrimaryKey("dbo.Ratings");
            AlterColumn("dbo.Ratings", "RatingId", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "Movie_MovieId");
            AddPrimaryKey("dbo.Ratings", "RatingId");
            CreateIndex("dbo.Ratings", "RatingId");
            AddForeignKey("dbo.Ratings", "RatingId", "dbo.Movies", "MovieId");
        }
    }
}
