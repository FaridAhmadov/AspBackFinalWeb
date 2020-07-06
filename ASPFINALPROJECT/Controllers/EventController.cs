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
    public class EventController : Controller
    {
        // GET: Event
        ConnectThat db = new ConnectThat();
        public ActionResult Index(string searchText)
        {
            ViewBag.Event = db.pagesedits.Where(t => t.Page == "Event").ToList();

            ViewModels viewModels = new ViewModels();
            viewModels.publishers = db.publishers.ToList();

            if (db.upcomingEvents.FirstOrDefault(l => l.Title.Contains(searchText)) != null)
            {
                viewModels.upcomingEvents = db.upcomingEvents.Where(l => l.Title.Contains(searchText)).ToList();
            }
            else
            {
                viewModels.upcomingEvents = db.upcomingEvents.ToList();

            }
            return View(viewModels);
        }

        [HttpPost]
        public ActionResult Subscribe(Subscribers sss)
        {

            db.subscribers.Add(sss);
            db.SaveChanges();

            return RedirectToAction("Index", "Event");
        }

        [HttpPost]
        public ActionResult Create(Messages mmm)
        {

            db.messages.Add(mmm);
            db.SaveChanges();

            return RedirectToAction("Index", "Event");
        }

        public ActionResult Details(int id)
        {
            ViewBag.Event = db.pagesedits.Where(t => t.Page == "Event").ToList();

            ViewBag.upcs = db.upcomingEvents.Include("publishers").Take(3).ToList();

            UpcomingEventss aaaa = db.upcomingEvents.Find(id);
            ViewBag.fs = db.eventSpeakers.Include("speakers").Where(a => a.upcomingEventss.Id == id).ToList();

            return View(aaaa);
        }
    }
}