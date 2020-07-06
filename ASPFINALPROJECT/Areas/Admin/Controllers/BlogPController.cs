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
    public class BlogPController : Controller
    {
        // GET: Admin/BlogP
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BlogDash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.latestFromBlogs = db.latestFromBlogs.ToList();
            viewModels.publishers = db.publishers.ToList();
            viewModels.users = db.users.ToList();

            return View(viewModels);
        }

      

        public ActionResult BlogUpdate(int Id)
        {
            LatestFromBlog abc = db.latestFromBlogs.Find(Id);
            return View(abc);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult BlogUpdate(LatestFromBlog LFBB)
        {
            string OldImageName = LFBB.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);


            if (LFBB.ImageUpload != null && LFBB.ImageUpload.ContentType != "image/jpeg" && LFBB.ImageUpload.ContentType != "image/png" && LFBB.ImageUpload.ContentType != "image/gif")
            {
                return Content("Please upload img/png or gif");
            }
            if (LFBB.ImageUpload != null && LFBB.ImageUpload.ContentLength > 1048576)
            {
                return Content("You can only upload max 1mb");
            }

            else
            {

                if (ModelState.IsValid)
                {
                    if (LFBB.ImageUpload != null)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + LFBB.ImageUpload.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                        LFBB.ImageUpload.SaveAs(imagePath);
                        System.IO.File.Delete(OldimagePath);
                        LFBB.Image = imageName;


                    }
                    else
                    {
                        LFBB.Image = OldImageName;
                    }
                }

                else
                {
                    return View(LFBB);

                }
            }

            LatestFromBlog abc = new LatestFromBlog();
            //abc.Image = LFBB.Image;
            //abc.ManageStatus = LFBB.ManageStatus;
            //abc.Title = LFBB.Title;
            //abc.usersID = LFBB.usersID;
            //abc.ContentText = LFBB.ContentText;
            //abc.CommentCount = LFBB.CommentCount;
            LFBB.ManageStatus = "User";
            LFBB.CreatedDate = DateTime.Now;
            db.Entry(LFBB).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("BlogDash", "BlogP");
        }

        public ActionResult BlogDelete(int Id)
        {
            LatestFromBlog abc = db.latestFromBlogs.Find(Id);
            db.latestFromBlogs.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("BlogDash", "BlogP");
        }
    }
}