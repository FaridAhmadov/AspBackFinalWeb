namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UpcomingEvents", "SelectedSpeakers", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UpcomingEvents", "SelectedSpeakers");
        }
    }
}
