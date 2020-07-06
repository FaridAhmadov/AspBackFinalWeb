using ASPFINALPROJECT.Areas.Admin.Filters;
using ASPFINALPROJECT.DAL;
using ASPFINALPROJECT.Models;
using ASPFINALPROJECT.VWmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFINALPROJECT.Areas.Admin.Controllers
{
    [SessionFilter]
    public class SpeakersController : Controller
    {
        ConnectThat db = new ConnectThat();
        // GET: Admin/Speakers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.speakers = db.speakers.ToList();
            return View(viewModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Speakers speakerr)
        {

                if (speakerr.ImageUpload != null && speakerr.ImageUpload.ContentType != "image/jpeg" && speakerr.ImageUpload.ContentType != "image/png" && speakerr.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (speakerr.ImageUpload != null && speakerr.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (speakerr.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(speakerr);
                    }
                    if (ModelState.IsValid)
                    {

                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + speakerr.ImageUpload.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                        speakerr.ImageUpload.SaveAs(imagePath);
                        speakerr.Image = imageName;

                        db.speakers.Add(speakerr);
                        db.SaveChanges();


                    }
                    else
                    {
                        return View(speakerr);
                    }
                }

            return RedirectToAction("Dash", "Speakers");
        }



        public ActionResult Update(int Id)
        {
            Speakers abc = db.speakers.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult Update(Speakers speakerss)
        {
            string OldImageName = speakerss.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);

       
                if (speakerss.ImageUpload != null && speakerss.ImageUpload.ContentType != "image/jpeg" && speakerss.ImageUpload.ContentType != "image/png" && speakerss.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (speakerss.ImageUpload != null && speakerss.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (ModelState.IsValid)
                    {
                        if (speakerss.ImageUpload != null)
                        {
                            string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + speakerss.ImageUpload.FileName;
                            string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                            speakerss.ImageUpload.SaveAs(imagePath);
                            
                            speakerss.Image = imageName;


                        }
                        else
                        {
                            speakerss.Image = OldImageName;
                        }

                    }

                    else
                    {
                        return View(speakerss);
                    }
                }
         
            db.Entry(speakerss).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dash", "Speakers");
        }

        public ActionResult Delete(int Id)
        {
            Speakers abc = db.speakers.Find(Id);
            db.speakers.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("Dash", "Speakers");
        }
    }
}
