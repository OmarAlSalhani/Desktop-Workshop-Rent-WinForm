﻿using System.Windows.Forms;using DevExpress.XtraReports.UI;using System;
using app7.classes;

namespace app7.repost_pos
{
    public partial class daily_report : DevExpress.XtraReports.UI.XtraReport
    {
        public daily_report()
        {
            InitializeComponent();
        }
        void set_report_detailes()
        {
            drebe_number_label.Text = "الرقم الضريبي : " + settings_files.main_settings.Default.tax_number;
            first_phone_label.Text = "الهاتف : " + settings_files.main_settings.Default.landline;
            second_phone_label.Text = "الجوال : " + settings_files.main_settings.Default.mobile;
           pharmacy_name_label.Text = settings_files.main_settings.Default.barber_name;address_label.Text = "";address_label.Text = "";
            logo_image.ImageUrl = settings_files.main_settings.Default.logo;
        }

        void BindData()
        {
            set_report_detailes();
            date_tb.Text = ar_daily_report_form.the_date;
            total_without_tax_tb.Text = ar_daily_report_form.total_without_tax;
            sales_with_tax_tb.Text = ar_daily_report_form.total_with_tax;
            taxex_tb.Text = ar_daily_report_form.taxes;
            snd_kbd_tb.Text = ar_daily_report_form.snd_qbd;
            snd_srf_tb.Text = ar_daily_report_form.snd_srf;
            customers_deon_tb.Text = ar_daily_report_form.customers_deon;
            paied_money_tb.Text = ar_daily_report_form.customers_paied_money;
        }

        public static void print()
        {
            if (settings_files.main_settings.Default.reports_print_type == 0)
            {
                daily_report report = new daily_report();
                report.BindData();
                report.PrinterName = settings_files.main_settings.Default.reports_printer_name;
                report.Print();
            }
            else
            {
                daily_report report = new daily_report();
                report.BindData();
                report.PrinterName = settings_files.main_settings.Default.reports_printer_name;
                report.ShowPreview();
            }

        }
    }
}
