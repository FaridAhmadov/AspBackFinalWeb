using ASPFINALPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ASPFINALPROJECT.DAL
{
    public class ConnectThat:DbContext
    {
        public ConnectThat() : base("ConnectMe")
        {
           
        }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Courses> courses { get; set; }
        public DbSet<HomeInfoSection> homeInfoSections { get; set; }
        public DbSet<LatestFromBlog> latestFromBlogs { get; set; }
        public DbSet<MeetOurTeachers> meetOurTeachers { get; set; }
        public DbSet<Messages> messages { get; set; }
        public DbSet<NoticeBoard> noticeBoards { get; set; }
        public DbSet<Slider> slider { get; set; }
        public DbSet<Speakers> speakers { get; set; }
        public DbSet<StudentSingleComment> studentSingleComments { get; set; }
        public DbSet<UpcomingEventss> upcomingEvents{ get; set; }
        public DbSet<WelcomeToEduHome> welcomeToEduHomes { get; set; }
        public DbSet<Publishers> publishers { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Subscribers> subscribers { get; set; }
        public DbSet<Pagesedit> pagesedits { get; set; }
        public DbSet<EventSpeaker> eventSpeakers { get; set; }

        public DbSet<Video> videoss { get; set; }

    }
}