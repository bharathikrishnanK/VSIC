using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace webapp.App_Start
{
    public class Bundleconfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/assets/plugins/jquery-ui-1.12.1/jquery-ui.min.js",
                      "~/assets/bootstrap/js/bootstrap.min.js",
                      "~/assets/plugins/metisMenu/metisMenu.min.js",
                      "~/assets/plugins/lobipanel/lobipanel.min.js",
                      "~/assets/plugins/animsition/js/animsition.min.js"
                       ));


            bundles.Add(new ScriptBundle("~/assets/validatejs").Include(
              "~/assets/validate/jquery-1.12.4.js",
              "~/assets/validate/jquery-1.11.1.min.js",
           "~/assets/validate/jquery.validate.min.js",
           "~/assets/validate/jquery.validate*",
           "~/assets/validate/bootstrap.min.js",
           "~/assets/validate/jquery.unobtrusive*",
           "~/assets/validate/jquery.validate.unobtrusive.min.js"
               ));
            bundles.Add(new StyleBundle("~/assets/validatecss").Include(
               "~/assets/validate/validatebootstrap.min.css",
               "~/assets/validate/style.css"
               ));
            bundles.Add(new StyleBundle("~/assets/pluginscss").Include("~/assets/plugins/datatables/dataTables.min.css"));
            bundles.Add(new ScriptBundle("~/assets/pluginsjs").Include("~/assets/plugins/jQuery/jquery-1.12.4.min.js",
                "~/assets/plugins/datatables/dataTables.min.js", "~/assets/plugins/dataTables.fixedColumns.min.js"));

        }
    }
}