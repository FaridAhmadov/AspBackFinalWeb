using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class StudentSingleComment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(250)]
        public string ContentText { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public string Image { get; set; }
    }
}