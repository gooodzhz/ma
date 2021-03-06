﻿using System.Web;
using System.Web.Optimization;

namespace MA.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/hplus").Include(
                "~/Content/hplus/css/bootstrap.min.css",
                "~/Content/hplus/font-awesome/css/font-awesome.css",
                "~/Content/hplus/css/plugins/morris/morris.css",
                "~/Scripts/hplus/js/plugins/gritter/jquery.gritter.css",
                "~/Content/hplus/css/animate.css",
                "~/Content/hplus/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/hplus").Include(
                "~/Scripts/hplus/js/jquery-2.1.1.min.js",
                "~/Scripts/hplus/js/bootstrap.min.js",
                "~/Scripts/hplus/js/plugins/metisMenu/jquery.metisMenu.js",
                "~/Scripts/hplus/js/plugins/slimscroll/jquery.slimscroll.min.js",
                "~/Scripts/hplus/js/hplus.js",
                "~/Scripts/hplus/js/plugins/pace/pace.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/pager").Include(
                "~/Scripts/zhz/pager.js",
                "~/Scripts/zhz/zhz.js"
                ));
        }
    }
}
