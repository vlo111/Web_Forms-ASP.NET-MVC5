#region Using

using System.Web.Optimization;

#endregion

namespace CenDek
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Script

            bundles.Add(new ScriptBundle("~/bundles/forms").Include(
                "~/scripts/plugin/jquery-form/jquery-form.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jq-grid").Include(
                "~/scripts/plugin/jqgrid/jquery.jqGrid.min.js",
                "~/scripts/plugin/jqgrid/grid.locale-en.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                 "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                       "~/Scripts/libs/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/smartadmin").Include(
                "~/scripts/app.config.js",
                "~/scripts/plugin/select2/select2.min.js",
                "~/scripts/smartwidgets/jarvis.widget.min.js",
                "~/scripts/app.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
              "~/scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").IncludeDirectory(
                "~/scripts", "jquery.validate.*").IncludeDirectory(
                "~/scripts", "jquery.unobtrusive-*"));

            bundles.Add(new ScriptBundle("~/bundles/dropzone").Include(
                "~/scripts/dropzone/dropzone.js").Include(
                "~/scripts/dropzone-amd-module.js"));

            bundles.Add(new ScriptBundle("~/bundles/customJs").Include(
             "~/scripts/Home.js"));

            bundles.Add(new ScriptBundle("~/bundles/owl").Include(
                "~/scripts/owl.carousel/owl.carousel.min.js"));
            #endregion
            #region Style

            bundles.Add(new StyleBundle("~/content/smartadmin").IncludeDirectory(
                "~/Content/css", "*.min.css").Include(
                "~/Content/bootstrap.css"));


            bundles.Add(new StyleBundle("~/content/stylevalidator").Include(
                "~/Content/StyleValidator.css"));

            bundles.Add(new StyleBundle("~/content/dropzone").Include(
                "~/Content/dropzone/dropzone.css"));

            bundles.Add(new StyleBundle("~/content/myyy").Include(
                "~/Content/css/your_style.css"));

            bundles.Add(new StyleBundle("~/content/owl").Include(
                "~/scripts/owl.carousel/assets/owl.carousel.css",
                "~/scripts/owl.carousel/assets/owl.theme.default.css"));
            #endregion
            BundleTable.EnableOptimizations = true;

        }
    }
}