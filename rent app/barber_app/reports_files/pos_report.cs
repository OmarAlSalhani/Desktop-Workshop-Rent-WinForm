using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System;
using app7.classes;
using DevExpress.XtraPrinting;
using app7.settings_files;
namespace app7.repost_pos
{
    public partial class pos_report : DevExpress.XtraReports.UI.XtraReport
    {
        public pos_report()
        {
            InitializeComponent();
        }

        void set_report_detailes()
        {
            drebe_number_label.Text =settings_files.main_settings.Default.tax_number;
            mobile_phone_tb.Text = "الهاتف : " + settings_files.main_settings.Default.landline + " | " + "الجوال : " + settings_files.main_settings.Default.mobile;
            pharmacy_name_label.Text = settings_files.main_settings.Default.barber_name;
            address_label.Text = settings_files.main_settings.Default.town + "," + settings_files.main_settings.Default.al7e + "," + settings_files.main_settings.Default.street;
            logo_image.ImageUrl = settings_files.main_settings.Default.logo;
            qr_image.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(fatora_forms.ar_pos_uc.qr);
        }

        private void BindData()
        {
            set_report_detailes();
            cash_paied_lbl.Text = fatora_forms.ar_sell_fatora_checkout_form.cash_pay.ToString();

            if(fatora_forms.ar_pos_uc.customer_tax_number.Length ==0)
            {
                vat_row.Visible = false;
            }
            if (fatora_forms.ar_pos_uc.customer_address.Length==0)
            {
                address_row.Visible = false;
            }
            if(fatora_forms.ar_pos_uc.customer_second_number.Length==0)
            {
                second_mobile_row.Visible = false;
            }
            customer_tax_number_tb.Text = fatora_forms.ar_pos_uc.customer_tax_number.Length != 0 ? fatora_forms.ar_pos_uc.customer_tax_number : "";
            customer_address_tb.Text = fatora_forms.ar_pos_uc.customer_address.Length > 2 ? fatora_forms.ar_pos_uc.customer_address : "";
            customer_second_mobile_tb.Text = fatora_forms.ar_pos_uc.customer_second_number.Length != 0 ?  fatora_forms.ar_pos_uc.customer_second_number : "";

        }
        public static void print(System.Data.DataTable products_datasource, object main_datasource)
        {
            if (settings_files.main_settings.Default.invoice_print_type == 0)
            {
                pos_report invoice = new pos_report();
                invoice.DataSource = main_datasource;
                invoice.DetailReport.DataSource = products_datasource;
                invoice.BindData();
                invoice.PrinterName = settings_files.main_settings.Default.invoice_printer_name;
                invoice.Print();
            }
            else
            {
                pos_report invoice = new pos_report();
                invoice.DataSource = main_datasource;
                invoice.DetailReport.DataSource = products_datasource;
                invoice.BindData();
                invoice.PrinterName = settings_files.main_settings.Default.invoice_printer_name;
                invoice.ShowPreview();
            }


        }
    }
}
