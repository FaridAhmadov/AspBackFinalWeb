using ASPFINALPROJECT.DAL;
using ASPFINALPROJECT.Models;
using ASPFINALPROJECT.VWmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFINALPROJECT.Controllers
{
    public class HomeController : Controller
    {
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            //Response.Cache.SetNoStore();

            //if (Session["LoggedIn"] == null)
            //{
            //    return RedirectToAction("myLogin", "LoginReg");
            //}
            ViewModels viewModels = new ViewModels();
            viewModels.slider = db.slider.ToList();
            viewModels.homeInfoSections = db.homeInfoSections.ToList();
            viewModels.welcomeToEduHomes = db.welcomeToEduHomes.ToList();
            viewModels.courses = db.courses.Take(3).ToList();
            viewModels.latestFromBlogs = db.latestFromBlogs.Take(3).ToList();
            viewModels.users = db.users.ToList();
            viewModels.upcomingEvents = db.upcomingEvents.ToList();

            viewModels.noticeBoards = db.noticeBoards.ToList();
            viewModels.studentSingleComments = db.studentSingleComments.ToList();
            ViewBag.qqqq = db.subscribers.ToList();

            ViewBag.VideoU = db.videoss.ToList();

            return View(viewModels);

        }
        [HttpPost]
        public ActionResult Subscribe(Subscribers sss)
        {

            db.subscribers.Add(sss);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}