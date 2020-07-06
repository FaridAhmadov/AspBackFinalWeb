namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "BlogPostmId", "dbo.LatestFromBlogs");
            DropIndex("dbo.Messages", new[] { "BlogPostmId" });
            AddColumn("dbo.Messages", "PostPageMsId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "Page", c => c.String());
            AlterColumn("dbo.Messages", "Subject", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Messages", "SubMessage");
            DropColumn("dbo.Messages", "BlogPostmId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "BlogPostmId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "SubMessage", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Subject", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Messages", "Page");
            DropColumn("dbo.Messages", "PostPageMsId");
            CreateIndex("dbo.Messages", "BlogPostmId");
            AddForeignKey("dbo.Messages", "BlogPostmId", "dbo.LatestFromBlogs", "Id", cascadeDelete: true);
        }
    }
}
