using System.Web.Optimization;

namespace SalePizza
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/myscripts").Include( 
                "~/Scripts/myscripts/css/*.css",
                "~/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/fonts/themify/themify-icons.css",
                "~/Scripts/myscripts/vendor/bootstrap/css/bootstrap.min.css",
                "~/Scripts/myscripts/vendor/animate/animate.css",
                "~/Scripts/myscripts/vendor/animsition/css/animsition.min.css",
                "~/Scripts/myscripts/vendor/select2/select2.min.css",
                "~/Scripts/myscripts/vendor/slick/slick.css",
                "~/Scripts/myscripts/vendor/lightbox2/css/lightbox.min.css",
                "~/Scripts/myscripts/vendor/daterangepicker/daterangepicker.css",
                "~/Scripts/myscripts/vendor/css-hamburgers/hamburgers.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
