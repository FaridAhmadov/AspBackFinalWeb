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

    public class CoursesPController : Controller
    {
        // GET: Admin/CoursesP
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CoursesDash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.courses = db.courses.ToList();
            return View(viewModels);
        }

        public ActionResult CoursesCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult CoursesCreate(Courses ccoursess)
        {
           
                if (ccoursess.ImageUpload != null && ccoursess.ImageUpload.ContentType != "image/jpeg" && ccoursess.ImageUpload.ContentType != "image/png" && ccoursess.ImageUpload.ContentType != "image/gif")
            {
                return Content("Please upload img/png or gif");
            }
            if (ccoursess.ImageUpload != null && ccoursess.ImageUpload.ContentLength > 1048576)
            {
                return Content("You can only upload max 1mb");
            }

            else
            {
                    if (ccoursess.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(ccoursess);
                    }
                    if (ModelState.IsValid)
                    {

                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + ccoursess.ImageUpload.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                        ccoursess.ImageUpload.SaveAs(imagePath);
                        ccoursess.Image = imageName;

                        DateTime start = DateTime.ParseExact(ccoursess.StartsDtp, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        ccoursess.Starts = start;
                        db.courses.Add(ccoursess);
                        db.SaveChanges();


                    }
                    else
                    {
                        return View(ccoursess);
                    }

            }

           
            return RedirectToAction("CoursesDash", "CoursesP");
        }



        public ActionResult CoursesUpdate(int Id)
        {
            Courses abc = db.courses.Find(Id);

            abc.StartsDtp = abc.Starts.ToString("dd.MM.yyyy");
            return View(abc);
        }


        [HttpPost]
        [ValidateInput(false)]

        public ActionResult CoursesUpdate(Courses coursess)
        {
            string OldImageName = coursess.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);

            
                if (coursess.ImageUpload != null && coursess.ImageUpload.ContentType != "image/jpeg" && coursess.ImageUpload.ContentType != "image/png" && coursess.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (coursess.ImageUpload != null && coursess.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (ModelState.IsValid)
                    {
                        if (coursess.ImageUpload != null)
                        {
                            string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + coursess.ImageUpload.FileName;
                            string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                            coursess.ImageUpload.SaveAs(imagePath);
                            coursess.Image = imageName;


                        }
                        else
                        {
                            coursess.Image = OldImageName;
                        }

                    }
                    else
                    {
                        return View(coursess);
                    }
                }
           
            DateTime start = DateTime.ParseExact(coursess.StartsDtp, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            coursess.Starts = start;
            db.Entry(coursess).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CoursesDash", "CoursesP");
        }

        public ActionResult CoursesDelete(int Id)
        {
            Courses abc = db.courses.Find(Id);
            db.courses.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("CoursesDash", "CoursesP");
        }
    }
}
