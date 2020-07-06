namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UpcomingEvents", "Selecteds", c => c.String());
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventsSpeakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        upcomingEventsId = c.Int(nullable: false),
                        speakersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.UpcomingEvents", "Selecteds");

        }
    }
}
