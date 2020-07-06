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

namespace ASPFINALPROJECT.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        ConnectThat db = new ConnectThat();
        public ActionResult Index(string searchText , int page = 1)
        {
            ViewBag.Blog = db.pagesedits.Where(t => t.Page == "Blog").ToList();
            ViewBag.CM = db.messages.ToList();
            ViewModels viewModels = new ViewModels();

            if (db.latestFromBlogs.FirstOrDefault(l => l.Title.Contains(searchText)) != null)
            {
                viewModels.latestFromBlogs = db.latestFromBlogs.Where(l => l.Title.Contains(searchText)).ToList();
            }
            else
            {
                viewModels.latestFromBlogs = db.latestFromBlogs.OrderByDescending(o=>o.Id).Skip((page-1)*4).Take(4).ToList();
                viewModels.pageCount = Convert.ToInt32(Math.Ceiling(db.latestFromBlogs.Count() / 4.0));
                viewModels.CurrentPage = page;
            }
            viewModels.users = db.users.ToList();

            return View(viewModels);
        }

        [HttpPost]
        public ActionResult Subscribe(Subscribers sss)
        {

            db.subscribers.Add(sss);
            db.SaveChanges();

            return RedirectToAction("Index", "Blog");
        }

        [HttpPost]
        public ActionResult Create(Messages mmm)
        {

            db.messages.Add(mmm);
            db.SaveChanges();

            return RedirectToAction("Index","Blog");
        }

        public ActionResult Details(int Id)
        {
            ViewBag.Blog = db.pagesedits.Where(t => t.Page == "Blog").ToList();
            ViewBag.LSB = db.latestFromBlogs.Take(3).ToList();

            LatestFromBlog bblog = db.latestFromBlogs.Find(Id);
            ViewBag.aa = db.users.FirstOrDefault(u => u.Id == bblog.usersID);
            return View(bblog);
        }


        [SessionFilterUser]

        public ActionResult UserBlogDash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.latestFromBlogs = db.latestFromBlogs.ToList();
            viewModels.users = db.users.ToList();

            return View(viewModels);
        }

        public ActionResult UserBlogCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult UserBlogCreate(LatestFromBlog LFB)
        {

                if (LFB.ImageUpload != null && LFB.ImageUpload.ContentType != "image/jpeg" && LFB.ImageUpload.ContentType != "image/png" && LFB.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (LFB.ImageUpload != null && LFB.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (LFB.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(LFB);
                    }
                    if (ModelState.IsValid)
                    {
                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + LFB.ImageUpload.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                        LFB.ManageStatus = "User";
                        LFB.usersID = (int)Session["LoggedIdd"];
                        LFB.ImageUpload.SaveAs(imagePath);
                        LFB.Image = imageName;
                        LFB.ManageStatus = "User";
                        LFB.CreatedDate = DateTime.Now;
                        db.latestFromBlogs.Add(LFB);
                        db.SaveChanges();
                    }
                    else
                    {

                        return View(LFB);

                    }
                }
        
            return RedirectToAction("UserBlogDash", "Blog");
        }


        [SessionFilterUser]

        public ActionResult UserBlogUpdate(int Id)
        {
            LatestFromBlog abc = db.latestFromBlogs.Find(Id);
            return View(abc);
        }

        [HttpPost]
        [ValidateInput(false)]
        [SessionFilterUser]

        public ActionResult UserBlogUpdate(LatestFromBlog LFBB)
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

            LFBB.ManageStatus = "User";
            LFBB.usersID = (int)Session["LoggedIdd"];
            LFBB.CreatedDate = DateTime.Now;
            db.Entry(LFBB).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("UserBlogDash", "Blog");
        }

        [SessionFilterUser]

        public ActionResult UserBlogDelete(int Id)
        {
            LatestFromBlog abc = db.latestFromBlogs.Find(Id);
            db.latestFromBlogs.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("UserBlogDash", "Blog");
        }
    }
}