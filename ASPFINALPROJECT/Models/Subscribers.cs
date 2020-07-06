using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.Models
{
    public class Subscribers
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

    }
}