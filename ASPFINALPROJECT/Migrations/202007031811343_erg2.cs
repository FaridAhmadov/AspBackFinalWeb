namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erg2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UpcomingEvents", "SelectedSpeakers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UpcomingEvents", "SelectedSpeakers", c => c.String());
        }
    }
}
