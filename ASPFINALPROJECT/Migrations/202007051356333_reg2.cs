namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reg2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LatestFromBlogs", "publishersID", "dbo.Publishers");
            DropForeignKey("dbo.LatestFromBlogs", "usersID", "dbo.Users");
            DropIndex("dbo.LatestFromBlogs", new[] { "usersID" });
            DropIndex("dbo.LatestFromBlogs", new[] { "publishersID" });
            RenameColumn(table: "dbo.LatestFromBlogs", name: "publishersID", newName: "Publishers_Id");
            RenameColumn(table: "dbo.LatestFromBlogs", name: "usersID", newName: "Users_Id");
            AddColumn("dbo.LatestFromBlogs", "ManageStatusIdn", c => c.Int(nullable: false));
            AlterColumn("dbo.LatestFromBlogs", "Users_Id", c => c.Int());
            AlterColumn("dbo.LatestFromBlogs", "Publishers_Id", c => c.Int());
            CreateIndex("dbo.LatestFromBlogs", "Publishers_Id");
            CreateIndex("dbo.LatestFromBlogs", "Users_Id");
            AddForeignKey("dbo.LatestFromBlogs", "Publishers_Id", "dbo.Publishers", "Id");
            AddForeignKey("dbo.LatestFromBlogs", "Users_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LatestFromBlogs", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.LatestFromBlogs", "Publishers_Id", "dbo.Publishers");
            DropIndex("dbo.LatestFromBlogs", new[] { "Users_Id" });
            DropIndex("dbo.LatestFromBlogs", new[] { "Publishers_Id" });
            AlterColumn("dbo.LatestFromBlogs", "Publishers_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.LatestFromBlogs", "Users_Id", c => c.Int(nullable: false));
            DropColumn("dbo.LatestFromBlogs", "ManageStatusIdn");
            RenameColumn(table: "dbo.LatestFromBlogs", name: "Users_Id", newName: "usersID");
            RenameColumn(table: "dbo.LatestFromBlogs", name: "Publishers_Id", newName: "publishersID");
            CreateIndex("dbo.LatestFromBlogs", "publishersID");
            CreateIndex("dbo.LatestFromBlogs", "usersID");
            AddForeignKey("dbo.LatestFromBlogs", "usersID", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LatestFromBlogs", "publishersID", "dbo.Publishers", "Id", cascadeDelete: true);
        }
    }
}
