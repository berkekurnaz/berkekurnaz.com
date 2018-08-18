using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KisiselBerkeKurnaz.Models;

namespace KisiselBerkeKurnaz.Controllers
{
    public class YoneticiEkipArkadasiController : Controller
    {
        private mvcKisiselBerke db = new mvcKisiselBerke();

        // GET: YoneticiEkipArkadasi
        public ActionResult Index()
        {
            return View(db.TBL_EKIPARKADASI.ToList());
        }

        // GET: YoneticiEkipArkadasi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_EKIPARKADASI tBL_EKIPARKADASI = db.TBL_EKIPARKADASI.Find(id);
            if (tBL_EKIPARKADASI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_EKIPARKADASI);
        }

        // GET: YoneticiEkipArkadasi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YoneticiEkipArkadasi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ADSOYAD,TELEFON,MAIL,ALAN,YETENEKLER,HAKKINIZDA")] TBL_EKIPARKADASI tBL_EKIPARKADASI)
        {
            if (ModelState.IsValid)
            {
                db.TBL_EKIPARKADASI.Add(tBL_EKIPARKADASI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_EKIPARKADASI);
        }

        // GET: YoneticiEkipArkadasi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_EKIPARKADASI tBL_EKIPARKADASI = db.TBL_EKIPARKADASI.Find(id);
            if (tBL_EKIPARKADASI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_EKIPARKADASI);
        }

        // POST: YoneticiEkipArkadasi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ADSOYAD,TELEFON,MAIL,ALAN,YETENEKLER,HAKKINIZDA")] TBL_EKIPARKADASI tBL_EKIPARKADASI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_EKIPARKADASI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_EKIPARKADASI);
        }

        // GET: YoneticiEkipArkadasi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_EKIPARKADASI tBL_EKIPARKADASI = db.TBL_EKIPARKADASI.Find(id);
            if (tBL_EKIPARKADASI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_EKIPARKADASI);
        }

        // POST: YoneticiEkipArkadasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_EKIPARKADASI tBL_EKIPARKADASI = db.TBL_EKIPARKADASI.Find(id);
            db.TBL_EKIPARKADASI.Remove(tBL_EKIPARKADASI);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
