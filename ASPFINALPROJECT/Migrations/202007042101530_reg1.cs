namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reg1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeetOurTeachers", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MeetOurTeachers", "Content");
        }
    }
}
