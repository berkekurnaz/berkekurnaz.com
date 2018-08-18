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
    public class YoneticiBlogController : Controller
    {
        private mvcKisiselBerke db = new mvcKisiselBerke();

        // GET: YoneticiBlog
        public ActionResult Index()
        {
            return View(db.TBL_BLOG.ToList());
        }

        // GET: YoneticiBlog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_BLOG tBL_BLOG = db.TBL_BLOG.Find(id);
            if (tBL_BLOG == null)
            {
                return HttpNotFound();
            }
            return View(tBL_BLOG);
        }

        // GET: YoneticiBlog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YoneticiBlog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BASLIK,TARIH,ICERIK")] TBL_BLOG tBL_BLOG)
        {
            if (ModelState.IsValid)
            {
                db.TBL_BLOG.Add(tBL_BLOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_BLOG);
        }

        // GET: YoneticiBlog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_BLOG tBL_BLOG = db.TBL_BLOG.Find(id);
            if (tBL_BLOG == null)
            {
                return HttpNotFound();
            }
            return View(tBL_BLOG);
        }

        // POST: YoneticiBlog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BASLIK,TARIH,ICERIK")] TBL_BLOG tBL_BLOG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_BLOG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_BLOG);
        }

        // GET: YoneticiBlog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_BLOG tBL_BLOG = db.TBL_BLOG.Find(id);
            if (tBL_BLOG == null)
            {
                return HttpNotFound();
            }
            return View(tBL_BLOG);
        }

        // POST: YoneticiBlog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_BLOG tBL_BLOG = db.TBL_BLOG.Find(id);
            db.TBL_BLOG.Remove(tBL_BLOG);
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
