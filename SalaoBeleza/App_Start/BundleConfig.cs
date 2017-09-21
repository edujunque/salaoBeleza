using System.Web;
using System.Web.Optimization;

namespace SalaoBeleza
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/jquery-ui-1.12.1.js",
                    "~/Scripts/bootstrap.min.js",
                    "~/Scripts/jquery.slimscroll.min.js",
                    "~/Scripts/fastclick.js",
                    "~/Scripts/adm-lte/adminlte.min.js" ,
                    "~/Scripts/adm-lte/demo.js",
                    "~/Content/plugins/iCheck/icheck.min.js",
                    "~/Scripts/moment.js",
                    "~/Scripts/bootstrap-datetimepicker.js",
                    "~/Scripts/jquery.dataTables.min.js",
                    "~/Scripts/dataTables.bootstrap.min.js"
                 ));

            bundles.Add(new ScriptBundle("~/bundles/Site").Include(
                    "~/Scripts/_partialViewCalendar.js",
                    "~/Scripts/dataTableCall.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css_bundle").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/font-awesome.min.css",
                    "~/Content/ionicons.min.css",
                    "~/Content/admin-lte/css/AdminLTE.min.css",
                    "~/Content/admin-lte/css/skins/all-skins.css",
                    "~/Content/plugins/iCheck/square/blue.css",
                    "~/Content/bootstrap-datetimepicker.css",
                    "~/Content/dataTables.bootstrap.min.css",
                    "~/Content/site.css"
            ));

            
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            //~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
            "~/Scripts/Inputmask/inputmask.js",
            "~/Scripts/Inputmask/jquery.inputmask.js",
            "~/Scripts/Inputmask/inputmask.extensions.js",
            "~/Scripts/Inputmask/inputmask.date.extensions.js",
            //and other extensions you want to include
            "~/Scripts/Inputmask/inputmask.numeric.extensions.js",
            "~/Scripts/Inputmask/configurationMask.js"
            ));

        }
    }
}
