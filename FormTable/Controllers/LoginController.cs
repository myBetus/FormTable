using FormTable.Areas.Yonetim.Controllers;
using FormTable.Areas.Yonetim.ViewModels;
using FormTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormTable.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult GirisYap(LoginViewModel kullanicilar, string returnUrl)
        {
            using (var db = new FormTableDBEntities())
            {
                var kullanicidb = db.KullanicilarDT.FirstOrDefault(x => x.AktifMi == true && x.KullaniciAdi == kullanicilar.KullaniciAdi && x.Sifre == kullanicilar.Sifre && x.AktifMi);
                if (kullanicidb != null)
                {
                    db.Entry(kullanicidb).CurrentValues.SetValues(kullanicidb);
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(kullanicidb.ID.ToString(), false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Anasayfa", new { area = "Yonetim" });

                    }
                }
                else
                {
                    ModelState.AddModelError("KullaniciYok", "Geçersiz Kullanıcı Adı / Şifre");
                    return View("Index");
                }
            }
        }


    }
}