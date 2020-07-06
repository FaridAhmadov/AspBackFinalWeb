namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weg2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "PostPageMsId", "dbo.LatestFromBlogs");
            DropIndex("dbo.Messages", new[] { "PostPageMsId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Messages", "PostPageMsId");
            AddForeignKey("dbo.Messages", "PostPageMsId", "dbo.LatestFromBlogs", "Id", cascadeDelete: true);
        }
    }
}
