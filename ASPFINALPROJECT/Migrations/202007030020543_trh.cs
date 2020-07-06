namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UpcomingEvents", "Speakers_Id", "dbo.Speakers");
            DropIndex("dbo.UpcomingEvents", new[] { "Speakers_Id" });
            DropColumn("dbo.UpcomingEvents", "Speakers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UpcomingEvents", "Speakers_Id", c => c.Int());
            CreateIndex("dbo.UpcomingEvents", "Speakers_Id");
            AddForeignKey("dbo.UpcomingEvents", "Speakers_Id", "dbo.Speakers", "Id");
        }
    }
}
