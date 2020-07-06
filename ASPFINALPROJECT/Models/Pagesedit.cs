using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class Pagesedit
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        [Required]
        public string PageTitle { get; set; }

        [Required]
        public string Page { get; set; }

    }
}