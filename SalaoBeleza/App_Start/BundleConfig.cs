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
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/jquery.unobtrusive-ajax.js",
                      "~/Scripts/jquery.validate-vsdoc.js",
                      "~/Scripts/jquery.validate.js",
                      "~/Scripts/jquery.validate.unobtrusive.js",
                      "~/Scripts/globalize.js",
                      "~/Scripts/jquery.validate.globalize.js",
                      "~/Scripts/jquery-ui-1.12.1.js",
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Content/plugins/iCheck/icheck.min.js"

                      ));

            bundles.Add(new ScriptBundle("~/bundles/Site").Include(
                    "~/Scripts/_partialViewCalendar.js",
                    "~/Scripts/dataTableCall.js"
          ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap-paper.css",
                      "~/Content/bootstrap.css",
                      "~/Content/admin-lte/css/AdminLTE.min.css",
                      "~/Content/plugins/iCheck/square/blue.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/bootstrap-datetimepicker.css",
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
