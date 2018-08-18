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
    public class YoneticiPaketlerimizController : Controller
    {

        mvcKisiselBerke db = new mvcKisiselBerke();

        public ActionResult Index()
        {
            var paketler = db.TBL_PAKETLER.OrderByDescending(p => p.ID).ToList();
            return View(paketler);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TBL_PAKETLER tbl, HttpPostedFileBase resim)
        {
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo fotoInfo = new FileInfo(resim.FileName);

                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(350, 200);
                    img.Save("~/Uploads/PaketlerResim/" + newFoto);
                    tbl.PAKETFOTOGRAF = "/Uploads/PaketlerResim/" + newFoto;
                }
                db.TBL_PAKETLER.Add(tbl);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(tbl);
        }

        public ActionResult Delete(int id)
        {
            var paketler = db.TBL_PAKETLER.Where(p => p.ID == id).SingleOrDefault();
            if (paketler == null)
            {
                return HttpNotFound();
            }
            return View(paketler);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var paketler = db.TBL_PAKETLER.Where(h => h.ID == id).SingleOrDefault();
                if (paketler == null)
                {
                    return HttpNotFound();
                }
                if (System.IO.File.Exists(Server.MapPath(paketler.PAKETFOTOGRAF)))
                {
                    System.IO.File.Delete(Server.MapPath(paketler.PAKETFOTOGRAF));
                }
                db.TBL_PAKETLER.Remove(paketler);
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
            var paketler = db.TBL_PAKETLER.Where(p => p.ID == id).SingleOrDefault();
            if (paketler == null)
            {
                return HttpNotFound();
            }
            return View(paketler);
        }

        [HttpPost]
        public ActionResult Edit(int id,HttpPostedFileBase resim, TBL_PAKETLER paketler)
        {
            try
            {
                var pakets = db.TBL_PAKETLER.Where(p => p.ID == id).SingleOrDefault();
                if (resim != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(pakets.PAKETFOTOGRAF)))
                    {
                        System.IO.File.Delete(Server.MapPath(pakets.PAKETFOTOGRAF));
                    }
                    WebImage img = new WebImage(resim.InputStream);
                    FileInfo fotoInfo = new FileInfo(resim.FileName);

                    string newFoto = Guid.NewGuid().ToString() + fotoInfo.Extension;
                    img.Resize(350, 200);
                    img.Save("~/Uploads/PaketlerResim/" + newFoto);
                    pakets.PAKETFOTOGRAF = "/Uploads/PaketlerResim/" + newFoto;
                    pakets.PAKETAD = paketler.PAKETAD;
                    pakets.PAKETTANITIM = paketler.PAKETTANITIM;
                    pakets.PAKETACIKLAMA = paketler.PAKETACIKLAMA;
                    pakets.PAKETFIYAT = paketler.PAKETFIYAT;
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