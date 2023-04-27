using FormTable.Areas.Yonetim.Controllers.Giris;
using FormTable.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FormTable.Areas.Yonetim.ViewModels;

namespace FormTable.Areas.Yonetim.Controllers
{
    public class IndexController : Controller
    {
        // GET: Yonetim/Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Redirect("/Login");
        }
        [GirisControlleri("All")]
        public ActionResult KeepAlive()
        {
            return View();
        }
        public static string AlertBildirim(AlertTip tip, string mesaj)
        {
            var tipstring = tip == AlertTip.Basarili ? "success" : tip == AlertTip.Bilgi ? "info" : tip == AlertTip.Uyari ? "warning" : tip == AlertTip.Hata ? "error" : "";
            return string.Format("Swal.fire({{position: 'top-end',icon: '" + tipstring + "',title: '" + mesaj + "',showConfirmButton: false,timer: 1500}});");
            //tip= success,warning,error,info
        }
        public enum AlertTip
        {
            Basarili = 0,//success
            Bilgi = 1,//info
            Uyari = 2,//warning
            Hata = 3,//error
        }
        public static KullaniciBilgileriClass KullaniciBilgileri(string kullaniciId)
        {
            using (var db = new FormTableDBEntities())
            {
                var id = Guid.Parse(kullaniciId);
                return db.KullanicilarDT.AsNoTracking().Where(x => x.ID == id).Select(x => new KullaniciBilgileriClass
                {
                    Id = x.ID,
                    AdSoyad = x.AdSoyad,
                    KullaniciAdi = x.KullaniciAdi,
                    Resim = x.Resim
                }).First();
            }
        }
        public static string ResimveyaDosyaKaydet(HttpPostedFileBase file, bool duzenlemeMi, string silinecekresimYolu, string webconfigKlasorAdi)
        {

            if (file != null && (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "application/pdf" || file.ContentType == "image/png" || file.ContentType == "image/x-icon"))
            {

                if (duzenlemeMi && !string.IsNullOrEmpty(silinecekresimYolu)) System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(silinecekresimYolu));
                var klasorYolu = ConfigurationManager.AppSettings[webconfigKlasorAdi];
                var uploadfullpath = System.Web.HttpContext.Current.Server.MapPath(klasorYolu);
                if (Directory.Exists(uploadfullpath) == false) Directory.CreateDirectory(uploadfullpath);
                var dosyaAdi = Path.GetRandomFileName().Replace(".", "");
                var uzanti = Path.GetExtension(file.FileName);
                var dosyaYoluyeni = klasorYolu + "/" + dosyaAdi + uzanti;
                file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(dosyaYoluyeni));
                return dosyaYoluyeni;
            }
            else
            {
                return "";
            }
        }
        public static string LinkDonustur(string text)
        {
            try
            {
                var strReturn = text.Trim();
                strReturn = strReturn.Replace("ğ", "g");
                strReturn = strReturn.Replace("Ğ", "G");
                strReturn = strReturn.Replace("ü", "u");
                strReturn = strReturn.Replace("Ü", "U");
                strReturn = strReturn.Replace("ş", "s");
                strReturn = strReturn.Replace("Ş", "S");
                strReturn = strReturn.Replace("ı", "i");
                strReturn = strReturn.Replace("İ", "I");
                strReturn = strReturn.Replace("ö", "o");
                strReturn = strReturn.Replace("Ö", "O");
                strReturn = strReturn.Replace("ç", "c");
                strReturn = strReturn.Replace("Ç", "C");
                strReturn = strReturn.Replace("-", "+");
                strReturn = strReturn.Replace(" ", "+");
                strReturn = strReturn.Trim();
                strReturn = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9+]").Replace(strReturn, "");
                strReturn = strReturn.Trim();
                strReturn = strReturn.Replace("+", "-");
                return strReturn;
            }
            catch (Exception ex)
            {
                var a = ex.ToString();
                return "/Anasayfa";
            }

        }
       
        [HttpPost]
        public JsonResult SummerResimYukleme(HttpPostedFileBase gelenresim, string dosyaYolu)
        {
            try
            {
                if (gelenresim != null && (gelenresim.ContentType == "image/jpeg" || gelenresim.ContentType == "image/jpg" || gelenresim.ContentType == "image/png"))
                {
                    var klasorYolu = ConfigurationManager.AppSettings[dosyaYolu];
                    var uploadfullpath = Server.MapPath(klasorYolu);
                    if (Directory.Exists(uploadfullpath) == false) Directory.CreateDirectory(uploadfullpath);
                    var dosyaAdi = Path.GetRandomFileName().Replace(".", "");
                    var uzanti = Path.GetExtension(gelenresim.FileName);
                    var dosyaYoluyeni = klasorYolu + "/" + dosyaAdi + uzanti;
                    gelenresim.SaveAs(Server.MapPath(dosyaYoluyeni));
                    var veri = new JsonDonenVeri { IslemTuru = true, DosyaYolu = dosyaYoluyeni };
                    var json = JsonConvert.SerializeObject(veri, Formatting.None);
                    return Json(json, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var veri = new JsonDonenVeri { IslemTuru = false, DosyaYolu = "" };
                    var json = JsonConvert.SerializeObject(veri, Formatting.None);
                    return Json(json, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                var veri = new JsonDonenVeri { IslemTuru = false, DosyaYolu = "" };
                var json = JsonConvert.SerializeObject(veri, Formatting.None);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
        private class JsonDonenVeri
        {
            public bool IslemTuru { get; set; }
            public string DosyaYolu { get; set; }
        }
        [HttpPost]
        public JsonResult SummerResimSilme(string resimYolu)
        {
            if (!string.IsNullOrEmpty(resimYolu))
            {
                System.IO.File.Delete(Server.MapPath(resimYolu));
                var veri = new JsonDonenVeri { IslemTuru = true, DosyaYolu = "" };
                var json = JsonConvert.SerializeObject(veri, Formatting.None);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var veri = new JsonDonenVeri { IslemTuru = false, DosyaYolu = "" };
                var json = JsonConvert.SerializeObject(veri, Formatting.None);
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
   
        public enum AlertTipYonetim
        {
            Basarili = 0,//success
            Bilgi = 1,//info
            Uyari = 2,//warning
            Hata = 3,//error
        }
        public static string AlertToastBildirimYonetim(AlertTipYonetim tip, string mesaj)
        {
            var tipstring = tip == AlertTipYonetim.Basarili ? "success" : tip == AlertTipYonetim.Bilgi ? "info" : tip == AlertTipYonetim.Uyari ? "warning" : tip == AlertTipYonetim.Hata ? "error" : "";
            //return string.Format("window.toastYonetici.fire({{icon: '" + tipstring + "',title: '" + mesaj + "'}});");
            return string.Format("AlertBildirimi(\"" + tipstring + "\", \"" + mesaj + "\");");
            //tip= success,warning,error,info
        }

    }
}