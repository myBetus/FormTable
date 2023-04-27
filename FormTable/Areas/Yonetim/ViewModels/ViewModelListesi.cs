using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace FormTable.Areas.Yonetim.ViewModels
{
        public class KullaniciBilgileriClass
        {
            public Guid Id { get; set; }
         
            public string AdSoyad { get; set; }
            public string Email { get; set; }
            public string KullaniciAdi { get; set; }
            public string Sifre { get; set; }
            public string Resim { get; set; }

        }
        public class LoginViewModel
        {
            public Guid KullaniciId { get; set; }
            public string KullaniciAdi { get; set; }
            public string Sifre { get; set; }
        }

    public class DersClass
    {
        public int  Id { get; set; }

        public string DersAdi { get; set; }

    }

    public class SinifNoClass
    {
        public int Id { get; set; }

        public string SinifNo { get; set; }

    }
    public class FormClass
    {
        public int Id { get; set; }

        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public bool Cinsiyet { get; set; }
        public int SinifNoID { get; set; }
        public int DersID { get; set; }
        public string SinifNo { get; set; }
        public string DersAdi { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
        public string Resim { get; set; }

    }
    public class FormViewModel
    {
        public FormClass Form { get; set; }
        public List<FormClass> ListForm { get; set; }
        public List<DersClass> ListDers { get; set; }
        public List<SinifNoClass> ListSinif { get; set; }

    }
    public class YeniKullaniciViewModel
        {
         public KullaniciBilgileriClass KullaniciBilgileri { get; set; }
         public List<KullaniciBilgileriClass> ListKullaniciBilgileri { get; set; }
    }

    }