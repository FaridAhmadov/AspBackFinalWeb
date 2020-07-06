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

    public class CoursesController : Controller
    {
        // GET: Courses
        ConnectThat db = new ConnectThat();
        public ActionResult Index( string searchText)
        {
            ViewBag.CoBack = db.pagesedits.Where(t => t.Page == "Courses").ToList();
            //List<Courses> abc = db.courses.ToList();
            ViewModels viewModels = new ViewModels();

            if (db.courses.FirstOrDefault(l => l.Title.Contains(searchText)) != null)
            {
                viewModels.courses = db.courses.Where(l => l.Title.Contains(searchText)).ToList();
            }
            else
            {
                viewModels.courses = db.courses.ToList();

            }
            return View(viewModels);
        }


        [HttpPost]
        public ActionResult Subscribe(Subscribers sss)
        {

            db.subscribers.Add(sss);
            db.SaveChanges();

            return RedirectToAction("Index", "Courses");
        }

        [HttpPost]
        public ActionResult Create(Messages mmm)
        {

            db.messages.Add(mmm);
            db.SaveChanges();

            return RedirectToAction("Index", "Courses");
        }

        public ActionResult Details(int id)
        {
            ViewBag.CoBack = db.pagesedits.Where(t => t.Page == "Courses").ToList();

            Courses findDetails = db.courses.Find(id);

            return View(findDetails);
        }
    }
}