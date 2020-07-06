using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class Courses
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime Starts { get; set; }

        [NotMapped]
        public string  StartsDtp{ get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int ClassDuration { get; set; }

        [Required]
        [MaxLength(50)]
        public string SkillLevel { get; set; }

        [Required]
        [MaxLength(50)]
        public string Language { get; set; }

        [Required]
        public int Students { get; set; }

        [Required]
        [MaxLength(30)]
        public string Assesments { get; set; }

        [Required]
        public decimal Fee { get; set; }

    }
}