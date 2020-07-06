namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erg5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UpcomingEvents", "startTime", c => c.String(nullable: false));
            AlterColumn("dbo.UpcomingEvents", "EndTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UpcomingEvents", "EndTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.UpcomingEvents", "startTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
