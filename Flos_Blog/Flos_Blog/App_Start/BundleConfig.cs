using System.Web;
using System.Web.Optimization;

namespace Flos_Blog
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(                       
                        "~/Scripts/AngularCore/angular.js",
                        "~/Scripts/AngularCore/angular-sanitize.js",
                        "~/Scripts/AngularCore/angular-resource.js",
                        "~/Scripts/tinymce.min.js",
                        "~/Scripts/FlosBlogApp.js",
                        "~/Scripts/AngularResources/TextsResource.js",
                        "~/Scripts/AngularControllers/LoginController.js",
                        "~/Scripts/AngularControllers/TextsController.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
        }
    }
}
