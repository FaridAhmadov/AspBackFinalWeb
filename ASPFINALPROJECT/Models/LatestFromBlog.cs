using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class LatestFromBlog
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string ManageStatus { get; set; }

        [Required]
        public string ContentText { get; set; }

        public int CommentCount { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public int usersID { get; set; }

        public Users users { get; set; }

        public string Image { get; set; }

    }
}