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
    public class YoneticiOrtakOlController : Controller
    {
        private mvcKisiselBerke db = new mvcKisiselBerke();

        // GET: YoneticiOrtakOl
        public ActionResult Index()
        {
            return View(db.TBL_ORTAKOL.ToList());
        }

        // GET: YoneticiOrtakOl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ORTAKOL tBL_ORTAKOL = db.TBL_ORTAKOL.Find(id);
            if (tBL_ORTAKOL == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ORTAKOL);
        }

        // GET: YoneticiOrtakOl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YoneticiOrtakOl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TANITIM,YATIRIMCI,EKIPARKADAS,PROJEORTAK,REKLAMVEREN")] TBL_ORTAKOL tBL_ORTAKOL)
        {
            if (ModelState.IsValid)
            {
                db.TBL_ORTAKOL.Add(tBL_ORTAKOL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_ORTAKOL);
        }

        // GET: YoneticiOrtakOl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ORTAKOL tBL_ORTAKOL = db.TBL_ORTAKOL.Find(id);
            if (tBL_ORTAKOL == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ORTAKOL);
        }

        // POST: YoneticiOrtakOl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TANITIM,YATIRIMCI,EKIPARKADAS,PROJEORTAK,REKLAMVEREN")] TBL_ORTAKOL tBL_ORTAKOL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_ORTAKOL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_ORTAKOL);
        }

        // GET: YoneticiOrtakOl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ORTAKOL tBL_ORTAKOL = db.TBL_ORTAKOL.Find(id);
            if (tBL_ORTAKOL == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ORTAKOL);
        }

        // POST: YoneticiOrtakOl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_ORTAKOL tBL_ORTAKOL = db.TBL_ORTAKOL.Find(id);
            db.TBL_ORTAKOL.Remove(tBL_ORTAKOL);
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
