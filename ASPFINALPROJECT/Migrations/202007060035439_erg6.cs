namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erg6 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Messages", "PostPageMsId");
            AddForeignKey("dbo.Messages", "PostPageMsId", "dbo.LatestFromBlogs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "PostPageMsId", "dbo.LatestFromBlogs");
            DropIndex("dbo.Messages", new[] { "PostPageMsId" });
        }
    }
}
