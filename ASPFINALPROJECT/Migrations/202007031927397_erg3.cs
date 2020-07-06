namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erg3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UpcomingEvents", "Selecteds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UpcomingEvents", "Selecteds");
        }
    }
}
