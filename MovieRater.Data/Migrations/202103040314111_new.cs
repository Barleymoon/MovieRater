namespace MovieRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Review", "ShowId", "dbo.Show");
            DropIndex("dbo.Review", new[] { "MovieId" });
            DropIndex("dbo.Review", new[] { "ShowId" });
            AlterColumn("dbo.Review", "MovieId", c => c.Int());
            AlterColumn("dbo.Review", "ShowId", c => c.Int());
            CreateIndex("dbo.Review", "MovieId");
            CreateIndex("dbo.Review", "ShowId");
            AddForeignKey("dbo.Review", "MovieId", "dbo.Movie", "MovieId");
            AddForeignKey("dbo.Review", "ShowId", "dbo.Show", "ShowId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "ShowId", "dbo.Show");
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            DropIndex("dbo.Review", new[] { "ShowId" });
            DropIndex("dbo.Review", new[] { "MovieId" });
            AlterColumn("dbo.Review", "ShowId", c => c.Int(nullable: false));
            AlterColumn("dbo.Review", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "ShowId");
            CreateIndex("dbo.Review", "MovieId");
            AddForeignKey("dbo.Review", "ShowId", "dbo.Show", "ShowId", cascadeDelete: true);
            AddForeignKey("dbo.Review", "MovieId", "dbo.Movie", "MovieId", cascadeDelete: true);
        }
    }
}
