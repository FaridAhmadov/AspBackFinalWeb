using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class WelcomeToEduHome
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string ContentText { get; set; }

        [Required]
        public string Activty { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public string Image { get; set; }
    }
}