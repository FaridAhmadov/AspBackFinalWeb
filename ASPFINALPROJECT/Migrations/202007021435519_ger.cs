namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ger : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UpcomingEvents", new[] { "speakers_Id" });
            AddColumn("dbo.UpcomingEvents", "publishersID", c => c.Int(nullable: false));
            CreateIndex("dbo.UpcomingEvents", "publishersID");
            CreateIndex("dbo.UpcomingEvents", "Speakers_Id");
            AddForeignKey("dbo.UpcomingEvents", "publishersID", "dbo.Publishers", "Id", cascadeDelete: true);
            DropColumn("dbo.UpcomingEvents", "speakersId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UpcomingEvents", "speakersId", c => c.String());
            DropForeignKey("dbo.UpcomingEvents", "publishersID", "dbo.Publishers");
            DropIndex("dbo.UpcomingEvents", new[] { "Speakers_Id" });
            DropIndex("dbo.UpcomingEvents", new[] { "publishersID" });
            DropColumn("dbo.UpcomingEvents", "publishersID");
            CreateIndex("dbo.UpcomingEvents", "speakers_Id");
        }
    }
}
