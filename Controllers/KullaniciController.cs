using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KisiselBerkeKurnaz.Models;

namespace KisiselBerkeKurnaz.Controllers
{
    public class KullaniciController : Controller
    {

        mvcKisiselBerke db = new mvcKisiselBerke();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(TBL_KULLANICI kullanici)
        {
            var giris = db.TBL_KULLANICI.Where(g => g.KULLANICIADI == kullanici.KULLANICIADI).SingleOrDefault();
            if (giris.KULLANICIADI == kullanici.KULLANICIADI && giris.SIFRE == kullanici.SIFRE)
            {
                Session["ID"] = giris.ID;
                Session["KULLANICIADI"] = giris.KULLANICIADI;
                Session["SIFRE"] = giris.SIFRE;
                Session["YETKI"] = giris.YETKI;
                return RedirectToAction("Index", "Yonetici");
            }
            else
            {
                ViewBag.Uyari = "Kullanıcı Adı Veya Şifre Hatalı...";
                return View();
            }
        }

        public ActionResult CikisYap()
        {
            Session["ID"] = null;
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }

    }
}