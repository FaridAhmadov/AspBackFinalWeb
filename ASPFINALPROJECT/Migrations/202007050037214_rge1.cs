namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rge1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Message", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
