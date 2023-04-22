﻿using System.Windows.Forms;using DevExpress.XtraReports.UI;using System;
using app7.classes;

namespace app7.repost_pos
{
    public partial class en_customers_mdeonea_report : DevExpress.XtraReports.UI.XtraReport
    {
        public en_customers_mdeonea_report()
        {
            InitializeComponent();
        }
        public static void to_pdf(System.Data.DataTable products_datasource)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            en_customers_mdeonea_report report = new en_customers_mdeonea_report();
            report.DetailReport.DataSource = products_datasource;
            report.BindData();
            report.PrinterName = app7.settings_files.main_settings.Default.reports_printer_name;
            saveFileDialog.Filter = "PDF|*.pdf";
            if (products_datasource.Rows.Count == 0) { notifications_class.no_data_message(); return; }
            saveFileDialog.FileName = report.head_label.Text;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                report.ExportToPdf(saveFileDialog.FileName);
        }
        public static void to_excel(System.Data.DataTable products_datasource)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            en_customers_mdeonea_report report = new en_customers_mdeonea_report();
            report.DetailReport.DataSource = products_datasource;
            report.BindData();
            report.PrinterName = app7.settings_files.main_settings.Default.reports_printer_name;
            saveFileDialog.Filter = "Excel|*.xlsx";
            if (products_datasource.Rows.Count == 0) { notifications_class.no_data_message(); return; }
            saveFileDialog.FileName = report.head_label.Text;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                report.ExportToXlsx(saveFileDialog.FileName);
        }
        public static void to_word(System.Data.DataTable products_datasource)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            en_customers_mdeonea_report report = new en_customers_mdeonea_report();
            report.DetailReport.DataSource = products_datasource;
            report.BindData();
            report.PrinterName = app7.settings_files.main_settings.Default.reports_printer_name;
            saveFileDialog.Filter = "Word|*.docx";
            if (products_datasource.Rows.Count == 0) { notifications_class.no_data_message(); return; }
            saveFileDialog.FileName = report.head_label.Text;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                report.ExportToDocx(saveFileDialog.FileName);
        }
        void set_report_detailes()
        {
            drebe_number_label.Text = "Tax Number : " + settings_files.main_settings.Default.tax_number;
            first_phone_label.Text = "Landline : " + settings_files.main_settings.Default.landline;
            second_phone_label.Text = "Mobile : " + settings_files.main_settings.Default.mobile;
            pharmacy_name_label.Text = settings_files.main_settings.Default.barber_name; address_label.Text = "";
            logo_image.ImageUrl = settings_files.main_settings.Default.logo;
        }
        void BindData()
        {
            set_report_detailes();
        }
        public static void print(System.Data.DataTable products_datasource, object main_datasource)
        {
            // 0 Direct
            if (app7.settings_files.main_settings.Default.reports_print_type == 0)
            {
                en_customers_mdeonea_report report = new en_customers_mdeonea_report();
                report.DetailReport.DataSource = products_datasource;
                report.BindData();
                report.PrinterName = app7.settings_files.main_settings.Default.reports_printer_name;
                report.Print();
            }
            else
            {
                en_customers_mdeonea_report report = new en_customers_mdeonea_report();
                report.DetailReport.DataSource = products_datasource;
                report.BindData();
                report.PrinterName = app7.settings_files.main_settings.Default.reports_printer_name;
                report.ShowPreview();
            }

        }
    }
}
