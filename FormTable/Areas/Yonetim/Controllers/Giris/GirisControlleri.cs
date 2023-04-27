using FormTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormTable.Areas.Yonetim.Controllers.Giris
{
    public class GirisControlleri : AuthorizeAttribute
    {
        // GET: Yonetim/GirisControlleri
        private readonly string[] _rol;
        public GirisControlleri(params string[] roles)
        {
            this._rol = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            using (var db = new FormTableDBEntities())
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated) return false;
                var authorize = false;//HttpContext.Current.User.Identity.IsAuthenticated;
                foreach (var role in _rol)
                {
                    var link = HttpContext.Current.Request.Url.Host == "localhost";
                    if (role != "All" && !link)
                    {
                        var kullaniciid = Guid.Parse(httpContext.User.Identity.Name);
                        var user = db.KullanicilarDT.Where(x => x.ID == kullaniciid &&  x.AktifMi);
                        authorize = user.Any();
                        if (authorize)
                        {
                            break;
                        }
                    }
                    else
                    {
                        authorize = true;
                        break;
                    }
                }
                return authorize;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            using (var db = new FormTableDBEntities())
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
                else
                {
                    if (!string.IsNullOrEmpty(filterContext.HttpContext.Request.RawUrl))
                    {
                        var izinsizgiris = new IzinsizGirisDT
                        {
                            GirenKisi = Guid.Parse(filterContext.HttpContext.User.Identity.Name),
                            GirmeTarihi = DateTime.Now,
                            GirdigiSayfa = filterContext.HttpContext.Request.RawUrl
                        };
                        db.IzinsizGirisDT.Add(izinsizgiris);
                        db.SaveChanges();
                    }
                    filterContext.HttpContext.Response.StatusCode = 403;
                }
            }
        }
    }
}