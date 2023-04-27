using FormTable.Areas.Yonetim.ViewModels;
using FormTable.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormTable.Areas.Yonetim.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Yonetim/Anasayfa
        [HttpGet]
        public ActionResult Index(string id)
        {
            using (var db = new FormTableDBEntities())
            {
                try
                {
                    int.TryParse(id, out var gelenid);
                    var formdb = new FormViewModel
                    {
                        Form = gelenid == 0 ? new FormClass() : db.FormDT.AsNoTracking().Where(x => x.AktifMi && x.ID == gelenid).Select(x => new FormClass()
                        {
                            Id = x.ID,
                            Ad = x.Ad,
                            SoyAd = x.SoyAd,
                            //Cinsiyet = x.Cinsiyet,
                            DersID = x.DersID,
                            SinifNoID = x.SinifNoID,
                            SinifNo = x.SinifNoDT.SinifNo,
                            DersAdi = x.DersDT.DersAdi,
                            Konu = x.Konu,
                            Mesaj = x.Mesaj,
                            Resim = x.Resim

                        }).FirstOrDefault(),
                        ListForm = db.FormDT.AsNoTracking().Where(x => x.AktifMi).Select(x => new FormClass()
                        {
                            Id = x.ID,
                            Ad = x.Ad,
                            SoyAd = x.SoyAd,
                            DersID = x.DersID,
                            SinifNoID = x.SinifNoID,
                            SinifNo = x.SinifNoDT.SinifNo,
                            DersAdi = x.DersDT.DersAdi,
                            Konu = x.Konu,
                            Mesaj = x.Mesaj,
                            Resim = x.Resim

                        }).ToList(),
                        ListDers = db.DersDT.AsNoTracking().Where(x => x.AktifMi).Select(x => new DersClass()
                        {
                            Id = x.ID,
                            DersAdi = x.DersAdi
                        }).ToList(),
                        ListSinif = db.SinifNoDT.AsNoTracking().Where(x => x.AktifMi).Select(x => new SinifNoClass()
                        {
                            Id = x.ID,
                            SinifNo = x.SinifNo
                        }).ToList(),
                    };
                    return View("Index", formdb);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult EkleDuzenle(FormViewModel formViewModel)
        {
            using (var db = new FormTableDBEntities())
            {
                if (formViewModel.Form.Id == 0)
                {
                    var veri = new FormDT
                    {
                        Ad = formViewModel.Form.Ad,
                        SoyAd = formViewModel.Form.SoyAd,
                        DersID=formViewModel.Form.DersID,
                        SinifNoID=formViewModel.Form.SinifNoID,
                        DersAdi = formViewModel.Form.DersAdi,
                        SinifNo = formViewModel.Form.SinifNo,
                        Mesaj = formViewModel.Form.Mesaj,
                        Konu = formViewModel.Form.Konu,
                        OlusturulmaTarihi = DateTime.Now,
                        OlusturanKisiID = Guid.Parse(User.Identity.Name),
                        AktifMi = true
                    };

                    var file = Request.Files[0];
                    if (file != null && !string.IsNullOrEmpty(file.FileName))
                    {
                        veri.Resim = IndexController.ResimveyaDosyaKaydet(file, false, "", "ResimSoru");
                    }
                    db.FormDT.Add(veri);
                    db.SaveChanges();

                    TempData["JavaScriptAlertYonetim"] = IndexController.AlertBildirim(IndexController.AlertTip.Basarili, "İşlem Başarılı");
                    return RedirectToAction("Index");
                    
                   
                
                }
                else
                { 
                    var duzenle = db.FormDT.First(x => x.ID == formViewModel.Form.Id);
                    duzenle.Ad = formViewModel.Form.Ad;
                    duzenle.SoyAd = formViewModel.Form.SoyAd;
                    duzenle.DersAdi = formViewModel.Form.DersAdi;
                    duzenle.SinifNo = formViewModel.Form.SinifNo;
                    duzenle.Konu = formViewModel.Form.Konu;
                    duzenle.Mesaj = formViewModel.Form.Mesaj;
                    //duzenle.Cinsiyet = formViewModel.Form.Cinsiyet;
                    duzenle.GuncellenmeTarihi = DateTime.Now;
                    duzenle.GuncelleyenKisiID = Guid.Parse(User.Identity.Name);


                    var file = Request.Files[0];
                    if (file != null && !string.IsNullOrEmpty(file.FileName))
                    {
                        duzenle.Resim = IndexController.ResimveyaDosyaKaydet(file, true, duzenle.Resim, "ResimSoru");
                    }
                    db.Entry(duzenle).CurrentValues.SetValues(duzenle);
                    db.SaveChanges();
                }
               
                    return Redirect("/Login");
                
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
                        return RedirectToAction("Index", new { id });
                    case "Sil":
                        var veri = db.FormDT.AsNoTracking().Where(x => x.AktifMi).OrderByDescending(x => x.OlusturulmaTarihi).Select(x => new FormClass
                        {
                            Id = x.ID,
                            Ad = x.Ad,
                            SoyAd = x.SoyAd,
                            //Cinsiyet = x.Cinsiyet,
                            DersID = x.DersID,
                            SinifNoID = x.SinifNoID,
                            SinifNo = x.SinifNo,
                            DersAdi = x.DersAdi,
                            Konu = x.Konu,
                            Mesaj = x.Mesaj,
                            Resim = x.Resim
                        }).ToList();
                        return PartialView("Index", veri);
                    default:
                        return RedirectToAction("Index");
                }
            }
        }
    }
}