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
    public class StudentComController : Controller
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
            viewModels.studentSingleComments = db.studentSingleComments.ToList();
            return View(viewModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentSingleComment SSC)
        {

                if (SSC.ImageUpload != null && SSC.ImageUpload.ContentType != "image/jpeg" && SSC.ImageUpload.ContentType != "image/png" && SSC.ImageUpload.ContentType != "image/gif")
            {
                return Content("Please upload img/png or gif");
            }
            if (SSC.ImageUpload != null && SSC.ImageUpload.ContentLength > 1048576)
            {
                return Content("You can only upload max 1mb");
            }

            else
            {
                    if (SSC.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(SSC);
                    }
                    if (ModelState.IsValid)
                {

                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + SSC.ImageUpload.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                    SSC.ImageUpload.SaveAs(imagePath);
                    SSC.Image = imageName;

                    db.studentSingleComments.Add(SSC);
                    db.SaveChanges();


                }
                else
                {
                    return View(SSC);
                }
            }

            return RedirectToAction("Dash", "StudentCom");
        }



        public ActionResult Update(int Id)
        {
            StudentSingleComment abc = db.studentSingleComments.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult Update(StudentSingleComment SSCC)
        {
            string OldImageName = SSCC.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);

                if (SSCC.ImageUpload != null && SSCC.ImageUpload.ContentType != "image/jpeg" && SSCC.ImageUpload.ContentType != "image/png" && SSCC.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (SSCC.ImageUpload != null && SSCC.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (ModelState.IsValid)
                    {
                        if (SSCC.ImageUpload != null)
                        {
                            string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + SSCC.ImageUpload.FileName;
                            string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                            SSCC.ImageUpload.SaveAs(imagePath);
                        System.IO.File.Delete(OldimagePath);
                            SSCC.Image = imageName;


                        }
                        else
                        {
                            SSCC.Image = OldImageName;
                        }

                    }

                    else
                    {
                        return View(SSCC);
                    }
                }
          
                db.Entry(SSCC).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dash", "StudentCom");
        }

        public ActionResult Delete(int Id)
        {
            StudentSingleComment abc = db.studentSingleComments.Find(Id);
            db.studentSingleComments.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("Dash", "StudentCom");
        }
    }
}