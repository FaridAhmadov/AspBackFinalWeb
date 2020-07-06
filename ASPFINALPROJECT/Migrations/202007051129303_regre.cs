namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regre : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UpcomingEvents", newName: "UpcomingEventsses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UpcomingEventsses", newName: "UpcomingEvents");
        }
    }
}
