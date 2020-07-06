using ASPFINALPROJECT.Areas.Admin.Filters;
using ASPFINALPROJECT.DAL;
using ASPFINALPROJECT.Models;
using ASPFINALPROJECT.VWmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ASPFINALPROJECT.Areas.Admin.Controllers
{
    [SessionFilter]
    public class MessagesController : Controller
    {
        ConnectThat db = new ConnectThat();

        // GET: Admin/Messages
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Dash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.messages = db.messages.ToList();
            return View(viewModels);
        }


        public ActionResult Update(int Id)
        {
            Messages abc = db.messages.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult Update(Messages mss)
        {


            if (ModelState.IsValid)
            {

                db.Entry(mss).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                return View(mss);
            }

            return RedirectToAction("Dash", "Messages");
        }

        public ActionResult Delete(int Id)
        {
            Messages abc = db.messages.Find(Id);
            db.messages.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("Dash", "Messages");
        }
    }
}