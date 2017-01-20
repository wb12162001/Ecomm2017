﻿using System.Web;
using System.Web.Optimization;

namespace Ecomm.Site.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryupload").Include(
                "~/Scripts/jquery.fileupload.js",
                "~/Scripts/jquery.fileupload-ui.js",
                "~/Scripts/jquery.iframe-transport.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
				"~/Scripts/jquery-ui-{version}.js",
				"~/Scripts/jquery-ui-zh.js"
				));

            bundles.Add(new ScriptBundle("~/bundles/ajaxfileupload").Include(
                "~/Scripts/ajaxfileupload.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            //Plugins
            //bootstrapValidator
            bundles.Add(new ScriptBundle("~/bundles/plugins/bootstrapvalidator/js").Include(
                "~/Content/plugins/bootstrapvalidator/js/bootstrapValidator.min.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/plugins/bootstrapvalidator/css").Include(
                     "~/Content/plugins/bootstrapvalidator/css/bootstrapValidator.min.css"));
            //OwlCarousel
            bundles.Add(new ScriptBundle("~/bundles/plugins/owl-carousel/js").Include(
                "~/Content/plugins/OwlCarousel/owl.carousel.min.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/plugins/owl-carousel/css").Include(
                     "~/Content/plugins/OwlCarousel/owl.carousel.css",
                     "~/Content/plugins/OwlCarousel/owl.theme.css"
                     ));
            //wysihtml5
            bundles.Add(new ScriptBundle("~/bundles/plugins/js/wysihtml5").Include(
                "~/Content/admin/js/handlebars.runtime.min.js",
                "~/Content/plugins/wysihtml5/wysihtml5-0.3.0.js",
                //"~/Content/plugins/wysihtml5/wysihtml5x-toolbar.min.js",
                "~/Content/plugins/wysihtml5/bootstrap-wysihtml5.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/plugins/css/wysihtml5").Include(
                     "~/Content/plugins/wysihtml5/bootstrap-wysihtml5.css"
                     ));

            //---Snell Site---
            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                "~/Content/snell/js/index.js",
                "~/Content/snell/js/bootbox.min.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/snell").Include(
                      "~/Content/snell/css/reset.min.css",
                      "~/Content/snell/css/bootstrap.min.css",
                      "~/Content/snell/css/font-awesome.css",
                      "~/Content/snell/css/index.css"));

            bundles.Add(new StyleBundle("~/bundles/login").Include(
                     "~/Content/snell/css/login.css"));
            //---Admin Site---

            //-----CSS-----
            bundles.Add(new StyleBundle("~/bundles/css/bootstrap2").Include(
                      "~/Content/admin/css/bootstrap.min.css",
                      "~/Content/admin/css/bootstrap-theme.min.css",
                      "~/Content/admin/css/bootstrap-responsive.min.css"));
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap/css/bootstrap.min.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/bundles/css/admin")
                      .Include("~/Content/admin/css/uniform.css", new CssRewriteUrlTransform())
                      .Include("~/Content/admin/css/select2.css", new CssRewriteUrlTransform())
                      .Include("~/Content/admin/css/matrix-style.css", new CssRewriteUrlTransform())
                      .Include("~/Content/admin/css/matrix-media.css", new CssRewriteUrlTransform())
                      .Include("~/Content/admin/css/font.css", new CssRewriteUrlTransform())
                      .Include("~/Content/admin/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform())
                      ); //mvc 加载字体不一样

			bundles.Add(new StyleBundle("~/bundles/css/jqueryui").Include(
					  "~/Content/themes/base/jquery.ui.core.css",
                      //"~/Content/themes/base/jquery.ui.resizable.css",
                      //"~/Content/themes/base/jquery.ui.selectable.css",
                      //"~/Content/themes/base/jquery.ui.accordion.css",
                      "~/Content/themes/base/jquery.ui.autocomplete.css",
                      //"~/Content/themes/base/jquery.ui.button.css",
                      //"~/Content/themes/base/jquery.ui.dialog.css",
                      //"~/Content/themes/base/jquery.ui.slider.css",
                      //"~/Content/themes/base/jquery.ui.tabs.css",
                      "~/Content/themes/base/jquery.ui.datepicker.css",
                      //"~/Content/themes/base/jquery.ui.progressbar.css",
                      "~/Content/themes/base/jquery.ui.theme.css"
					  ));

            //-----JS-----
            bundles.Add(new ScriptBundle("~/bundles/js/admin-jq").Include(
                     "~/Content/admin/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap2").Include(
                     "~/Content/admin/js/bootstrap.min.js",
                     "~/Content/admin/js/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jqdataTables").Include(
                      "~/Content/admin/js/jquery.dataTables.min.js",
                      "~/Content/admin/js/jquery.dataTables.AjaxSource.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/admin-plugin").Include(
                      "~/Content/admin/js/select2.min.js"));
            

        }
    }
}
