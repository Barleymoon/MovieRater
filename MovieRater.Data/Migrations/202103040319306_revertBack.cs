namespace MovieRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertBack : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            DropIndex("dbo.Review", new[] { "MovieId" });
            RenameColumn(table: "dbo.Review", name: "ShowId", newName: "Show_ShowId");
            RenameIndex(table: "dbo.Review", name: "IX_ShowId", newName: "IX_Show_ShowId");
            AlterColumn("dbo.Review", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "MovieId");
            AddForeignKey("dbo.Review", "MovieId", "dbo.Movie", "MovieId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            DropIndex("dbo.Review", new[] { "MovieId" });
            AlterColumn("dbo.Review", "MovieId", c => c.Int());
            RenameIndex(table: "dbo.Review", name: "IX_Show_ShowId", newName: "IX_ShowId");
            RenameColumn(table: "dbo.Review", name: "Show_ShowId", newName: "ShowId");
            CreateIndex("dbo.Review", "MovieId");
            AddForeignKey("dbo.Review", "MovieId", "dbo.Movie", "MovieId");
        }
    }
}
