namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rgeg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UpcomingEvents", "startTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.UpcomingEvents", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UpcomingEvents", "EndTime");
            DropColumn("dbo.UpcomingEvents", "startTime");
        }
    }
}
