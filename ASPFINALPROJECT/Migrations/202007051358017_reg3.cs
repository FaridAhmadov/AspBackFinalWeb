namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reg3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LatestFromBlogs", "Publishers_Id", "dbo.Publishers");
            DropForeignKey("dbo.LatestFromBlogs", "Users_Id", "dbo.Users");
            DropIndex("dbo.LatestFromBlogs", new[] { "Publishers_Id" });
            DropIndex("dbo.LatestFromBlogs", new[] { "Users_Id" });
            DropColumn("dbo.LatestFromBlogs", "Publishers_Id");
            DropColumn("dbo.LatestFromBlogs", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LatestFromBlogs", "Users_Id", c => c.Int());
            AddColumn("dbo.LatestFromBlogs", "Publishers_Id", c => c.Int());
            CreateIndex("dbo.LatestFromBlogs", "Users_Id");
            CreateIndex("dbo.LatestFromBlogs", "Publishers_Id");
            AddForeignKey("dbo.LatestFromBlogs", "Users_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.LatestFromBlogs", "Publishers_Id", "dbo.Publishers", "Id");
        }
    }
}
