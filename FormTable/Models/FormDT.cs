//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormTable.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FormDT
    {
        public int ID { get; set; }
        public int SinifNoID { get; set; }
        public int DersID { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string SinifNo { get; set; }
        public string DersAdi { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
        public string Resim { get; set; }
        public System.DateTime OlusturulmaTarihi { get; set; }
        public Nullable<System.Guid> OlusturanKisiID { get; set; }
        public Nullable<System.DateTime> GuncellenmeTarihi { get; set; }
        public Nullable<System.Guid> GuncelleyenKisiID { get; set; }
        public Nullable<System.DateTime> SilinmeTarihi { get; set; }
        public Nullable<System.Guid> SilenKisiID { get; set; }
        public bool AktifMi { get; set; }
    
        public virtual DersDT DersDT { get; set; }
        public virtual SinifNoDT SinifNoDT { get; set; }
    }
}
