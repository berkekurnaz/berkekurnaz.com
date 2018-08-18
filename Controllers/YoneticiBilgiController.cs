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
    public class YoneticiBilgiController : Controller
    {
        private mvcKisiselBerke db = new mvcKisiselBerke();

        // GET: YoneticiBilgi
        public ActionResult Index()
        {
            return View(db.TBL_BILGI.ToList());
        }

        // GET: YoneticiBilgi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_BILGI tBL_BILGI = db.TBL_BILGI.Find(id);
            if (tBL_BILGI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_BILGI);
        }

        // GET: YoneticiBilgi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YoneticiBilgi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SITEADI,SITEACIKLAMA")] TBL_BILGI tBL_BILGI)
        {
            if (ModelState.IsValid)
            {
                db.TBL_BILGI.Add(tBL_BILGI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_BILGI);
        }

        // GET: YoneticiBilgi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_BILGI tBL_BILGI = db.TBL_BILGI.Find(id);
            if (tBL_BILGI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_BILGI);
        }

        // POST: YoneticiBilgi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SITEADI,SITEACIKLAMA")] TBL_BILGI tBL_BILGI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_BILGI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_BILGI);
        }

        // GET: YoneticiBilgi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_BILGI tBL_BILGI = db.TBL_BILGI.Find(id);
            if (tBL_BILGI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_BILGI);
        }

        // POST: YoneticiBilgi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_BILGI tBL_BILGI = db.TBL_BILGI.Find(id);
            db.TBL_BILGI.Remove(tBL_BILGI);
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
