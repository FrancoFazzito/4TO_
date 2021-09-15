using System.Web;
using System.Web.Optimization;

namespace MCGA.WebSite
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js",
						"~/Scripts/jquery-ui-{version}.js",
						"~/Scripts/stacktable.js",
						"~/Scripts/moment.js",
						"~/Scripts/fullcalendar.js",
						"~/Scripts/locale-all.js"));

			   
					//< script type = "text/javascript" src = "//cdnjs.cloudflare.com/ajax/libs/qtip2/3.0.3/jquery.qtip.min.js" ></ script >


			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
						"~/Scripts/bootstrap.js",
						"~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
						"~/Content/bootstrap.min.css",
						"~/Content/themes/base/jquery-ui.css",
						"~/Content/font-awesome.min.css",
						"~/Content/PagedList.min.css",
						"~/Content/site.min.css",
						"~/Content/fullcalendar.min.css"));


				//< link rel = "stylesheet" href = "//cdnjs.cloudflare.com/ajax/libs/qtip2/3.0.3/jquery.qtip.min.css" />
  
		}
	}
}
