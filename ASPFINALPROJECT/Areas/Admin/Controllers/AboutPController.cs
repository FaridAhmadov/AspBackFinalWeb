using ASPFINALPROJECT.Areas.Admin.Filters;
using ASPFINALPROJECT.Controllers;
using ASPFINALPROJECT.DAL;
using ASPFINALPROJECT.Models;
using ASPFINALPROJECT.VWmodels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFINALPROJECT.Areas.Admin.Controllers
{
    [SessionFilter]

    public class AboutPController : Controller
    {
        // GET: Admin/AboutP
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.welcomeToEduHomes = db.welcomeToEduHomes.ToList();
            return View(viewModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WelcomeToEduHome WTEH)
        {
           
                if (WTEH.ImageUpload != null && WTEH.ImageUpload.ContentType != "image/jpeg" && WTEH.ImageUpload.ContentType != "image/png" && WTEH.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (WTEH.ImageUpload != null && WTEH.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (ModelState.IsValid)
                    {

                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + WTEH.ImageUpload.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                        WTEH.ImageUpload.SaveAs(imagePath);
                        WTEH.Image = imageName;

                        db.welcomeToEduHomes.Add(WTEH);
                        db.SaveChanges();


                    }
                    else
                    {
                        return View(WTEH);
                    }
                }
   
            return RedirectToAction("Dash", "AboutP");
        }



        public ActionResult Update(int Id)
        {
            WelcomeToEduHome abc = db.welcomeToEduHomes.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult Update(WelcomeToEduHome WtehU)
        {
            string OldImageName = WtehU.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);

          
            if (WtehU.ImageUpload != null && WtehU.ImageUpload.ContentType != "image/jpeg" && WtehU.ImageUpload.ContentType != "image/png" && WtehU.ImageUpload.ContentType != "image/gif")
            {
                return Content("Please upload img/png or gif");
            }
            if (WtehU.ImageUpload != null && WtehU.ImageUpload.ContentLength > 1048576)
            {
                return Content("You can only upload max 1mb");
            }

            else
            {
                if (ModelState.IsValid)
                {
                    if (WtehU.ImageUpload != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + WtehU.ImageUpload.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                        WtehU.ImageUpload.SaveAs(imagePath);
                        System.IO.File.Delete(OldimagePath);
                        WtehU.Image = imageName;

                      
                    }
                    else
                    {
                        WtehU.Image = OldImageName;
                    }

                }
                else
                {
                    return View(WtehU);
                }
            }
            db.Entry(WtehU).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dash", "AboutP");
        }

        public ActionResult Delete(int Id)
        {
            WelcomeToEduHome abc = db.welcomeToEduHomes.Find(Id);
            db.welcomeToEduHomes.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("Dash", "AboutP");
        }
    }
}