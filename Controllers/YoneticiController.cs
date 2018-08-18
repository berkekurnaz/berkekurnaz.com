using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KisiselBerkeKurnaz.Models;

namespace KisiselBerkeKurnaz.Controllers
{
    public class YoneticiController : Controller
    {

        mvcKisiselBerke db = new mvcKisiselBerke();
       
        public ActionResult Index()
        {
            ViewBag.BlogSayi = db.TBL_BLOG.Count();
            ViewBag.Hazirladiklarim = db.TBL_HAZIRLADIKLARIM.Count();
            ViewBag.Paketlerimiz = db.TBL_PAKETLER.Count();
            ViewBag.Kullanicilar = db.TBL_KULLANICI.Count();
            return View();
        }

    }
}