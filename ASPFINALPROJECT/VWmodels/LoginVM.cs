﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.VWmodels
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

    }
}