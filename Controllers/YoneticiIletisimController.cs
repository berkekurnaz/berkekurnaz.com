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
    public class YoneticiIletisimController : Controller
    {
        private mvcKisiselBerke db = new mvcKisiselBerke();

        // GET: YoneticiIletisim
        public ActionResult Index()
        {
            return View(db.TBL_ILETISIM.ToList());
        }

        // GET: YoneticiIletisim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ILETISIM tBL_ILETISIM = db.TBL_ILETISIM.Find(id);
            if (tBL_ILETISIM == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ILETISIM);
        }

        // GET: YoneticiIletisim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YoneticiIletisim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ADSOYAD,MAIL,TELEFON,MESAJ")] TBL_ILETISIM tBL_ILETISIM)
        {
            if (ModelState.IsValid)
            {
                db.TBL_ILETISIM.Add(tBL_ILETISIM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_ILETISIM);
        }

        // GET: YoneticiIletisim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ILETISIM tBL_ILETISIM = db.TBL_ILETISIM.Find(id);
            if (tBL_ILETISIM == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ILETISIM);
        }

        // POST: YoneticiIletisim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ADSOYAD,MAIL,TELEFON,MESAJ")] TBL_ILETISIM tBL_ILETISIM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_ILETISIM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_ILETISIM);
        }

        // GET: YoneticiIletisim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ILETISIM tBL_ILETISIM = db.TBL_ILETISIM.Find(id);
            if (tBL_ILETISIM == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ILETISIM);
        }

        // POST: YoneticiIletisim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_ILETISIM tBL_ILETISIM = db.TBL_ILETISIM.Find(id);
            db.TBL_ILETISIM.Remove(tBL_ILETISIM);
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
