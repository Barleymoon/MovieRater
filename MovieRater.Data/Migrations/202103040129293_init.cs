namespace MovieRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        OwnerId = c.Guid(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        AddedMovie = c.DateTimeOffset(nullable: false, precision: 7),
                        Genre = c.String(),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Score = c.Double(nullable: false),
                        ReviewText = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Movie_MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Movie", t => t.Movie_MovieId)
                .Index(t => t.Movie_MovieId);
            
            
            
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        ShowId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.String(),
                        AddedShow = c.DateTimeOffset(nullable: false, precision: 7),
                        Genre = c.String(),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.ShowId);
            
            
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Review", "Movie_MovieId", "dbo.Movie");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Review", new[] { "Movie_MovieId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Show");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Review");
            DropTable("dbo.Movie");
        }
    }
}
