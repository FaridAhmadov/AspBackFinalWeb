namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _34tr34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LatestFromBlogs", "usersID", c => c.Int(nullable: false));
            AddColumn("dbo.LatestFromBlogs", "publishersID", c => c.Int(nullable: false));
            CreateIndex("dbo.LatestFromBlogs", "usersID");
            CreateIndex("dbo.LatestFromBlogs", "publishersID");
            AddForeignKey("dbo.LatestFromBlogs", "publishersID", "dbo.Publishers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LatestFromBlogs", "usersID", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.LatestFromBlogs", "ManageStatusIdn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LatestFromBlogs", "ManageStatusIdn", c => c.Int(nullable: false));
            DropForeignKey("dbo.LatestFromBlogs", "usersID", "dbo.Users");
            DropForeignKey("dbo.LatestFromBlogs", "publishersID", "dbo.Publishers");
            DropIndex("dbo.LatestFromBlogs", new[] { "publishersID" });
            DropIndex("dbo.LatestFromBlogs", new[] { "usersID" });
            DropColumn("dbo.LatestFromBlogs", "publishersID");
            DropColumn("dbo.LatestFromBlogs", "usersID");
        }
    }
}
