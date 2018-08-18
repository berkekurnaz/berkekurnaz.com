using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using KisiselBerkeKurnaz.Models;

namespace KisiselBerkeKurnaz.Controllers
{
    public class YoneticiHazirladiklarimController : Controller
    {

        mvcKisiselBerke db = new mvcKisiselBerke();

        public ActionResult Index()
        {
            var hazirladiklarim = db.TBL_HAZIRLADIKLARIM.OrderByDescending(h => h.ID).ToList();
            return View(hazirladiklarim);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TBL_HAZIRLADIKLARIM tbl,HttpPostedFileBase resim)
        {
            if (ModelState.IsValid)
            {
                if(resim != null)
                {
                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo fotoInfo = new FileInfo(resim.FileName);

                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(350, 200);
                    img.Save("~/Uploads/HazirladiklarimResim/" + newFoto);
                    tbl.FOTOGRAF = "/Uploads/HazirladiklarimResim/" + newFoto;
                }
                db.TBL_HAZIRLADIKLARIM.Add(tbl);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(tbl);
        }


        public ActionResult Delete(int id)
        {
            var hazirladiklarim = db.TBL_HAZIRLADIKLARIM.Where(h => h.ID == id).SingleOrDefault();
            if (hazirladiklarim == null)
            {
                return HttpNotFound();
            }
            return View(hazirladiklarim);
        }

        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            try
            {
                var hazirladiklarim = db.TBL_HAZIRLADIKLARIM.Where(h => h.ID == id).SingleOrDefault();
                if (hazirladiklarim == null)
                {
                    return HttpNotFound();
                }
                if(System.IO.File.Exists(Server.MapPath(hazirladiklarim.FOTOGRAF)))
                {
                    System.IO.File.Delete(Server.MapPath(hazirladiklarim.FOTOGRAF));
                }
                db.TBL_HAZIRLADIKLARIM.Remove(hazirladiklarim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var hazirladiklarim = db.TBL_HAZIRLADIKLARIM.Where(p => p.ID == id).SingleOrDefault();
            if (hazirladiklarim == null)
            {
                return HttpNotFound();
            }
            return View(hazirladiklarim);
        }

        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase resim, TBL_HAZIRLADIKLARIM hazir)
        {
            try
            {
                var hazirs = db.TBL_HAZIRLADIKLARIM.Where(p => p.ID == id).SingleOrDefault();
                if (resim != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(hazirs.FOTOGRAF)))
                    {
                        System.IO.File.Delete(Server.MapPath(hazirs.FOTOGRAF));
                    }
                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo fotoInfo = new FileInfo(resim.FileName);

                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(350, 200);
                    img.Save("~/Uploads/HazirladiklarimResim/" + newFoto);
                    hazirs.FOTOGRAF = "/Uploads/HazirladiklarimResim/" + newFoto;
                    hazirs.AD = hazir.AD;
                    hazirs.TANITIM = hazir.TANITIM;
                    hazirs.ACIKLAMA = hazir.ACIKLAMA;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}