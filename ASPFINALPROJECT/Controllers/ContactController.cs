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
    public class ContactController : Controller
    {
        // GET: Contact
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            ViewBag.ConBack = db.pagesedits.Where(t => t.Page == "Contact").ToList();
            ViewBag.contact = db.contacts.Find(1);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Messages mmm)
        {
           
                db.messages.Add(mmm);
                db.SaveChanges();
     
                return RedirectToAction("Index","Contact");
        }


        [HttpPost]
        public ActionResult Subscribe(Subscribers sss)
        {

            db.subscribers.Add(sss);
            db.SaveChanges();

            return RedirectToAction("Index", "Contact");
        }

    }
}