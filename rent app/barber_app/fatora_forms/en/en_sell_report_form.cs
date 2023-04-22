﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using app7.settings_files;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using app7.classes;

namespace app7.fatora_forms.en
{
    public partial class en_sell_report_form : XtraForm
    {

        public en_sell_report_form()
        {
            InitializeComponent();
            first_date.DateTime = last_date.DateTime = DateTime.Now;
            my_grid_view_class.set_find_panel_font2(gridView2, gridControl2, true, true);
            my_grid_view_class.show_empty_message2(gridView2);
            my_grid_view_class.set_font_and_hover_effect(gridView2);
        }
        bool convert_int32(int num, string textbox)
        {
            if (!int.TryParse(textbox, out num))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        void uncheck_radio()
        {
            if (date_cbx.Checked || username_cbx.Checked || customer_cbx.Checked)
            {
                id_barcode_radio.Checked = false;
            }
        }
        int choices()
        {
            int c = 2;
            if (id_barcode_radio.Checked)
            {
                c = 1;
            }
            if (date_cbx.Checked && username_cbx.Checked == false && customer_cbx.Checked == false)
            {
                c = 2;
            }
            if (username_cbx.Checked && date_cbx.Checked == false && customer_cbx.Checked == false)
            {
                c = 3;
            }
            if (customer_cbx.Checked && date_cbx.Checked == false && username_cbx.Checked == false)
            {
                c = 4;
            }
            return c;
        }
        string query(int choices)
        {
            string f = first_date.DateTime.ToString("dd-MM-yyyy");
            string l = last_date.DateTime.ToString("dd-MM-yyyy");
            string a = "";
            if (choices == 1)
            {
                a = $@"SELECT [fatora_id] as 'Invoice ID'
      ,[bill_type] as 'Invoice type'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'Date and time'
      ,customer_name as 'Customer'
      ,[total_before_taxes] as 'Total before tax',[taxes] as 'Tax',[total_amount] as 'Total after tax',[net_amount] as 'Total'
	  ,[paied_money] as 'Paied'
      ,[net_amount] as 'Remaining'
	  
      ,(select username from users_table where users_table.user_id=userID) as 'Username'  
  FROM [sales_head_table] where fatora_id={Convert.ToInt32(id_barcode_tb.Text)}";
            }
            if (choices == 2)
            {
                a = $@"SELECT [fatora_id] as 'Invoice ID'
      ,[bill_type] as 'Invoice type'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'Date and time'
      ,customer_name as 'Customer'
      ,[total_before_taxes] as 'Total before tax',[taxes] as 'Tax',[total_amount] as 'Total after tax',[net_amount] as 'Total'
	  ,[paied_money] as 'Paied'
      ,[net_amount] as 'Remaining'
	  
      ,(select username from users_table where users_table.user_id=userID) as 'Username'  
  FROM [sales_head_table] where sell_date between convert(date,'{f}',105) and convert(date,'{l}',105)";
            }
            if (choices == 3)
            {
                a = $@"SELECT [fatora_id] as 'Invoice ID'
      ,[bill_type] as 'Invoice type'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'Date and time'
      ,customer_name as 'Customer'
      ,[total_before_taxes] as 'Total before tax',[taxes] as 'Tax',[total_amount] as 'Total after tax',[net_amount] as 'Total'
	  ,[paied_money] as 'Paied'
      ,[net_amount] as 'Remaining'
	  
      ,(select username from users_table where users_table.user_id=userID) as 'Username'  
  FROM [sales_head_table] where userID=(select user_id from users_table where username=N'{username_cb.Text}')";
            }
            if (choices == 4)
            {
                a = $@"SELECT [fatora_id] as 'Invoice ID'
      ,[bill_type] as 'Invoice type'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'Date and time'
      ,customer_name as 'Customer'
      ,[total_before_taxes] as 'Total before tax',[taxes] as 'Tax',[total_amount] as 'Total after tax',[net_amount] as 'Total'
	  ,[paied_money] as 'Paied'
      ,[net_amount] as 'Remaining'
	  
      ,(select username from users_table where users_table.user_id=userID) as 'Username'  
  FROM [sales_head_table] where customer_name=N'{customer_name_cb.Text}'";
            }
            return a;
        }
        private void id_barcode_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (id_barcode_radio.Checked)
            {
                date_cbx.Checked = customer_cbx.Checked = username_cbx.Checked = false;
            }
        }

        private void date_cbx_CheckedChanged(object sender, EventArgs e)
        {
            uncheck_radio();
        }

        private void show_report_btn_Click(object sender, EventArgs e)
        {
            if (date_cbx.Checked == false && id_barcode_radio.Checked == false && username_cbx.Checked == false && customer_cbx.Checked == false)
            {
                OmarNotifications.Alert.ShowInformation("Select search options");
                return;
            }
            if (id_barcode_radio.Checked)
            {
                if (texts_class.is_null(id_barcode_tb.Text))
                {
                    OmarNotifications.Alert.ShowInformation("Enter invoice id");
                    return;
                }
                else
                {
                    int invoice_id = 0;
                    if (convert_int32(invoice_id, id_barcode_tb.Text) == false)
                    {
                        OmarNotifications.Alert.ShowInformation("ID incorrect");
                        return;
                    }
                }
            }
            DataTable table = connection_class.select(query(choices()));
            if (table.Rows.Count == 0)
            {
                notifications_class.grid_message();
                gridControl2.DataSource = null;
                return;
            }
            my_grid_view_class.set_datasource(gridControl2, gridView2, table);
            my_grid_view_class.set_summary(gridView2, "Total after tax");
            my_grid_view_class.set_summary(gridView2, "Total before tax");
            my_grid_view_class.set_summary(gridView2, "Total");
            my_grid_view_class.set_summary(gridView2, "Tax");
            my_grid_view_class.set_summary(gridView2, "Paied");
            my_grid_view_class.set_summary(gridView2, "Remaining");
        }
        public static string from_date, to_date;
        private void print_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            repost_pos.en_sales_report.print(my_grid_view_class.gridview_to_data_table(gridView2), null);

        }

        private void en_sell_report_form_Load(object sender, EventArgs e)
        {
            DataTable table = connection_class.select(@"SELECT [fatora_id] as 'Invoice ID'
      ,[bill_type] as 'Invoice type'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'Date and time'
      ,customer_name as 'Customer'
      ,[total_before_taxes] as 'Total before tax',[taxes] as 'Tax',[total_amount] as 'Total after tax',[net_amount] as 'Total'
	  ,[paied_money] as 'Paied'
      ,[net_amount] as 'Remaining'
	  
      ,(select username from users_table where users_table.user_id=userID) as 'Username'   
  FROM [sales_head_table] where 1 = 2");
            my_grid_view_class.set_datasource(gridControl2, gridView2, table);
            if (fill_cb_worker.IsBusy == false)
                fill_cb_worker.RunWorkerAsync();
        }
        DataTable customers_table, users_table, bill_type_table;
        private void fill_cb_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            customers_table = connection_class.select("select distinct customer_name as 'Customer' from sales_head_table");
            users_table = connection_class.select("select distinct username as 'Username' from users_table");
            bill_type_table = connection_class.select("select distinct bill_type as 'Invoice type' from sales_head_table");
        }

        private void fill_cb_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            classes.lookup_edit_class.fill_lookup(customers_table, customer_name_cb, "Customer");
            classes.lookup_edit_class.fill_lookup(users_table, username_cb, "Username");
        }

        private void word_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            repost_pos.en_sales_report.to_word(my_grid_view_class.gridview_to_data_table(gridView2));
        }
        void openForm(XtraForm form, bool m = false)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.IconOptions.ShowIcon = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = m;
            form.Text = "";
            form.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress);
            form.Show();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
          if(gridView2.SelectedRowsCount>1)
            {
                OmarNotifications.Alert.ShowInformation("Select one invoice");
                return;
            }
            string invoice_number = gridView2.GetFocusedRowCellValue(gridView2.Columns[0].FieldName).ToString();
           en_fatora_detailes_form form = new en_fatora_detailes_form();
            en_fatora_detailes_form.invoice_number = invoice_number;
            form.head_label.Text = $"Invoice detailes {invoice_number}";
            openForm(new en_fatora_detailes_form());
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            repost_pos.en_sales_report.to_excel(my_grid_view_class.gridview_to_data_table(gridView2));
        }

        private void pdf_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            repost_pos.en_sales_report.to_pdf(my_grid_view_class.gridview_to_data_table(gridView2));
        }
        public static int fatora_id;

    }
}