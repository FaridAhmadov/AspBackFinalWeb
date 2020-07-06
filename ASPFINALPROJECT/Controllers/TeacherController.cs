using ASPFINALPROJECT.DAL;
using ASPFINALPROJECT.Models;
using ASPFINALPROJECT.VWmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ASPFINALPROJECT.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        ConnectThat db = new ConnectThat();
        public ActionResult Index(string searchText)
        {
            ViewBag.TeaBack = db.pagesedits.Where(t => t.Page == "Teacher").ToList();
            ViewModels viewModels = new ViewModels();

            if (db.meetOurTeachers.FirstOrDefault(l => l.Title.Contains(searchText)) != null)
            {
                viewModels.meetOurTeachers = db.meetOurTeachers.Where(l => l.Title.Contains(searchText)).ToList();
            }
            else
            {
                viewModels.meetOurTeachers = db.meetOurTeachers.ToList();

            }
            viewModels.pagesedits = db.pagesedits.ToList();

            return View(viewModels);
        }


        [HttpPost]
        public ActionResult Subscribe(Subscribers sss)
        {

            db.subscribers.Add(sss);
            db.SaveChanges();

            return RedirectToAction("Index", "Teacher");
        }

        public ActionResult Details(int id)
        {
            MeetOurTeachers abc = db.meetOurTeachers.Find(id);
            ViewBag.TeaBack = db.pagesedits.Where(t => t.Page == "Teacher").ToList();

            return View(abc);
        }
    }
}