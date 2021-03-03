namespace MovieRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 1000),
                        AddedMovie = c.DateTimeOffset(nullable: false, precision: 7),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        ShowId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Rating = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.ShowId);
            
            AddColumn("dbo.Review", "ReviewText", c => c.String());
            AddColumn("dbo.Review", "Movie_MovieId", c => c.Int());
            CreateIndex("dbo.Review", "Movie_MovieId");
            AddForeignKey("dbo.Review", "Movie_MovieId", "dbo.Movie", "MovieId");
            DropColumn("dbo.Review", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "Text", c => c.String());
            DropForeignKey("dbo.Review", "Movie_MovieId", "dbo.Movie");
            DropIndex("dbo.Review", new[] { "Movie_MovieId" });
            DropColumn("dbo.Review", "Movie_MovieId");
            DropColumn("dbo.Review", "ReviewText");
            DropTable("dbo.Show");
            DropTable("dbo.Movie");
        }
    }
}
