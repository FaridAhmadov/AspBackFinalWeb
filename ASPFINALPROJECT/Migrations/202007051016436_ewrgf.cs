namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ewrgf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UpcomingEvents", "startTime", c => c.String());
            AlterColumn("dbo.UpcomingEvents", "EndTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UpcomingEvents", "EndTime", c => c.String(nullable: false));
            AlterColumn("dbo.UpcomingEvents", "startTime", c => c.String(nullable: false));
        }
    }
}
