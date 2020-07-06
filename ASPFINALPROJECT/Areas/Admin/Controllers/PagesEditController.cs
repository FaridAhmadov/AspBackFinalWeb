using ASPFINALPROJECT.Areas.Admin.Filters;
using ASPFINALPROJECT.DAL;
using ASPFINALPROJECT.Models;
using ASPFINALPROJECT.VWmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ASPFINALPROJECT.Areas.Admin.Controllers
{
    [SessionFilter]
    public class PagesEditController : Controller
    {

        ConnectThat db = new ConnectThat();
        // GET: Admin/PagesEdit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PagesDash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.pagesedits = db.pagesedits.ToList();
            return View(viewModels);
        }   

        public ActionResult PagesCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PagesCreate(Pagesedit pagess)
        {

                if (pagess.ImageUpload != null && pagess.ImageUpload.ContentType != "image/jpeg" && pagess.ImageUpload.ContentType != "image/png" && pagess.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (pagess.ImageUpload != null && pagess.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (pagess.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(pagess);
                    }
                    if (ModelState.IsValid)
                    {

                        string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + pagess.ImageUpload.FileName;
                        string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                        pagess.ImageUpload.SaveAs(imagePath);
                        pagess.Image = imageName;

                        db.pagesedits.Add(pagess);
                        db.SaveChanges();


                    }
                    else
                    {
                        return View(pagess);
                    }
                }

            return RedirectToAction("PagesDash", "PagesEdit");
        }



        public ActionResult PagesUpdate(int Id)
        {
            Pagesedit abc = db.pagesedits.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult PagesUpdate(Pagesedit pagesss)
        {
            string OldImageName = pagesss.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);

        
                if (pagesss.ImageUpload != null && pagesss.ImageUpload.ContentType != "image/jpeg" && pagesss.ImageUpload.ContentType != "image/png" && pagesss.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (pagesss.ImageUpload != null && pagesss.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (ModelState.IsValid)
                    {
                        if (pagesss.ImageUpload != null)
                        {
                            string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + pagesss.ImageUpload.FileName;
                            string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                            pagesss.ImageUpload.SaveAs(imagePath);
                            System.IO.File.Delete(OldimagePath);
                            pagesss.Image = imageName;


                        }
                        else
                        {
                            pagesss.Image = OldImageName;
                        }

                    }

                    else
                    {
                        return View(pagesss);
                    }
                }
           
            db.Entry(pagesss).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("PagesDash", "PagesEdit");
        }

        public ActionResult PagesDelete(int Id)
        {
            Pagesedit abc = db.pagesedits.Find(Id);
            db.pagesedits.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("Dash", "Speakers");
        }
    }
}