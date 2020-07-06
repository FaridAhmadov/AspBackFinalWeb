namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LatestFromBlogs", "CommentCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LatestFromBlogs", "CommentCount");
        }
    }
}
