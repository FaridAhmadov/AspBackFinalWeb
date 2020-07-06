using ASPFINALPROJECT.Areas.Admin.Filters;
using ASPFINALPROJECT.DAL;
using ASPFINALPROJECT.Models;
using ASPFINALPROJECT.VWmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ASPFINALPROJECT.Areas.Admin.Controllers
{
    [SessionFilter]
    public class EventPController : Controller
    {
        ConnectThat db = new ConnectThat();

        // GET: Admin/EventP
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EventDash()
        {

                ViewModels viewModels = new ViewModels();
            viewModels.upcomingEvents = db.upcomingEvents.ToList();
            viewModels.publishers = db.publishers.ToList();
            viewModels.eventSpeakers = db.eventSpeakers.ToList();
            viewModels.speakers = db.speakers.ToList();

            return View(viewModels);

           
        }

        public ActionResult EventCreate()
        {
            ViewBag.Speakers = db.speakers.ToList();

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EventCreate(UpcomingEventss UE)
        {

                if (UE.ImageUpload != null && UE.ImageUpload.ContentType != "image/jpeg" && UE.ImageUpload.ContentType != "image/png" && UE.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (UE.ImageUpload != null && UE.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (UE.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(UE);
                    }
                    if (ModelState.IsValid)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + UE.ImageUpload.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                        UE.ImageUpload.SaveAs(imagePath);
                        UE.Image = imageName;

                        DateTime start = DateTime.ParseExact(UE.StartsDtp, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        UE.Date = start;

                        db.upcomingEvents.Add(UE);
                        db.SaveChanges();

                    foreach (var item in UE.SelectedSpeakers)
                    {
                        EventSpeaker eventss = new EventSpeaker();
                        eventss.upcomingEventssID = UE.Id;
                        eventss.speakersID = item;
                        db.eventSpeakers.Add(eventss);
                    }

                    db.SaveChanges();
                     }
                    else
                    {

                        return View(UE);

                    }
                }
    
            return RedirectToAction("EventDash", "EventP");
        }



        public ActionResult EventUpdate(int Id)
        {
            UpcomingEventss abc = db.upcomingEvents.Find(Id);
            ViewBag.Speakers = db.speakers.ToList();

            abc.StartsDtp = abc.Date.ToString("dd.MM.yyyy");
            return View(abc);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult EventUpdate(UpcomingEventss UEE)
        {
            string OldImageName = UEE.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);

          
                if (UEE.ImageUpload != null && UEE.ImageUpload.ContentType != "image/jpeg" && UEE.ImageUpload.ContentType != "image/png" && UEE.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (UEE.ImageUpload != null && UEE.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {

                    if (ModelState.IsValid)
                    {
                        if (UEE.ImageUpload != null)
                        {
                            string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + UEE.ImageUpload.FileName;
                            string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                            UEE.ImageUpload.SaveAs(imagePath);
                            System.IO.File.Delete(OldimagePath);
                            UEE.Image = imageName;


                        }
                        else
                        {
                            UEE.Image = OldImageName;
                        }
                    }

                    else
                    {
                        return View(UEE);

                    }
                }


            DateTime start = DateTime.ParseExact(UEE.StartsDtp, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            UEE.Date = start;
            db.Entry(UEE).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EventDash", "EventP");
        }

        public ActionResult EventDelete(int Id)
        {
            UpcomingEventss abc = db.upcomingEvents.Find(Id);
            db.upcomingEvents.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("EventDash", "EventP");
        }
    }
}