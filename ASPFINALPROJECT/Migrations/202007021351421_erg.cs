namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UpcomingEvents", "Speaker1", "dbo.Speakers");
            DropIndex("dbo.UpcomingEvents", new[] { "Speaker1" });
            RenameColumn(table: "dbo.UpcomingEvents", name: "Speaker1", newName: "speakers_Id");
            AddColumn("dbo.UpcomingEvents", "speakersId", c => c.String());
            AlterColumn("dbo.UpcomingEvents", "speakers_Id", c => c.Int());
            CreateIndex("dbo.UpcomingEvents", "speakers_Id");
            AddForeignKey("dbo.UpcomingEvents", "speakers_Id", "dbo.Speakers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpcomingEvents", "speakers_Id", "dbo.Speakers");
            DropIndex("dbo.UpcomingEvents", new[] { "speakers_Id" });
            AlterColumn("dbo.UpcomingEvents", "speakers_Id", c => c.Int(nullable: false));
            DropColumn("dbo.UpcomingEvents", "speakersId");
            RenameColumn(table: "dbo.UpcomingEvents", name: "speakers_Id", newName: "Speaker1");
            CreateIndex("dbo.UpcomingEvents", "Speaker1");
            AddForeignKey("dbo.UpcomingEvents", "Speaker1", "dbo.Speakers", "Id", cascadeDelete: true);
        }
    }
}
