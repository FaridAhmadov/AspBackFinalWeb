using ASPFINALPROJECT.Areas.Admin.Filters;
using ASPFINALPROJECT.DAL;
using ASPFINALPROJECT.Models;
using ASPFINALPROJECT.VWmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ASPFINALPROJECT.Areas.Admin.Controllers
{
    public class LoginRegController : Controller
    {
        // GET: Admin/LoginReg
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult myLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult myLogin(LoginVM singleLogin)
        {
            if (ModelState.IsValid)
            {
                Publishers singlePublisher = db.publishers.FirstOrDefault(p => p.Email == singleLogin.Email);

                if (singlePublisher != null)
                {
                    if (Crypto.VerifyHashedPassword(singlePublisher.Password, singleLogin.Password))
                    {
                        Session["LoggedIn"] = singlePublisher;
                        Session["LoggedId"] = singlePublisher.Id;
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Please enter a right password!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Please enter a right email!");
                    return View();
                }
            }
            return View();
        }

        public ActionResult myLogout()
        {
            Session["LoggedIn"] = null;
            Session["LoggedId"] = null;
            return RedirectToAction("myLogin", "LoginReg");
        }

        public ActionResult myRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult myRegistration(Publishers newpublisher)
        {


            if (newpublisher.ImageUpload == null)
            {
                ModelState.AddModelError("ImageUpload", "Image is required");

                return View(newpublisher);
            }
            if (ModelState.IsValid)
            {

                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + newpublisher.ImageUpload.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                newpublisher.ImageUpload.SaveAs(imagePath);
                newpublisher.Image = imageName;

                newpublisher.Password = Crypto.HashPassword(newpublisher.Password);
                db.publishers.Add(newpublisher);
                db.SaveChanges();
            }
            else
            {
                return View(newpublisher);

            }
            return RedirectToAction("myLogin", "LoginReg");
        }






        [SessionFilter]
        public ActionResult AdminUpdate()
        {
            Publishers abc = db.publishers.Find((int)Session["LoggedId"]);        
            return View(abc);
        }

        [SessionFilter]
        [HttpPost]
        public ActionResult AdminUpdate(Publishers pubUP)
        {
            string OldImageName = pubUP.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);


                if (pubUP.ImageUpload != null && pubUP.ImageUpload.ContentType != "image/jpeg" && pubUP.ImageUpload.ContentType != "image/png" && pubUP.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (pubUP.ImageUpload != null && pubUP.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {

                    if (ModelState.IsValid)
                    {

                            if (pubUP.ImageUpload != null)
                            {
                                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + pubUP.ImageUpload.FileName;
                                string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                                pubUP.ImageUpload.SaveAs(imagePath);
                                System.IO.File.Delete(OldimagePath);
                                pubUP.Image = imageName;
                            }
                            else
                            {
                                pubUP.Image = OldImageName;
                            }                     
                    }
                    else
                    {
                        return View(pubUP);
                    }
                }
          
            Publishers abc = db.publishers.Find((int)Session["LoggedId"]);
            abc.Fullname = pubUP.Fullname;
            abc.Email = pubUP.Email;
            abc.Image = pubUP.Image;
            abc.Username = pubUP.Username;
            abc.Password = pubUP.Password;


            db.Entry(abc).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }







        //RESET PASSWORD

        public ActionResult ResetPass()
        {
            Publishers abc = db.publishers.Find((int)Session["LoggedId"]);
            if (Session["LoggedIn"] != null)
            {
                abc.Password = null;
            }
            else
            {
                return RedirectToAction("myLogin", "LoginReg");

            }
            return View(abc);

        }

        [HttpPost]
        public ActionResult ResetPass(Publishers pubUPP)
        {
            string strName = Request["Oldpassword"].ToString();

            if (ModelState.IsValid)
            {
                Publishers pubInfo = (Publishers)Session["LoggedIn"];

                if (Crypto.VerifyHashedPassword(pubInfo.Password, strName))
                {
                    Publishers abc = db.publishers.Find((int)Session["LoggedId"]);
                    abc.Password = Crypto.HashPassword(pubUPP.Password);
                    db.Entry(abc).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    return View(pubInfo);

                }
            }
            else
            {
                return View(pubUPP);
            }
           
            db.SaveChanges();
            return RedirectToAction("myLogin", "LoginReg");

        }

    }
}