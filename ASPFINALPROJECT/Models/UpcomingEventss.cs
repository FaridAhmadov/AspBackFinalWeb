using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class UpcomingEventss
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [NotMapped]
        public string StartsDtp { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string startTime { get; set; }


        public string EndTime { get; set; }

        [Required]
        public string ContentText { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public int publishersID { get; set; }

        public List<EventSpeaker> eventSpeakers { get; set; }
        [NotMapped]
        public int[] SelectedSpeakers { get; set; }

        public Publishers publishers { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public string Image { get; set; }
    }
}