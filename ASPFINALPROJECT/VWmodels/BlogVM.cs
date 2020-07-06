using ASPFINALPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPFINALPROJECT.VWmodels
{
    public class BlogVM
    {
        public List<LatestFromBlog> latestFromBlogssss { get; set; }
        public List<Users> userss { get; set; }

        public int pageCount { get; set; }
        public int CurrentPage { get; set; }

    }
}