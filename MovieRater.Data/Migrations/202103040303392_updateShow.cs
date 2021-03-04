namespace MovieRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateShow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "ShowId", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "ShowId");
            AddForeignKey("dbo.Review", "ShowId", "dbo.Show", "ShowId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "ShowId", "dbo.Show");
            DropIndex("dbo.Review", new[] { "ShowId" });
            DropColumn("dbo.Review", "ShowId");
        }
    }
}
