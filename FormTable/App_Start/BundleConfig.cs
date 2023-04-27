using System.Web;
using System.Web.Optimization;

namespace FormTable
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/YonetimCss").Include(
    "~/Areas/Yonetim/assets/css/plugins/prism-coy.css",
    "~/Areas/Yonetim/assets/css/plugins/animate.min.css",
    "~/Areas/Yonetim/assets/css/plugins/select2.min.css",
    "~/Areas/Yonetim/assets/css/style.css",
    "~/Areas/Yonetim/assets/css/sweetalert2.min.css",
    "~/Scripts/dropzone/dropzone.min.css"
));

            bundles.Add(new ScriptBundle("~/Content/YonetimJs").Include(
                "~/Areas/Yonetim/assets/js/vendor-all.min.js",
                "~/Areas/Yonetim/assets/js/DevexpressButonIslemleri.js",
                "~/Areas/Yonetim/assets/js/plugins/bootstrap.min.js",
                "~/Areas/Yonetim/assets/js/ripple.js",
                "~/Areas/Yonetim/assets/js/sweetalert2.js",
                "~/Areas/Yonetim/assets/js/horizontal-menu.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/dropzone/dropzone.min.js",
                "~/Areas/Yonetim/assets/js/inputmask.min.js",
                "~/Areas/Yonetim/assets/js/plugins/select2.full.min.js",
                "~/Scripts/js-cookie/js.cookie-2.2.1.min.js",
                "~/Areas/Yonetim/assets/js/YoneticiIslemleri.js"
                //"~/Scripts/jquery.signalR-2.4.2.js"
                ));
        }
    }
}
