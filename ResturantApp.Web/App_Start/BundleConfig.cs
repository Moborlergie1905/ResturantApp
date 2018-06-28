using System.Web;
using System.Web.Optimization;

namespace ResturantApp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize.js"));
            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                      "~/Scripts/sb-admin/sb-admin.min.js",
                      "~/Scripts/jquery-easing/jquery.easing.min.js",
                      "~/Scripts/datatables/jquery.dataTables.js",
                      "~/Scripts/datatables/dataTables.bootstrap4.js"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                      "~/Scripts/MyScript.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/sb-admin/sb-admin.css",
                      "~/Content/Site.css",
                      "~/Scripts/datatables/dataTable.bootstrap4.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/awesome").Include(
                      "~/Content/font-awesome/css/font-awesome.min.css"));
        }
    }
}
