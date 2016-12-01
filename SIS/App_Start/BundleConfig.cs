using System.Web.Optimization;

namespace SIS
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterLayout(bundles);

            RegisterShared(bundles);

            RegisterAccount(bundles);

            RegisterHome(bundles);

            RegisterCharts(bundles);

            RegisterWidgets(bundles);

            RegisterElements(bundles);

            RegisterForms(bundles);

            RegisterTables(bundles);

            RegisterCalendar(bundles);

            RegisterMailbox(bundles);

            RegisterExamples(bundles);

            RegisterDocumentation(bundles);
        }

        private static void RegisterDocumentation(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Documentation/menu").Include(
                "~/Scripts/Documentation/Documentation-menu.js"));
        }

        private static void RegisterExamples(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Examples/Blank/menu").Include(
                "~/Scripts/Examples/Blank-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Invoice/menu").Include(
                "~/Scripts/Examples/Invoice-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Lockscreen/menu").Include(
                "~/Scripts/Examples/Lockscreen-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Login").Include(
                "~/Scripts/Examples/Login.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Login/menu").Include(
                "~/Scripts/Examples/Login-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/P404/menu").Include(
                "~/Scripts/Examples/P404-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/P500/menu").Include(
                "~/Scripts/Examples/P500-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Pace").Include(
                "~/Scripts/Examples/Pace.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Pace/menu").Include(
                "~/Scripts/Examples/Pace-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/ProfileEx/menu").Include(
                "~/Scripts/Examples/ProfileEx-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Register").Include(
                "~/Scripts/Examples/Register.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Examples/Register/menu").Include(
                "~/Scripts/Examples/Register-menu.js"));
        }



        private static void RegisterMailbox(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Inbox").Include(
                "~/Scripts/Mailbox/Inbox.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Inbox/menu").Include(
                "~/Scripts/Mailbox/Inbox-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Compose").Include(
                "~/Scripts/Mailbox/Compose.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Compose/menu").Include(
               "~/Scripts/Mailbox/Compose-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Mailbox/Read/menu").Include(
                "~/Scripts/Mailbox/Read-menu.js"));
        }

        private static void RegisterCalendar(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Calendar").Include(
                "~/Scripts/Calendar/Calendar.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Calendar/menu").Include(
                "~/Scripts/Calendar/Calendar-menu.js"));
        }

        private static void RegisterTables(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Tables/Simple/menu").Include(
                "~/Scripts/Tables/Simple-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Tables/Data").Include(
                "~/Scripts/Tables/Data.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Tables/Data/menu").Include(
                "~/Scripts/Tables/Data-menu.js"));
        }

        private static void RegisterForms(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Forms/Advanced").Include(
                "~/Scripts/Forms/Advanced.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Forms/Advanced/menu").Include(
                "~/Scripts/Forms/Advanced-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Forms/Editors").Include(
                "~/Scripts/Forms/Editors.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Forms/Editors/menu").Include(
                "~/Scripts/Forms/Editors-menu.js"));


            bundles.Add(new ScriptBundle("~/Scripts/Forms/General/menu").Include(
                "~/Scripts/Forms/General-menu.js"));
        }

        private static void RegisterElements(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Elements/Buttons/menu").Include(
                "~/Scripts/Elements/Buttons-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/General/menu").Include(
                "~/Scripts/Elements/General-menu.js"));

            bundles.Add(new StyleBundle("~/Styles/Elements/General").Include(
                "~/Styles/Elements/General.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/Icons/menu").Include(
                "~/Scripts/Elements/Icons-menu.js"));

            bundles.Add(new StyleBundle("~/Styles/Elements/Icons").Include(
                "~/Styles/Elements/Icons.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/Modals/menu").Include(
                "~/Scripts/Elements/Modals-menu.js"));

            bundles.Add(new StyleBundle("~/Styles/Elements/Modals").Include(
                "~/Styles/Elements/Modals.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/Sliders").Include(
                "~/Scripts/Elements/Sliders.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/Sliders/menu").Include(
                "~/Scripts/Elements/Sliders-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Elements/Timeline/menu").Include(
                "~/Scripts/Elements/Timeline-menu.js"));
        }

        private static void RegisterWidgets(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Widgets/menu").Include(
                "~/Scripts/Widgets/Widgets-menu.js"));
        }

        private static void RegisterCharts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Charts/ChartsJs").Include(
                "~/Scripts/Charts/ChartsJs.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Charts/ChartsJs/menu").Include(
                            "~/Scripts/Charts/ChartsJs-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Morris").Include(
                "~/Scripts/Charts/Morris.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Morris/menu").Include(
                "~/Scripts/Charts/Morris-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Flot").Include(
                "~/Scripts/Charts/Flot.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Flot/menu").Include(
                "~/Scripts/Charts/Flot-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Inline").Include(
                "~/Scripts/Charts/Inline.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Charts/Inline/menu").Include(
                "~/Scripts/Charts/Inline-menu.js"));
        }

        private static void RegisterHome(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV1").Include(
                "~/Scripts/Home/DashboardV1.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV1/menu").Include(
                "~/Scripts/Home/DashboardV1-menu.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV2").Include(
                "~/Scripts/Home/DashboardV2.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Home/DashboardV2/menu").Include(
                "~/Scripts/Home/DashboardV2-menu.js"));
        }

        private static void RegisterAccount(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Account/Login").Include(
                "~/Scripts/Account/Login.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Account/Register").Include(
                "~/Scripts/Account/Register.js"));
        }

        private static void RegisterShared(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Shared/_Layout").Include(
                "~/Scripts/Shared/_Layout.js"));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bundles"></param>
        private static void RegisterLayout(BundleCollection bundles)
        {
            // bootstrap
            bundles.Add(new ScriptBundle("~/Content/bootstrap/js").Include(
                "~/Content/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                "~/Content/bootstrap/css/bootstrap.min.css"));

            // dist
            bundles.Add(new ScriptBundle("~/Content/dist/js").Include(
                "~/Content/dist/js/app.js"));

            bundles.Add(new StyleBundle("~/Content/dist/css").Include(
                "~/Content/dist/css/admin-lte.min.css"));

            bundles.Add(new StyleBundle("~/Content/dist/css/skins").Include(
                "~/Content/dist/css/skins/_all-skins.min.css"));

            // documentation
            bundles.Add(new ScriptBundle("~/Content/documentation/js").Include(
                "~/Content/documentation/js/docs.js"));

            bundles.Add(new StyleBundle("~/Content/documentation/css").Include(
                "~/Content/documentation/css/style.css"));

            // plugins | bootstrap-slider
            bundles.Add(new ScriptBundle("~/Content/plugins/bootstrap-slider/js").Include(
                                        "~/Content/plugins/bootstrap-slider/js/bootstrap-slider.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/bootstrap-slider/css").Include(
                                        "~/Content/plugins/bootstrap-slider/css/slider.css"));

            // plugins | bootstrap-wysihtml5
            bundles.Add(new ScriptBundle("~/Content/plugins/bootstrap-wysihtml5/js").Include(
                                         "~/Content/plugins/bootstrap-wysihtml5/js/bootstrap3-wysihtml5.all.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/bootstrap-wysihtml5/css").Include(
                                        "~/Content/plugins/bootstrap-wysihtml5/css/bootstrap3-wysihtml5.min.css"));

            // plugins | custome-theme
            bundles.Add(new ScriptBundle("~/Content/themes/CustomTheme/js").Include(
                 "~/Content/themes/CustomeTheme/js/custom.min.js"));

            bundles.Add(new StyleBundle("~/Content/themes/CustomTheme/css").Include(
                                       "~/Content/themes/CustomTheme/css/custom.min.css"));

            // plugins | chartjs
            bundles.Add(new ScriptBundle("~/Content/plugins/chartjs/js").Include(
                                         "~/Content/plugins/chartjs/js/chart.min.js"));

            // plugins | ckeditor
            bundles.Add(new ScriptBundle("~/Content/plugins/ckeditor/js").Include(
                                         "~/Content/plugins/ckeditor/js/ckeditor.js"));

            // plugins | colorpicker
            bundles.Add(new ScriptBundle("~/Content/plugins/colorpicker/js").Include(
                                         "~/Content/plugins/colorpicker/js/bootstrap-colorpicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/colorpicker/css").Include(
                                        "~/Content/plugins/colorpicker/css/bootstrap-colorpicker.css"));

            // plugins | datatables
            bundles.Add(new ScriptBundle("~/Content/plugins/datatables/js").Include(
                                         "~/Content/plugins/datatables/js/jquery.dataTables.min.js",
                                         "~/Content/plugins/datatables/js/dataTables.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/datatables/css").Include(
                                        "~/Content/plugins/datatables/css/dataTables.bootstrap.css"));

            // plugins | datepicker
            bundles.Add(new ScriptBundle("~/Content/plugins/datepicker/js").Include(
                                         "~/Content/plugins/datepicker/js/bootstrap-datepicker.js",
                                         "~/Content/plugins/datepicker/js/locales/bootstrap-datepicker*"));

            bundles.Add(new StyleBundle("~/Content/plugins/datepicker/css").Include(
                                        "~/Content/plugins/datepicker/css/datepicker3.css"));

            // plugins | daterangepicker
            bundles.Add(new ScriptBundle("~/Content/plugins/daterangepicker/js").Include(
                                         "~/Content/plugins/daterangepicker/js/moment.min.js",
                                         "~/Content/plugins/daterangepicker/js/daterangepicker.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/daterangepicker/css").Include(
                                        "~/Content/plugins/daterangepicker/css/daterangepicker-bs3.css"));

            // plugins | fastclick
            bundles.Add(new ScriptBundle("~/Content/plugins/fastclick/js").Include(
                                         "~/Content/plugins/fastclick/js/fastclick.min.js"));

            // plugins | flot
            bundles.Add(new ScriptBundle("~/Content/plugins/flot/js").Include(
                                         "~/Content/plugins/flot/js/jquery.flot.min.js",
                                         "~/Content/plugins/flot/js/jquery.flot.resize.min.js",
                                         "~/Content/plugins/flot/js/jquery.flot.pie.min.js",
                                         "~/Content/plugins/flot/js/jquery.flot.categories.min.js"));

            // plugins | font-awesome
            bundles.Add(new StyleBundle("~/Content/plugins/font-awesome/css").Include(
                                        "~/Content/plugins/font-awesome/css/font-awesome.min.css"));

            // plugins | fullcalendar
            bundles.Add(new ScriptBundle("~/Content/plugins/fullcalendar/js").Include(
                                         "~/Content/plugins/fullcalendar/js/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/fullcalendar/css").Include(
                                        "~/Content/plugins/fullcalendar/css/fullcalendar.min.css"));

            bundles.Add(new StyleBundle("~/Content/plugins/fullcalendar/css/print").Include(
                                        "~/Content/plugins/fullcalendar/css/print/fullcalendar.print.css"));

            // plugins | icheck
            bundles.Add(new ScriptBundle("~/Content/plugins/icheck/js").Include(
                                         "~/Content/plugins/icheck/js/icheck.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/icheck/css").Include(
                                        "~/Content/plugins/icheck/css/all.css"));

            bundles.Add(new StyleBundle("~/Content/plugins/icheck/css/flat").Include(
                                        "~/Content/plugins/icheck/css/flat/flat.css"));

            bundles.Add(new StyleBundle("~/Content/plugins/icheck/css/sqare/blue").Include(
                                        "~/Content/plugins/icheck/css/sqare/blue.css"));

            // plugins | input-mask
            bundles.Add(new ScriptBundle("~/Content/plugins/input-mask/js").Include(
                                         "~/Content/plugins/input-mask/js/jquery.inputmask.js",
                                         "~/Content/plugins/input-mask/js/jquery.inputmask.date.extensions.js",
                                         "~/Content/plugins/input-mask/js/jquery.inputmask.extensions.js"));

            // plugins | ionicons
            bundles.Add(new StyleBundle("~/Content/plugins/ionicons/css").Include(
                                        "~/Content/plugins/ionicons/css/ionicons.min.css"));

            // plugins | ionslider
            bundles.Add(new ScriptBundle("~/Content/plugins/ionslider/js").Include(
                                         "~/Content/plugins/ionslider/js/ion.rangeSlider.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/ionslider/css").Include(
                                        "~/Content/plugins/ionslider/css/ion.rangeSlider.css",
                                        "~/Content/plugins/ionslider/css/ion.rangeSlider.skinNice.css"));

            // plugins | jquery
            bundles.Add(new ScriptBundle("~/Content/plugins/jquery/js").Include(
                                         "~/Content/plugins/jquery/js/jQuery-2.1.4.min.js",
                                         "~/Scripts/jquery-{version}.js",
                                         "~/Scripts/jquery-ui-{version}.js"));

            // plugins | jquery-validate
            bundles.Add(new ScriptBundle("~/Content/plugins/jquery-validate/js").Include(
                                         "~/Content/plugins/jquery-validate/js/jquery.validate*",
                                         "~/Content/Plugins/bootstrap-multiselect/css/bootstrap-multiselect.css",
                                         "~/Content/Plugins/bootstrap-multiselect/js/bootstrap-multiselect.js"));

            // plugins | jquery-ui
            bundles.Add(new ScriptBundle("~/Content/plugins/jquery-ui/js").Include(
                                         "~/Content/plugins/jquery-ui/js/jquery-ui.min.js"));

            // plugins | jvectormap
            bundles.Add(new ScriptBundle("~/Content/plugins/jvectormap/js").Include(
                                         "~/Content/plugins/jvectormap/js/jquery-jvectormap-1.2.2.min.js",
                                         "~/Content/plugins/jvectormap/js/jquery-jvectormap-world-mill-en.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/jvectormap/css").Include(
                                        "~/Content/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css"));

            // plugins | knob
            bundles.Add(new ScriptBundle("~/Content/plugins/knob/js").Include(
                                         "~/Content/plugins/knob/js/jquery.knob.js"));

            // plugins | morris
            bundles.Add(new StyleBundle("~/Content/plugins/morris/css").Include(
                                        "~/Content/plugins/morris/css/morris.css"));

            // plugins | momentjs
            bundles.Add(new ScriptBundle("~/Content/plugins/momentjs/js").Include(
                                         "~/Content/plugins/momentjs/js/moment.min.js"));

            // plugins | pace
            bundles.Add(new ScriptBundle("~/Content/plugins/pace/js").Include(
                                         "~/Content/plugins/pace/js/pace.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/pace/css").Include(
                                        "~/Content/plugins/pace/css/pace.min.css"));

            // plugins | slimscroll
            bundles.Add(new ScriptBundle("~/Content/plugins/slimscroll/js").Include(
                                         "~/Content/plugins/slimscroll/js/jquery.slimscroll.min.js"));

            // plugins | sparkline
            bundles.Add(new ScriptBundle("~/Content/plugins/sparkline/js").Include(
                                         "~/Content/plugins/sparkline/js/jquery.sparkline.min.js"));

            // plugins | timepicker
            bundles.Add(new ScriptBundle("~/Content/plugins/timepicker/js").Include(
                                         "~/Content/plugins/timepicker/js/bootstrap-timepicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/timepicker/css").Include(
                                        "~/Content/plugins/timepicker/css/bootstrap-timepicker.min.css"));

            // plugins | raphael
            bundles.Add(new ScriptBundle("~/Content/plugins/raphael/js").Include(
                                         "~/Content/plugins/raphael/js/raphael-min.js"));

            // plugins | select2
            bundles.Add(new ScriptBundle("~/Content/plugins/select2/js").Include(
                                         "~/Content/plugins/select2/js/select2.full.min.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/select2/css").Include(
                                        "~/Content/plugins/select2/css/select2.min.css"));

            // plugins | morris
            bundles.Add(new ScriptBundle("~/Content/plugins/morris/js").Include(
                                         "~/Content/plugins/morris/js/morris.min.js"));

            // plugins | nprogress
            bundles.Add(new ScriptBundle("~/Content/plugins/nprogress/js").Include(
                                        "~/Content/plugins/nprogress/js/nprogress.js"));

            // plugins | Multiselect
            bundles.Add(new ScriptBundle("~/Content/plugins/bootstrap-multiselect").Include(
                 "~/Content/plugins/bootstrap-multiselect/js/bootstrap-multiselect.js"));

            bundles.Add(new StyleBundle("~/Content/plugins/bootstrap-multiselect").Include(
                "~/Content/plugins/bootstrap-multiselect/css/bootstrap-multiselect.css"));

            // Scripts | Modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                                         "~/Scripts/modernizr-*"));
        }
    }
}
