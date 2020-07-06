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
    public class NoticeBoardPController : Controller
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
            viewModels.noticeBoards = db.noticeBoards.ToList();
            return View(viewModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NoticeBoard NB)
        {


                if (ModelState.IsValid)
                {
                NB.CreatedDate = DateTime.Now;
                    db.noticeBoards.Add(NB);
                    db.SaveChanges();


                }
                else
                {
                    return View(NB);
                }


            return RedirectToAction("Dash", "NoticeBoardP");
        }



        public ActionResult Update(int Id)
        {
            NoticeBoard abc = db.noticeBoards.Find(Id);
            return View(abc);
        }

        [HttpPost]
        public ActionResult Update(NoticeBoard NBB)
        {

           
                if (ModelState.IsValid)
                {

                    db.Entry(NBB).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    return View(NBB);
                }
           
            return RedirectToAction("Dash", "NoticeBoardP");
        }

        public ActionResult Delete(int Id)
        {
            NoticeBoard abc = db.noticeBoards.Find(Id);
            db.noticeBoards.Remove(abc);
            db.SaveChanges();
            return RedirectToAction("Dash", "NoticeBoardP");
        }
    }
}