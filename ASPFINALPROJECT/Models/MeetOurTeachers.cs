using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class MeetOurTeachers
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(30)]
        public string Status { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(30)]
        public string Degree { get; set; }

        [Required]
        [MaxLength(30)]
        public string Experience { get; set; }

        [Required]
        [MaxLength(150)]
        public string Hobbies { get; set; }

        [Required]
        [MaxLength(150)]
        public string Faculty { get; set; }

        [Required]
        [MaxLength(30)]
        public string Mail { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [MaxLength(30)]
        public string Skype { get; set; }

        [Required]
        public int Language { get; set; }

        [Required]
        public int TeamLeader { get; set; }

        [Required]
        public int Design { get; set; }

        [Required]
        public int Innovation { get; set; }

        [Required]
        public int Development { get; set; }

        [Required]
        public int Communication { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public string Image { get; set; }
    }
}