using ASPFINALPROJECT.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFINALPROJECT.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [SessionFilter]
        public ActionResult Index()
        {  
            return View();
        }
      

    }
}