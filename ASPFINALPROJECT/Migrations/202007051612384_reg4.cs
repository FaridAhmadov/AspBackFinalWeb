namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reg4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventSpeakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        speakersID = c.Int(nullable: false),
                        upcomingEventssID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Speakers", t => t.speakersID, cascadeDelete: true)
                .ForeignKey("dbo.UpcomingEventsses", t => t.upcomingEventssID, cascadeDelete: true)
                .Index(t => t.speakersID)
                .Index(t => t.upcomingEventssID);
            
            DropColumn("dbo.UpcomingEventsses", "Selecteds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UpcomingEventsses", "Selecteds", c => c.String());
            DropForeignKey("dbo.EventSpeakers", "upcomingEventssID", "dbo.UpcomingEventsses");
            DropForeignKey("dbo.EventSpeakers", "speakersID", "dbo.Speakers");
            DropIndex("dbo.EventSpeakers", new[] { "upcomingEventssID" });
            DropIndex("dbo.EventSpeakers", new[] { "speakersID" });
            DropTable("dbo.EventSpeakers");
        }
    }
}
