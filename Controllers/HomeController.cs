using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KisiselBerkeKurnaz.Models;

namespace KisiselBerkeKurnaz.Controllers
{
    public class HomeController : Controller
    {

        mvcKisiselBerke db = new mvcKisiselBerke();

        public ActionResult Index()
        {
            var bilgi = db.TBL_BILGI.ToList();
            return View(bilgi);
        }

        public ActionResult BenKimim()
        {
            var benkimim = db.TBL_HAKKIMDA.ToList();
            return View(benkimim);
        }



        /* SERVISLERIMIZ LISTELEME VE DETAY SAYFASI */
        public ActionResult Servislerimiz()
        {
            var servisler = db.TBL_PAKETLER.OrderByDescending(s => s.ID).ToList();
            return View(servisler);
        }

        public ActionResult ServislerimizDetay(int id)
        {
            var servisler = db.TBL_PAKETLER.Where(s => s.ID == id).SingleOrDefault();
            if (servisler == null)
            {
                return HttpNotFound();
            }
            return View(servisler);
        }



        public ActionResult OrtakOl()
        {
            var ortakol = db.TBL_ORTAKOL.ToList();
            return View(ortakol);
        }



        /* HAZIRLADIKLARIM LISTELEME VE DETAY SAYFASI */
        public ActionResult Hazirladiklarim()
        {
            var hazirladiklarim = db.TBL_HAZIRLADIKLARIM.OrderByDescending(h => h.ID).ToList();
            return View(hazirladiklarim);
        }

        public ActionResult HazirladiklarimDetay(int id)
        {
            var hazirladiklarim = db.TBL_HAZIRLADIKLARIM.Where(h => h.ID == id).SingleOrDefault();
            if (hazirladiklarim == null)
            {
                return HttpNotFound();
            }
            return View(hazirladiklarim);
        }



        /* BLOG LISTELEME VE DETAY SAYFASI */
        public ActionResult Blog()
        {
            var blog = db.TBL_BLOG.OrderByDescending(b => b.ID).ToList();
            return View(blog);
        }

        public ActionResult BlogDetay(int id)
        {
            var blog = db.TBL_BLOG.Where(b => b.ID == id).SingleOrDefault();
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }



        /* ILETISIM EKRANI VE POST ISLEMI */
        public ActionResult Iletisim()
        {
            return View();
        }

        public JsonResult IletisimForm(string adsoyad,string mail,string telefon,string mesaj)
        {
            if (adsoyad == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            db.TBL_ILETISIM.Add(new TBL_ILETISIM { ADSOYAD = adsoyad, TELEFON = telefon, MAIL = mail, MESAJ = mesaj });
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);
        }


        public ActionResult BKOyun()
        {
            return View();
        }



        /* ILETISIM EKRANI VE POST ISLEMI */
        public ActionResult EkipKatil()
        {
            return View();
        }

        public ActionResult EkipKatilForm(string adsoyad,string telefon,string mail,string alan,string yetenekler,string hakkinda)
        {
            if (adsoyad == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            db.TBL_EKIPARKADASI.Add(new TBL_EKIPARKADASI { ADSOYAD = adsoyad, TELEFON = telefon, MAIL = mail, ALAN = alan, YETENEKLER = yetenekler, HAKKINIZDA = hakkinda });
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}