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
    public class YoneticiKullaniciController : Controller
    {
        private mvcKisiselBerke db = new mvcKisiselBerke();

        // GET: YoneticiKullanici
        public ActionResult Index()
        {
            return View(db.TBL_KULLANICI.ToList());
        }

        // GET: YoneticiKullanici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_KULLANICI tBL_KULLANICI = db.TBL_KULLANICI.Find(id);
            if (tBL_KULLANICI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_KULLANICI);
        }

        // GET: YoneticiKullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YoneticiKullanici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KULLANICIADI,SIFRE,YETKI")] TBL_KULLANICI tBL_KULLANICI)
        {
            if (ModelState.IsValid)
            {
                db.TBL_KULLANICI.Add(tBL_KULLANICI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_KULLANICI);
        }

        // GET: YoneticiKullanici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_KULLANICI tBL_KULLANICI = db.TBL_KULLANICI.Find(id);
            if (tBL_KULLANICI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_KULLANICI);
        }

        // POST: YoneticiKullanici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KULLANICIADI,SIFRE,YETKI")] TBL_KULLANICI tBL_KULLANICI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_KULLANICI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_KULLANICI);
        }

        // GET: YoneticiKullanici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_KULLANICI tBL_KULLANICI = db.TBL_KULLANICI.Find(id);
            if (tBL_KULLANICI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_KULLANICI);
        }

        // POST: YoneticiKullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_KULLANICI tBL_KULLANICI = db.TBL_KULLANICI.Find(id);
            db.TBL_KULLANICI.Remove(tBL_KULLANICI);
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
