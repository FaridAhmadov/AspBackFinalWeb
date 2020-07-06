using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class Users
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Fullname { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        [MaxLength(30)]
        [Required]
        public string Email { get; set; }

        [MinLength(8)]
        [Required]
        public string Password { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public string Image { get; set; }
        public List<LatestFromBlog> LatestFromBlog { get; set; }
    }
}