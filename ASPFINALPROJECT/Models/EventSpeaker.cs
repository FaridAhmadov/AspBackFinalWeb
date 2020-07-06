using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class EventSpeaker
    {
        public int Id { get; set; }

        public int speakersID { get; set; }
        public int upcomingEventssID { get; set; }

        public Speakers speakers { get; set; }
        public UpcomingEventss upcomingEventss { get; set; }
    }
}