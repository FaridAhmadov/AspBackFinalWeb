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
    public class AboutController : Controller
    {
        // GET: About
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            ViewBag.AboutBack = db.pagesedits.Where(t => t.Page == "About").ToList();


            ViewModels viewModels = new ViewModels();
            viewModels.welcomeToEduHomes = db.welcomeToEduHomes.ToList();
            viewModels.noticeBoards = db.noticeBoards.ToList();
            viewModels.videos = db.videoss.ToList();
            viewModels.studentSingleComments = db.studentSingleComments.ToList();
            viewModels.meetOurTeachers = db.meetOurTeachers.Take(4).ToList();

            ViewBag.VideoU = db.videoss.ToList();

            return View(viewModels);

        }


        [HttpPost]
        public ActionResult Subscribe(Subscribers sss)
        {

            db.subscribers.Add(sss);
            db.SaveChanges();

            return RedirectToAction("Index", "About");
        }
    }


}