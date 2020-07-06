using ASPFINALPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.VWmodels
{
    public class ViewModels
    {
        public List<Contact> contacts { get; set; }
        public List<Courses> courses { get; set; }
        public List<HomeInfoSection> homeInfoSections { get; set; }
        public List<LatestFromBlog> latestFromBlogs { get; set; }
        public List<MeetOurTeachers> meetOurTeachers { get; set; }
        public List<Messages> messages { get; set; }
        public List<NoticeBoard> noticeBoards { get; set; }
        public List<Slider> slider { get; set; }
        public List<Speakers> speakers { get; set; }
        public List<StudentSingleComment> studentSingleComments { get; set; }
        public List<UpcomingEventss> upcomingEvents { get; set; }
        public List<WelcomeToEduHome> welcomeToEduHomes { get; set; }
        public List<Publishers> publishers { get; set; }
        public List<Users> users { get; set; }
        public List<Subscribers> subscribers { get; set; }
        public List<Pagesedit> pagesedits { get; set; }
        public List<Video> videos { get; set; }
        public List<EventSpeaker> eventSpeakers { get; set; }

        public int pageCount { get; set; }
        public int CurrentPage { get; set; }

    }
}