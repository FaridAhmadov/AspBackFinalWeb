namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erg7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UpcomingEventsses", "ContentText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UpcomingEventsses", "ContentText", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
