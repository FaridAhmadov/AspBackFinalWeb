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
    public class TeachersPController : Controller
    {
        // GET: Admin/TeachersP
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.meetOurTeachers = db.meetOurTeachers.ToList();
            return View(viewModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MeetOurTeachers MOT)
        {

                if (MOT.ImageUpload != null && MOT.ImageUpload.ContentType != "image/jpeg" && MOT.ImageUpload.ContentType != "image/png" && MOT.ImageUpload.ContentType != "image/gif")
            {
                return Content("Please upload img/png or gif");
            }
            if (MOT.ImageUpload != null && MOT.ImageUpload.ContentLength > 1048576)
            {
                return Content("You can only upload max 1mb");
            }

            else
            {
                    if (MOT.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(MOT);
                    }
                    if (ModelState.IsValid)
                {

                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + MOT.ImageUpload.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                    MOT.ImageUpload.SaveAs(imagePath);
                    MOT.Image = imageName;

                    db.meetOurTeachers.Add(MOT);
                    db.SaveChanges();


                }
                else
                {
                    return View(MOT);
                }
            }


            return RedirectToAction("Dash", "TeachersP");
        }



        public ActionResult Update(int Id)
        {
            MeetOurTeachers abc = db.meetOurTeachers.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult Update(MeetOurTeachers ttc)
        {
            string OldImageName = ttc.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);

            if (Session["LoggedIn"] != null)
            {
                if (ttc.ImageUpload != null && ttc.ImageUpload.ContentType != "image/jpeg" && ttc.ImageUpload.ContentType != "image/png" && ttc.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (ttc.ImageUpload != null && ttc.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (ModelState.IsValid)
                    {
                        if (ttc.ImageUpload != null)
                        {
                            string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + ttc.ImageUpload.FileName;
                            string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                            ttc.ImageUpload.SaveAs(imagePath);
                            System.IO.File.Delete(OldimagePath);
                            ttc.Image = imageName;


                        }
                        else
                        {
                            ttc.Image = OldImageName;
                        }

                    }

                    else
                    {
                        return View(ttc);
                    }
                }
            }
            else
            {
                return RedirectToAction("myLogin", "LoginReg");

            }
            db.Entry(ttc).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dash", "TeachersP");
        }

        public ActionResult Delete(int Id)
        {
            MeetOurTeachers abc = db.meetOurTeachers.Find(Id);
            db.meetOurTeachers.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("Dash", "TeachersP");
        }
    }
}