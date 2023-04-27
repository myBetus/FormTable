using DevExpress.Web.Mvc;
using FormTable.Areas.Yonetim.ViewModels;
using FormTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormTable.Areas.Yonetim.Controllers
{
    public class KullaniciController : Controller
    {

        public ActionResult Liste(string id)
        {
            using (var db = new FormTableDBEntities())
            {
                try
                {
                    Guid.TryParse(id, out var gelenid);
                    var veri = new YeniKullaniciViewModel
                    {
                        KullaniciBilgileri = gelenid == Guid.Empty ? new KullaniciBilgileriClass() : db.KullanicilarDT.AsNoTracking().Where(x => x.ID == gelenid).Select(x => new KullaniciBilgileriClass
                        {
                            Id = x.ID,
                            Resim = x.Resim,
                            KullaniciAdi = x.KullaniciAdi,
                            Email = x.Email,
                            AdSoyad = x.AdSoyad,
                        }).First(),
                        ListKullaniciBilgileri = db.KullanicilarDT.AsNoTracking().Where(x => x.AktifMi).Select(x => new KullaniciBilgileriClass()
                        {
                            Id = x.ID,
                            Resim = x.Resim,
                            KullaniciAdi = x.KullaniciAdi,
                            Email = x.Email,
                            AdSoyad = x.AdSoyad,
                        }).ToList(),
                    };
                    return View(veri);
                }
                catch (Exception)
                {
                    return RedirectToAction("Liste");
                }
            }
        }
        public ActionResult Tanimla(string id)
        {
            using (var db = new FormTableDBEntities())
            {
                try
                {
                    Guid.TryParse(id, out var gelenid);
                    var veri = new YeniKullaniciViewModel
                    {
                        KullaniciBilgileri = gelenid == Guid.Empty ? new KullaniciBilgileriClass() : db.KullanicilarDT.AsNoTracking().Where(x => x.ID == gelenid).Select(x => new KullaniciBilgileriClass
                        {
                            Id = x.ID,
                            Resim = x.Resim,
                            KullaniciAdi = x.KullaniciAdi,
                            Email=x.Email,
                            AdSoyad = x.AdSoyad,
                        }).First(),
                        ListKullaniciBilgileri = db.KullanicilarDT.AsNoTracking().Where(x => x.AktifMi).Select(x => new KullaniciBilgileriClass()
                        {
                          Id = x.ID,
                            Resim = x.Resim,
                            KullaniciAdi = x.KullaniciAdi,
                            Email=x.Email,
                            AdSoyad = x.AdSoyad,
                        }).ToList(),
                    };
                    return View(veri);
                }
                catch (Exception)
                {
                    return RedirectToAction("Liste");
                }
            }
        }
        [ValidateInput(false)]
        public PartialViewResult _KullaniciList()
        {
            using (var db = new FormTableDBEntities())
            {
                var veri = db.KullanicilarDT.AsNoTracking().Where(x => x.AktifMi).OrderByDescending(x => x.OlusturulmaTarihi).Select(x => new KullaniciBilgileriClass
                {
                    Id = x.ID,
                    Resim = x.Resim,
                    KullaniciAdi = x.KullaniciAdi,
                    Email=x.Email,
                    AdSoyad = x.AdSoyad,
                }).ToList();
                return PartialView("_KullaniciList", veri);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EkleDuzenle(YeniKullaniciViewModel gelenveri)
        {
            using (var db = new FormTableDBEntities())
            {
                if (gelenveri.KullaniciBilgileri.Id == Guid.Empty)
                {
                    var veri = new KullanicilarDT
                    {
                        ID = Guid.NewGuid(),
                        AdSoyad = gelenveri.KullaniciBilgileri.AdSoyad,
                        KullaniciAdi = gelenveri.KullaniciBilgileri.KullaniciAdi,
                        Email=gelenveri.KullaniciBilgileri.Email,
                        Sifre=gelenveri.KullaniciBilgileri.Sifre,
                        OlusturanKisiID = Guid.Parse(User.Identity.Name),
                        OlusturulmaTarihi = DateTime.Now,
                        AktifMi = true
                    };
                   
                    var file = Request.Files[0];
                    if (file != null && !string.IsNullOrEmpty(file.FileName))
                    {
                        veri.Resim = IndexController.ResimveyaDosyaKaydet(file, false, "", "ResimKullanici");
                    }
                    db.KullanicilarDT.Add(veri);
                    db.SaveChanges();
                }
                else
                {
                    var veri = db.KullanicilarDT.First(x => x.ID == gelenveri.KullaniciBilgileri.Id);

                    veri.AdSoyad = gelenveri.KullaniciBilgileri.AdSoyad;
                    veri.KullaniciAdi = gelenveri.KullaniciBilgileri.KullaniciAdi;
                    veri.Email = gelenveri.KullaniciBilgileri.Email;
                    veri.Sifre = gelenveri.KullaniciBilgileri.Sifre;
                    veri.GuncellenmeTarihi = DateTime.Now;
                    veri.GuncelleyenKisiID = Guid.Parse(User.Identity.Name);
                 
                    var file = Request.Files[0];
                    if (file != null && !string.IsNullOrEmpty(file.FileName))
                    {
                        veri.Resim = IndexController.ResimveyaDosyaKaydet(file, true, veri.Resim, "ResimKullanici");
                    }
                    db.Entry(veri).CurrentValues.SetValues(veri);
                    db.SaveChanges();
                }
                if (User.Identity.Name != gelenveri.KullaniciBilgileri.Id.ToString())
                {
                    TempData["JavaScriptAlertYonetim"] = IndexController.AlertBildirim(IndexController.AlertTip.Basarili, "İşlemi başarılı.");
                    return RedirectToAction("Liste");
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                    return Redirect("/Login");
                }
            }
        }
        [HttpPost]
        public ActionResult GridButonIslemleri(string buttonName, string id)
        {
            using (var db = new FormTableDBEntities())
            {
                switch (buttonName)
                {
                    case "Düzenle":
                        return RedirectToAction("Tanimla", new { id });
                    case "Sil":
                        var veri = db.KullanicilarDT.AsNoTracking().Where(x => x.AktifMi).OrderByDescending(x => x.OlusturulmaTarihi).Select(x => new KullaniciBilgileriClass
                        {
                            Id = x.ID,
                            Resim = x.Resim,
                            KullaniciAdi = x.KullaniciAdi,
                            Email=x.Email, 
                            Sifre=x.Sifre,
                            AdSoyad = x.AdSoyad
                        }).ToList();
                        return PartialView("Liste", veri);
                    default:
                        return RedirectToAction("Liste");
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool KullaniciSil(string id)
        {
            using (var db = new FormTableDBEntities())
            {
                if (Guid.TryParse(id, out var gelenid))
                {
                    var veri = db.KullanicilarDT.FirstOrDefault(x => x.ID == gelenid);
                    if (veri != null)
                    {
                        if (veri.Resim != null) System.IO.File.Delete(Server.MapPath(veri.Resim));
                        veri.SilinmeTarihi = DateTime.Now;
                        veri.SilenKisiID = Guid.Parse(User.Identity.Name);
                        veri.AktifMi = false;
                        veri.Resim = null;
                        db.Entry(veri).CurrentValues.SetValues(veri);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        public ActionResult ProfilSayfasi()
        {
            var kullaniciveri = IndexController.KullaniciBilgileri(User.Identity.Name);
            return View(kullaniciveri);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfilKaydet(KullaniciBilgileriClass gelenveri)
        {
            using (var db = new FormTableDBEntities())
            {
                var veri = db.KullanicilarDT.First(x => x.ID == gelenveri.Id);
                veri.AdSoyad = gelenveri.AdSoyad;
                veri.KullaniciAdi = gelenveri.KullaniciAdi;
                veri.Email = gelenveri.Email;
                veri.Sifre = gelenveri.Sifre;
                veri.GuncellenmeTarihi = DateTime.Now;
                veri.GuncelleyenKisiID = Guid.Parse(User.Identity.Name);
              
                var file = Request.Files[0];
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    veri.Resim = IndexController.ResimveyaDosyaKaydet(file, true, veri.Resim, "ResimKullanici");
                }
                db.Entry(veri).CurrentValues.SetValues(veri);
                db.SaveChanges();
                FormsAuthentication.SignOut();
                Session.Abandon();
                return Redirect("/Login");
            }
        }


    }
}