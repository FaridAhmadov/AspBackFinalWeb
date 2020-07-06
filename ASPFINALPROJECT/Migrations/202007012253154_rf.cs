namespace ASPFINALPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Address = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                        Image = c.String(),
                        Starts = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        ClassDuration = c.Int(nullable: false),
                        SkillLevel = c.String(nullable: false, maxLength: 50),
                        Language = c.String(nullable: false, maxLength: 50),
                        Students = c.Int(nullable: false),
                        Assesments = c.String(nullable: false, maxLength: 30),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeInfoSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Subtitle = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LatestFromBlogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        ManageStatus = c.String(),
                        ManageStatusIdn = c.Int(nullable: false),
                        ContentText = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeetOurTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Status = c.String(nullable: false, maxLength: 30),
                        Degree = c.String(nullable: false, maxLength: 30),
                        Experience = c.String(nullable: false, maxLength: 30),
                        Hobbies = c.String(nullable: false, maxLength: 150),
                        Faculty = c.String(nullable: false, maxLength: 150),
                        Mail = c.String(nullable: false, maxLength: 30),
                        Number = c.Int(nullable: false),
                        Skype = c.String(nullable: false, maxLength: 30),
                        Language = c.Int(nullable: false),
                        TeamLeader = c.Int(nullable: false),
                        Design = c.Int(nullable: false),
                        Innovation = c.Int(nullable: false),
                        Development = c.Int(nullable: false),
                        Communication = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubMessage = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        Subject = c.String(nullable: false, maxLength: 50),
                        Message = c.String(nullable: false, maxLength: 250),
                        BlogPostmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LatestFromBlogs", t => t.BlogPostmId, cascadeDelete: true)
                .Index(t => t.BlogPostmId);
            
            CreateTable(
                "dbo.NoticeBoards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ContentText = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Subtitle = c.String(nullable: false, maxLength: 200),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ProfessionStatus = c.String(nullable: false, maxLength: 50),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UpcomingEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        ContentText = c.String(nullable: false, maxLength: 250),
                        Location = c.String(nullable: false, maxLength: 100),
                        Speaker1 = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Speakers", t => t.Speaker1, cascadeDelete: true)
                .Index(t => t.Speaker1);
            
            CreateTable(
                "dbo.StudentSingleComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        ContentText = c.String(nullable: false, maxLength: 250),
                        Status = c.String(nullable: false, maxLength: 50),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WelcomeToEduHomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ContentText = c.String(nullable: false, maxLength: 500),
                        Activty = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpcomingEvents", "Speaker1", "dbo.Speakers");
            DropForeignKey("dbo.Messages", "BlogPostmId", "dbo.LatestFromBlogs");
            DropIndex("dbo.UpcomingEvents", new[] { "Speaker1" });
            DropIndex("dbo.Messages", new[] { "BlogPostmId" });
            DropTable("dbo.WelcomeToEduHomes");
            DropTable("dbo.Users");
            DropTable("dbo.StudentSingleComments");
            DropTable("dbo.UpcomingEvents");
            DropTable("dbo.Speakers");
            DropTable("dbo.Sliders");
            DropTable("dbo.Publishers");
            DropTable("dbo.NoticeBoards");
            DropTable("dbo.Messages");
            DropTable("dbo.MeetOurTeachers");
            DropTable("dbo.LatestFromBlogs");
            DropTable("dbo.HomeInfoSections");
            DropTable("dbo.Courses");
            DropTable("dbo.Contacts");
        }
    }
}
