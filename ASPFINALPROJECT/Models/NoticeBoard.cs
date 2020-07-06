using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class NoticeBoard
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(250)]
        public string ContentText { get; set; }
    }
}