using ASPFINALPROJECT.Areas.Admin.Filters;
using ASPFINALPROJECT.DAL;
using ASPFINALPROJECT.Models;
using ASPFINALPROJECT.VWmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFINALPROJECT.Areas.Admin.Controllers
{
    [SessionFilter]

    public class ContactPController : Controller
    {
        // GET: Admin/ContactP
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dash()
        {
            if (Session["LoggedIn"] != null)
            {
                ViewModels viewModels = new ViewModels();
                viewModels.contacts = db.contacts.ToList();
                return View(viewModels);
            }
            else
            {
                return RedirectToAction("myLogin", "LoginReg");

            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contactt)
        {

                if (ModelState.IsValid)
                {
                    db.contacts.Add(contactt);
                    db.SaveChanges();


                }
                else
                {
                    return View(contactt);
                }
          
            return RedirectToAction("Dash", "ContactP");
        }



        public ActionResult Update(int Id)
        {
            Contact abc = db.contacts.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult Update(Contact contacttt)
        {

                if (ModelState.IsValid)
                {

                    db.Entry(contacttt).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    return View(contacttt);
                }

            return RedirectToAction("Dash", "ContactP");
        }

        public ActionResult Delete(int Id)
        {
            Contact abc = db.contacts.Find(Id);
            db.contacts.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("Dash", "ContactP");
        }
    }
}