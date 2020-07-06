namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weg1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LatestFromBlogs", "usersID", c => c.Int(nullable: false));
            CreateIndex("dbo.LatestFromBlogs", "usersID");
            AddForeignKey("dbo.LatestFromBlogs", "usersID", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.LatestFromBlogs", "ManageStatusIdn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LatestFromBlogs", "ManageStatusIdn", c => c.Int(nullable: false));
            DropForeignKey("dbo.LatestFromBlogs", "usersID", "dbo.Users");
            DropIndex("dbo.LatestFromBlogs", new[] { "usersID" });
            DropColumn("dbo.LatestFromBlogs", "usersID");
        }
    }
}
