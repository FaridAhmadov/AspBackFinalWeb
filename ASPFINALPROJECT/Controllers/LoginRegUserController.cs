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

namespace ASPFINALPROJECT.Controllers
{
    public class LoginRegUserController : Controller
    {
        // GET: LoginRegUser
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
                Users singlePublisher = db.users.FirstOrDefault(p => p.Email == singleLogin.Email);

                if (singlePublisher != null)
                {
                    if (Crypto.VerifyHashedPassword(singlePublisher.Password, singleLogin.Password))
                    {
                        Session["LoggedInn"] = singlePublisher;
                        Session["LoggedIdd"] = singlePublisher.Id;
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
            Session["LoggedInn"] = null;
            Session["LoggedIdd"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult myRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult myRegistration(Users userr)
        {


            if (userr.ImageUpload == null)
            {
                ModelState.AddModelError("ImageUpload", "Image is required");

                return View(userr);
            }
            if (ModelState.IsValid)
            {

                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + userr.ImageUpload.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                userr.ImageUpload.SaveAs(imagePath);
                userr.Image = imageName;

                userr.Password = Crypto.HashPassword(userr.Password);
                db.users.Add(userr);
                db.SaveChanges();
            }
            else
            {
                return View(userr);

            }
            return RedirectToAction("myLogin", "LoginRegUser");
        }







        public ActionResult UserUpdate()
        {
            Users abc = db.users.Find(Session["LoggedIdd"]);
            return View(abc);
        }

        [HttpPost]
        public ActionResult UserUpdate(Users userUp)
        {
            string OldImageName = userUp.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);

            if (Session["LoggedInn"] != null)
            {
                if (userUp.ImageUpload != null && userUp.ImageUpload.ContentType != "image/jpeg" && userUp.ImageUpload.ContentType != "image/png" && userUp.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (userUp.ImageUpload != null && userUp.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {

                    if (ModelState.IsValid)
                    {

                        if (userUp.ImageUpload != null)
                        {
                            string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + userUp.ImageUpload.FileName;
                            string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                            userUp.ImageUpload.SaveAs(imagePath);
                            System.IO.File.Delete(OldimagePath);
                            userUp.Image = imageName;
                        }
                        else
                        {
                            userUp.Image = OldImageName;
                        }
                    }
                    else
                    {
                        return View(userUp);
                    }
                }
            }
            else
            {
                return RedirectToAction("myLogin", "LoginRegUser");
            }
            Users abc = db.users.Find((int)Session["LoggedIdd"]);
            abc.Fullname = userUp.Fullname;
            abc.Email = userUp.Email;
            abc.Image = userUp.Image;
            abc.Username = userUp.Username;
            abc.Password = userUp.Password;


            db.Entry(abc).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }













        //RESET PASSWORD

        public ActionResult ResetPass()
        {
            Users abc = db.users.Find((int)Session["LoggedIdd"]);
            if (Session["LoggedInn"] != null)
            {
                abc.Password = null;
            }
            else
            {
                return RedirectToAction("myLogin", "LoginRegUser");

            }
            return View(abc);

        }

        [HttpPost]
        public ActionResult ResetPass(Users userss)
        {
            string strName = Request["Oldpassword"].ToString();

            if (ModelState.IsValid)
            {
                Users pubInfo = (Users)Session["LoggedInn"];

                if (Crypto.VerifyHashedPassword(pubInfo.Password, strName))
                {
                    Users abc = db.users.Find((int)Session["LoggedIdd"]);
                    abc.Password = Crypto.HashPassword(userss.Password);
                    db.Entry(abc).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    return View(pubInfo);

                }
            }
            else
            {
                return View(userss);
            }

            db.SaveChanges();
            return RedirectToAction("myLogin", "LoginRegUser");

        }

    }
}

