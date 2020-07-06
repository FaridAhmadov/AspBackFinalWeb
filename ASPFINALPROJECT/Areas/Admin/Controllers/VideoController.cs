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
    public class VideoController : Controller
    {
        // GET: Admin/Video
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VideoDash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.videos = db.videoss.ToList();
            return View(viewModels);
        }

        public ActionResult VideoCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult VideoCreate(Video videoo)
        {

                if (videoo.ImageUpload != null && videoo.ImageUpload.ContentType != "image/jpeg" && videoo.ImageUpload.ContentType != "image/png" && videoo.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (videoo.ImageUpload != null && videoo.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (videoo.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(videoo);
                    }
                    if (ModelState.IsValid)
                    {

                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + videoo.ImageUpload.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                        videoo.ImageUpload.SaveAs(imagePath);
                        videoo.Image = imageName;

                        db.videoss.Add(videoo);
                        db.SaveChanges();


                    }
                    else
                    {
                        return View(videoo);
                    }

                }

            return RedirectToAction("VideoDash", "Video");
        }



        public ActionResult VideoUpdate(int Id)
        {
            Video abc = db.videoss.Find(Id);

            return View(abc);
        }


        [HttpPost]
        [ValidateInput(false)]

        public ActionResult VideoUpdate(Video videooo)
        {
            string OldImageName = videooo.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);


                if (videooo.ImageUpload != null && videooo.ImageUpload.ContentType != "image/jpeg" && videooo.ImageUpload.ContentType != "image/png" && videooo.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (videooo.ImageUpload != null && videooo.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (ModelState.IsValid)
                    {
                        if (videooo.ImageUpload != null)
                        {
                            string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + videooo.ImageUpload.FileName;
                            string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                            videooo.ImageUpload.SaveAs(imagePath);
                            System.IO.File.Delete(OldimagePath);
                            videooo.Image = imageName;


                        }
                        else
                        {
                            videooo.Image = OldImageName;
                        }

                    }
                    else
                    {
                        return View(videooo);
                    }
                }
          

            db.Entry(videooo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("VideoDash", "Video");
        }

        public ActionResult VideoDelete(int Id)
        {
            Video abc = db.videoss.Find(Id);
            db.videoss.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("VideoDash", "Video");
        }
    }
}