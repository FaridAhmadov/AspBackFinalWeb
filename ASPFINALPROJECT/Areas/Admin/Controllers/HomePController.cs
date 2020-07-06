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
    public class HomePController : Controller
    {
        // GET: Admin/AboutP
        ConnectThat db = new ConnectThat();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SliderDash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.slider = db.slider.ToList();
            return View(viewModels);
        }

        public ActionResult SliderCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SliderCreate(Slider slider)
        {
   
                if (slider.ImageUpload != null && slider.ImageUpload.ContentType != "image/jpeg" && slider.ImageUpload.ContentType != "image/png" && slider.ImageUpload.ContentType != "image/gif")
            {
                return Content("Please upload img/png or gif");
            }
            if (slider.ImageUpload != null && slider.ImageUpload.ContentLength > 5048576)
            {
                return Content("You can only upload max 1mb");
            }

            else
            {
                    if (slider.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(slider);
                    }
                    if (ModelState.IsValid)
                {

                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + slider.ImageUpload.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                    slider.ImageUpload.SaveAs(imagePath);
                    slider.Image = imageName;

                    db.slider.Add(slider);
                    db.SaveChanges();


                }
                else
                {
                    return View(slider);
                }
            }

    

            return RedirectToAction("SliderDash", "HomeP");
        }



        public ActionResult SliderUpdate(int Id)
        {
            Slider abc = db.slider.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult SliderUpdate(Slider sliderr)
        {
            string OldImageName = sliderr.Image;
            string OldimagePath = Path.Combine(Server.MapPath("~/Public/img"), OldImageName);

           
                if (sliderr.ImageUpload != null && sliderr.ImageUpload.ContentType != "image/jpeg" && sliderr.ImageUpload.ContentType != "image/png" && sliderr.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (sliderr.ImageUpload != null && sliderr.ImageUpload.ContentLength > 1048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {
                    if (ModelState.IsValid)
                    {
                        if (sliderr.ImageUpload != null)
                        {
                            string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + sliderr.ImageUpload.FileName;
                            string imagePath = Path.Combine(Server.MapPath("~/Public/img"), imageName);

                            sliderr.ImageUpload.SaveAs(imagePath);
                        System.IO.File.Delete(OldimagePath);
                            sliderr.Image = imageName;


                        }
                        else
                        {
                            sliderr.Image = OldImageName;
                        }

                    }
                    else
                    {
                        return View(sliderr);
                    }
                }
          

            db.Entry(sliderr).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("SliderDash", "HomeP");
        }

        public ActionResult SliderDelete(int Id)
        {
            Slider abc = db.slider.Find(Id);
            db.slider.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("SliderDash", "HomeP");
        }









//WELCOME TO EDU HOME SECTION



        public ActionResult WelcomeTehDash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.welcomeToEduHomes = db.welcomeToEduHomes.ToList();
            return View(viewModels);
        }

        public ActionResult WelcomeTehCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult WelcomeTehCreate(WelcomeToEduHome WTEH)
        {

                if (WTEH.ImageUpload != null && WTEH.ImageUpload.ContentType != "image/jpeg" && WTEH.ImageUpload.ContentType != "image/png" && WTEH.ImageUpload.ContentType != "image/gif")
                {
                    return Content("Please upload img/png or gif");
                }
                if (WTEH.ImageUpload != null && WTEH.ImageUpload.ContentLength > 2048576)
                {
                    return Content("You can only upload max 1mb");
                }

                else
                {

                    if (WTEH.ImageUpload == null)
                    {
                        ModelState.AddModelError("ImageUpload", "Image is required");

                        return View(WTEH);
                    }
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
      

            return RedirectToAction("WelcomeTehDash", "HomeP");
        }



        public ActionResult WelcomeTehUpdate(int Id)
        {
            WelcomeToEduHome abc = db.welcomeToEduHomes.Find(Id);
            return View(abc);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult WelcomeTehUpdate(WelcomeToEduHome WtehU)
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
            return RedirectToAction("WelcomeTehDash", "HomeP");
        }

        public ActionResult WelcomeTehDelete(int Id)
        {
            WelcomeToEduHome abc = db.welcomeToEduHomes.Find(Id);
            db.welcomeToEduHomes.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("WelcomeTehDash", "HomeP");
        }





        //INFO SECTION

        public ActionResult InfoDash()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.homeInfoSections = db.homeInfoSections.ToList();
            return View(viewModels);
        }

        public ActionResult InfoCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InfoCreate(HomeInfoSection Homeinfo)
        {
  
                if (ModelState.IsValid)
                {

                    db.homeInfoSections.Add(Homeinfo);
                    db.SaveChanges();

                }
                else
                {
                    return View(Homeinfo);
                }
       

            return RedirectToAction("InfoDash", "HomeP");
        }



        public ActionResult InfoUpdate(int Id)
        {
            HomeInfoSection abc = db.homeInfoSections.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult InfoUpdate(HomeInfoSection Homeinf)
        {

                if (ModelState.IsValid)
                {
                    db.Entry(Homeinf).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    return View(Homeinf);
                }
 
            return RedirectToAction("InfoDash", "HomeP");
        }

        public ActionResult InfoDelete(int Id)
        {
            HomeInfoSection abc = db.homeInfoSections.Find(Id);
            db.homeInfoSections.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("InfoDash", "HomeP");
        }

    }
}
