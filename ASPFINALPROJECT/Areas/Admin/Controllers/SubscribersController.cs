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
    public class SubscribersController : Controller
    {
        ConnectThat db = new ConnectThat();
        // GET: Admin/Subscribers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.subscribers = db.subscribers.ToList();
            return View(viewModels);
        }

        public ActionResult Delete(int Id)
        {
            Subscribers abc = db.subscribers.Find(Id);
            db.subscribers.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("Dash", "Subscribers");
        }

    }
}