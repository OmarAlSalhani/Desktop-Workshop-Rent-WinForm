﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using app7.classes;
using app7.settings_files;
using System.Data.SqlClient;

namespace app7.fatora_forms
{
    public partial class ar_pos_uc : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// delete from head table
        /// delete from body table
        /// </summary>
        /// 
        void openForm(XtraForm form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.IconOptions.ShowIcon = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.Text = "";
            form.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress);
            form.ShowDialog();
        }
        public ar_pos_uc()
        {
            InitializeComponent();
            my_grid_view_class.set_find_panel_font2(main_gridview, quantites_grid_control, true, false, false);
            my_grid_view_class.set_font_and_hover_effect(main_gridview);
            my_grid_view_class.show_empty_message2(main_gridview);
            repositoryItemButtonEdit1.Click += delegate
            {
                try
                {
                    main_gridview.DeleteRow(main_gridview.FocusedRowHandle);
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }

            };
            repositoryItemLookUpEdit1.EditValueChanged += RepositoryItemLookUpEdit1_EditValueChanged;
        }

        private void RepositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;
            var val = lookUpEdit.EditValue;
            var text = repositoryItemLookUpEdit1.GetDisplayText(val);
            DataTable table = connection_class.select($"select * from products_table where product_name=N'{text}'");
            if (table.Rows.Count != 0)
            {
                double price_before_tax = Convert.ToDouble(table.Rows[0]["daily_rent"]);
                double tax = (price_before_tax * settings_files.main_settings.Default.tax_value) / 100;
                double full_value = price_before_tax + tax;
                main_gridview.SetFocusedRowCellValue(colqty, 1);
                main_gridview.SetFocusedRowCellValue(col_priceBeforeTax, price_before_tax);
                main_gridview.SetFocusedRowCellValue(col_tax, tax);
                main_gridview.SetFocusedRowCellValue(colfull_Value, full_value);
            }
        }

        #region vars_area
        public static string the_date;
        // pos products user control
        // list to prevent add duplicate products to gridview
        public List<string> AddedProducts = new List<string>();
        // to store invoice id 
        public static int FatoraID = 0;

        #endregion
        #region methods_area
        // to check if everything ok before add invoice
        private bool IsEveryThingOK()
        {
            if (main_gridview.RowCount == 0)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء أختيار الخدمات أولاً");
                return false;
            }
            return true;
        }
        // fill { total amount } and { discount } and { final amount } texts

        // get fatora id from database
        static int fatora_id()
        {
            DataTable table = connection_class.select("select isnull(max(fatora_id),1) from sales_head_table");
            return Convert.ToInt32(table.Rows[0][0]);
        }
        // fill table with report head info for print
        public static decimal totalForPrint, taxForPrint;
        public static string Footer;
        public static string customer_name;
        public static string customer_tax_number;
        public static string customer_address;
        public static string customer_sgl;
        public static string customer_building;
        public static string customer_street;
        public static string customer_second_number;
        static DataTable head_datasource()
        {
            DataTable table = connection_class.select(@"SELECT [fatora_id]
      ,[sell_date]
      ,[sell_time]
      ,customer_name as customer_name
      ,(select customer_tax_number from customers_table where customers_table.customer_name=sales_head_table.customer_name) as customer_tax_number
      ,(select concat(country,'-',town,'-',al7e) from customers_table where customers_table.customer_name=sales_head_table.customer_name) as customer_address
      ,(select customer_sgl_number from customers_table where customers_table.customer_name=sales_head_table.customer_name) as customer_sgl_number
      ,(select building_number from customers_table where customers_table.customer_name=sales_head_table.customer_name) as building
      ,(select street from customers_table where customers_table.customer_name=sales_head_table.customer_name) as street
      ,(select customer_second_mobile from customers_table where customers_table.customer_name=sales_head_table.customer_name) as customer_second_mobile
      ,[total_amount]
      ,[net_amount]
      ,[pay_method]
      ,[taxes]
      ,[total_before_taxes]
      ,[paied_money]
      ,[cash]
      ,[card]
      ,[discount]
  FROM[app7_database].[dbo].[sales_head_table] where fatora_id=" + fatora_id());
            if (table.Rows.Count != 0)
            {
                customer_name = table.Rows[0]["customer_name"].ToString();
                customer_tax_number = table.Rows[0]["customer_tax_number"].ToString();
                customer_address = table.Rows[0]["customer_address"].ToString();
                customer_sgl = table.Rows[0]["customer_sgl_number"].ToString();
                customer_building = table.Rows[0]["building"].ToString();
                customer_street = table.Rows[0]["street"].ToString();
                customer_second_number = table.Rows[0]["customer_second_mobile"].ToString();
            }
            return table;
        }
        // fill table with report body info for print
        static DataTable products_datasource()
        {
            DataTable table = connection_class.select(@"SELECT number = ROW_NUMBER() OVER (ORDER BY fatora_id)
      ,[fatora_id]
      ,[product_name]
      ,[quantity]
      ,[product_price_before_tax]
      ,[tax]
      ,[product_full_price]
      ,[ash3ar_qty]
  FROM [app7_database].[dbo].[sales_body_table] where fatora_id=" + fatora_id());
            return table;
        }
        // get fatora id from database
        private void GetFatoraID()
        {
            DataTable fatora_id_table = connection_class.select("Select isnull(max(fatora_id)+1,1) from sales_head_table");
            FatoraID = Convert.ToInt32(fatora_id_table.Rows[0][0]);
        }
        // send invoice to database to save it`s info
        // for each invoice there`s two main thing :
        // invoice head : which hold un repeated info
        // invoice body : which hold repeated info { products }
        public static Image qr;
        int add_fatora_head_and_body(string bill_type, string customer_name)
        {

            GetFatoraID();
            totalForPrint = (decimal)ar_sell_fatora_checkout_form.total_amount;
            taxForPrint = (decimal)get_tax();
            string pay_method = ar_sell_fatora_checkout_form.the_pay_type;
            string sell_date = DateTime.Now.ToString("dd-MM-yyyy");
            string sell_time = DateTime.Now.ToString("hh:mm:ss tt");
            double total_amount = ar_sell_fatora_checkout_form.total_amount;
            double tax = get_tax();
            double discount = ar_sell_fatora_checkout_form.discount;
            double cash = ar_sell_fatora_checkout_form.cash_pay;
            double paied_money = ar_sell_fatora_checkout_form.cash_pay;
            double total_before_taxes = ar_sell_fatora_checkout_form.total_amount - get_tax();
            double net_amount = ar_sell_fatora_checkout_form.how_stay;
            TLVCls tlv = new TLVCls(settings_files.main_settings.Default.barber_name, settings_files.main_settings.Default.tax_number, DateTime.Now, fatora_forms.ar_pos_uc.totalForPrint, fatora_forms.ar_pos_uc.taxForPrint);
            pictureBox1.Image = tlv.toQrCode();
            qr = pictureBox1.Image;
            connection_class.command($"insert into sales_head_table values ({FatoraID},N'{bill_type}',N'{sell_date}',N'{sell_time}',N'{customer_name_cb.Text}',{total_amount},{net_amount},N'{const_variables_class.userID}',N'{pay_method}',{tax},{total_before_taxes},{paied_money},{cash},0,{discount})");
            int result = 0;
            for (int i = 0; i < main_gridview.RowCount - 1; i++)
            {
                string product_name = main_gridview.GetRowCellValue(i, colproduct_name).ToString();
                double price_before_tax = Convert.ToDouble(main_gridview.GetRowCellValue(i, col_priceBeforeTax));
                double product_tax = Convert.ToDouble(main_gridview.GetRowCellValue(i, col_tax));
                double full_value = Convert.ToDouble(main_gridview.GetRowCellValue(i, colfull_Value));
                double qty = Convert.ToDouble(main_gridview.GetRowCellValue(i, colqty));
                result = connection_class.command($"insert into sales_body_table values({FatoraID},N'{product_name}',{qty},{price_before_tax},{product_tax},{full_value},{qty})");
            }
            set_storage_value_and_logs();
            logs_class.log_add($"إضافة فاتورة مبيعات رقم {FatoraID}", FatoraID, "المبيعات");
            return result;
        }
        void clear_rows()
        {
            footer_tb.Text = "";
            for (int c = 0; c < main_gridview.RowCount; c++)
            {
                main_gridview.DeleteRow(c);
            }
            for (int l = 0; l < main_gridview.DataRowCount; l++)
            {
                main_gridview.DeleteRow(l);
            }
            if (main_gridview.RowCount != 0)
            {
                for (int c = 0; c < main_gridview.RowCount; c++)
                {
                    main_gridview.DeleteRow(c);
                }
            }
            if (main_gridview.DataRowCount != 0)
            {
                for (int l = 0; l < main_gridview.DataRowCount; l++)
                {
                    main_gridview.DeleteRow(l);
                }

            }

        }
        private void SendFatoraToDatabase(string bill_type, string customer_name)
        {
            if (IsEveryThingOK() == false)
            {
                return;
            }
            if (add_fatora_head_and_body(bill_type, customer_name) >= 1)
            {
                // بدي أعرف أذا عم بيع الوحدة الرئيسية أما لا
                for (int i = 0; i < main_gridview.RowCount; i++)
                {
                    if (i < main_gridview.RowCount)
                    {
                        if (i == main_gridview.RowCount - 1)
                        {
                            print_or_not();
                            clear_rows();
                            AddedProducts.Clear();
                            break;
                        }
                        else
                            continue;
                    }
                    else if (i == main_gridview.RowCount - 1)

                    {
                        print_or_not();
                        clear_rows();
                        AddedProducts.Clear();
                    }
                }
            }
        }
        bool print_fatora = false;
        void print_or_not()
        {
            Footer = footer_tb.Text;
            if (print_fatora)
            {
                //...80mm
                if(main_settings.Default.invoice_paper==0)
                {
                    repost_pos.pos_report.print(products_datasource(), head_datasource());

                }
                else
                {
                    repost_pos.XtraReportSaleInvoice.print(products_datasource(), head_datasource());

                }

            }
            else
                classes.notifications_class.success_message();
            customer_name_cb.ItemIndex = 0;
        }
        #endregion
        void set_storage_value_and_logs()
        {
            if (fatora_forms.ar_sell_fatora_checkout_form.cash_pay > 0)
            {
                storage_class.storage_value_increase(fatora_forms.ar_sell_fatora_checkout_form.cash_pay);
                storage_class.storage_log_add($"القبض من فاتورة المبيعات ذات الرقم {FatoraID}", ar_sell_fatora_checkout_form.cash_pay, main_settings.Default.storage_id);
            }
            ar_sell_fatora_checkout_form.IsClicked = false;
        }
        //Cash pay button without print
        double the_total_amount()
        {
            double value = 0;
            for (int i = 0; i < main_gridview.DataRowCount; i++)
            {
                value += Convert.ToDouble(main_gridview.GetRowCellValue(i, colfull_Value).ToString());
            }
            return value;
        }
        double get_tax()
        {
            double value = 0;
            if (settings_files.main_settings.Default.tax_value != 0)
            {
                for (int i = 0; i < main_gridview.DataRowCount; i++)
                {
                    double tax = Convert.ToDouble(main_gridview.GetRowCellValue(i, col_tax).ToString());
                    value += tax;
                }
            }

            return value;
        }
        void send_fatora_to_agel_db()
        {
            GetFatoraID();
            DataTable table = connection_class.select("select isnull(max(agl_id)+1,1) from agle_table");
            SqlCommand command = new SqlCommand("insert into agle_table values (@agl_id,@fatora_id,@customer_name,@how_pay,@how_stay,@full_money,@the_pay_date,@ok,@sell_date)", connection_class.connection());
            double how_stay = ar_sell_fatora_checkout_form.total_amount - (ar_sell_fatora_checkout_form.cash_pay);
            command.Parameters.AddWithValue("@agl_id", Convert.ToInt32(table.Rows[0][0]));
            command.Parameters.AddWithValue("@fatora_id", FatoraID);
            command.Parameters.AddWithValue("@customer_name", customer_name_cb.Text);
            command.Parameters.AddWithValue("@how_pay", ar_sell_fatora_checkout_form.cash_pay);
            command.Parameters.AddWithValue("@how_stay", how_stay);
            command.Parameters.AddWithValue("@full_money", ar_sell_fatora_checkout_form.total_amount);
            command.Parameters.AddWithValue("@the_pay_date", agel_due_date_dtp.DateTime.ToString("dd-MM-yyyy"));
            command.Parameters.AddWithValue("@sell_date", DateTime.Now.ToString("dd-MM-yyyy"));
            command.Parameters.AddWithValue("@ok", 0);
            command.ExecuteNonQuery();
            classes.add_kshf_class.customer_kshf(customer_name_cb.Text, $"فاتورة مبيعات رقم ( {FatoraID} )", how_stay);
            classes.aol_moda_class.update_customer_aol_moda(customer_name_cb.Text, how_stay);
            SendFatoraToDatabase(ar_sell_fatora_checkout_form.the_pay_type, customer_name_cb.Text);

        }
        private void pay_btn_Click(object sender, EventArgs e)
        {
            print_fatora = false;
            save_fatora();
        }
        private void main_gridview_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colqty || e.Column==col_priceBeforeTax)
            {
                int qty = Convert.ToInt32(main_gridview.GetFocusedRowCellValue(colqty));
                double beforetax = Convert.ToDouble(main_gridview.GetFocusedRowCellValue(col_priceBeforeTax));
                double tax = Convert.ToDouble(beforetax * main_settings.Default.tax_value) / 100;
                double price_with_tax = beforetax + tax;
                main_gridview.SetFocusedRowCellValue(colfull_Value, price_with_tax * qty);
                main_gridview.SetFocusedRowCellValue(col_tax, (tax * qty));
            }
        }

        private void main_gridview_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void main_gridview_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {

        }


        private void pay_print_btn_Click(object sender, EventArgs e)
        {
            print_fatora = true;
            save_fatora();
        }

        private void ar_pos_uc_Load(object sender, EventArgs e)
        {
            agel_due_date_dtp.DateTime = DateTime.Now;
            run_worker_class.run(customers_worker);
        }

        private void main_gridview_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void search_cb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {


        }

        private void customer_name_cb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {

            }
        }
        DataTable customers_table;
        private void customers_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            customers_table = connection_class.select("select customer_id as 'الرقم',customer_name as 'العميل',customer_mobile as 'الجوال' from customers_table order by customer_name");

        }
        private void customers_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataRow dr = customers_table.NewRow();
            dr["الرقم"] = 0;
            dr["العميل"] = "عميل نقدي";
            dr["الجوال"] = "";
            int yourPosition = 0;
            customers_table.Rows.InsertAt(dr, yourPosition);
            classes.lookup_edit_class.fill_lookup(customers_table, customer_name_cb, "العميل");
            run_worker_class.run(products_worker);
        }
        public static bool is_bill_agel = false;
        public static bool is_gomla = false;
        public static int col_number_for_open_unit_form = 0;
        DataTable main_category_table;
        private void products_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            main_category_table = connection_class.select("select id,category_name from categories_table where is_main=1");
        }

        private void customer_name_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customer_name_cb.Text != "عميل نقدي")
            {
                is_bill_agel = true;

            }
            else is_bill_agel = false;
        }
        void save_fatora()
        {
            if (IsEveryThingOK())
            {
                get_tax();
                ar_sell_fatora_checkout_form form = new ar_sell_fatora_checkout_form();
                if (customer_name_cb.Text != "عميل نقدي")
                {
                    is_bill_agel = true;
                    form.pay_type_cb.Properties.Items.Remove("متعدد");
                }
                else is_bill_agel = false;
                form.total_textbox.Text = the_total_amount().ToString();
                form.net_textbox.Text = the_total_amount().ToString();
                openForm(form);
                if (fatora_forms.ar_sell_fatora_checkout_form.IsClicked)
                {
                    // إذا الفاتورة مبيعات نقدية
                    if (customer_name_cb.Text == "عميل نقدي")
                    {

                        SendFatoraToDatabase("نقداً", customer_name_cb.Text);
                    }
                    // إذا فاتورة المبيعات آجلة
                    else if (customer_name_cb.Text != "عميل نقدي")
                    {

                        send_fatora_to_agel_db();

                    }
                }
            }
        }
        private void main_category_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void add_product_btn_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            openForm(new customers_forms.ar_customers_form());
            run_worker_class.run(customers_worker);
        }

        private void main_gridview_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (main_gridview.GetFocusedRowCellValue(colproduct_name) is null)
            {
                e.Valid = false;
            }
        }

        private void main_gridview_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            OmarNotifications.Alert.ShowInformation("يرجى أدخال البيان");
        }

        DataTable products_table;
        private void products_worker_DoWork_1(object sender, DoWorkEventArgs e)
        {
            products_table = connection_class.select($"select id as 'رقم المادة', product_name as 'المادة' from products_table");
        }

        private void products_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lookup_edit_class.fill_lookup(products_table,repositoryItemLookUpEdit1,"المادة", "رقم المادة");
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            if (notifications_class.my_messageBoxRightYesNo("هل أنت متأكد ؟") == DialogResult.Yes)
            {
                classes.form_close_class.close("pos_form");
            }
        }
    }
}
