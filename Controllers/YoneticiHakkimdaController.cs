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
    public class YoneticiHakkimdaController : Controller
    {
        private mvcKisiselBerke db = new mvcKisiselBerke();

        // GET: YoneticiHakkimda
        public ActionResult Index()
        {
            return View(db.TBL_HAKKIMDA.ToList());
        }

        // GET: YoneticiHakkimda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_HAKKIMDA tBL_HAKKIMDA = db.TBL_HAKKIMDA.Find(id);
            if (tBL_HAKKIMDA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_HAKKIMDA);
        }

        // GET: YoneticiHakkimda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YoneticiHakkimda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HAKKIMDA,BKOYUN")] TBL_HAKKIMDA tBL_HAKKIMDA)
        {
            if (ModelState.IsValid)
            {
                db.TBL_HAKKIMDA.Add(tBL_HAKKIMDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_HAKKIMDA);
        }

        // GET: YoneticiHakkimda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_HAKKIMDA tBL_HAKKIMDA = db.TBL_HAKKIMDA.Find(id);
            if (tBL_HAKKIMDA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_HAKKIMDA);
        }

        // POST: YoneticiHakkimda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HAKKIMDA,BKOYUN")] TBL_HAKKIMDA tBL_HAKKIMDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_HAKKIMDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_HAKKIMDA);
        }

        // GET: YoneticiHakkimda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_HAKKIMDA tBL_HAKKIMDA = db.TBL_HAKKIMDA.Find(id);
            if (tBL_HAKKIMDA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_HAKKIMDA);
        }

        // POST: YoneticiHakkimda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_HAKKIMDA tBL_HAKKIMDA = db.TBL_HAKKIMDA.Find(id);
            db.TBL_HAKKIMDA.Remove(tBL_HAKKIMDA);
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
