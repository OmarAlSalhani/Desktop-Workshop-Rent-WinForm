using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using app7.classes;
using app7.settings_files;
using System.Data.SqlClient;
using DevExpress.XtraGrid;

namespace app7.fatora_forms
{
    public partial class en_ard_s3r_uc : DevExpress.XtraEditors.XtraUserControl
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
        public en_ard_s3r_uc()
        {
            InitializeComponent();
            my_grid_view_class.set_find_panel_font2(main_gridview, quantites_grid_control, true, false, false);
            my_grid_view_class.set_font_and_hover_effect(main_gridview);
            my_grid_view_class.show_empty_message2(main_gridview);
            repositoryItemLookUpEdit1.EditValueChanged += RepositoryItemLookUpEdit1_EditValueChanged;

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
                OmarNotifications.Alert.ShowInformation("Select products first");
                return false;
            }
            return true;
        }
        // fill { total amount } and { discount } and { final amount } texts

        // get fatora id from database
        // fill table with report head info for print
        public static double totalForPrint, taxForPrint;
        public static string note;

         DataTable head_datasource()
        {
            DataTable table = connection_class.select($@"SELECT
      concat(N'الأسم - Name : ',customer_name) as customer_name
      ,concat(N'الرقم الضريبي-tax number : ',customer_tax_number)  as customer_tax_number
      , concat(N'العنوان-address : ',country,'-',town,'-',al7e)  as customer_address
      , concat(N'السجل التجاري-commercial register : ',customer_sgl_number)  as customer_sgl_number
      , concat(N'المبنى-building : ',building_number)  as building
      , concat(N'الشارع-street : ',street)  as street
      ,concat(N'الرقم الاضافي-mobile2 : ',customer_second_mobile)  as customer_second_mobile
  FROM customers_table where customer_name=N'{customer_name_cb.Text}'");
            return table;
        }
        // fill table with report body info for print
         DataTable products_datasource()
        {
            DataTable t = connection_class.select("select * from ard_s3r_temp_table");
            return t;
        }
       
        void clear_rows()
        {
            note_tb.Text = "";
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
        void print()
        {
            for (int i = 0; i < main_gridview.DataRowCount; i++)
            {
                string name = main_gridview.GetRowCellValue(i, colproduct_name).ToString();
                string qty = main_gridview.GetRowCellValue(i, colqty).ToString();
                string price = main_gridview.GetRowCellValue(i, col_priceBeforeTax).ToString();
                string tax = main_gridview.GetRowCellValue(i, col_tax).ToString();
                string total = main_gridview.GetRowCellValue(i, colfull_Value).ToString();
                connection_class.command($"insert into ard_s3r_temp_table values (N'{name}',{qty},{price},{tax},{total})");
            }
            repost_pos.ard_s3r_report.print(products_datasource(), head_datasource());
            customer_name_cb.ItemIndex = 0;
            note_tb.Text = "";
            id_tb.Text = (Convert.ToInt32(id_tb.Text) + 1).ToString();
            clear_rows();
            connection_class.command($"delete from ard_s3r_temp_table");
        }
        #endregion

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
        private void pay_btn_Click(object sender, EventArgs e)
        {
        }
        private void main_gridview_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void main_gridview_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void main_gridview_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {

        }

        private void pay_print_btn_Click(object sender, EventArgs e)
        {
            note = note_tb.Text;
            FatoraID = Convert.ToInt32(id_tb.Text);
            the_date = DateTime.Now.ToString("yyyy-MM-dd");
            taxForPrint = get_tax();
            totalForPrint = the_total_amount();
            print();
        }

        private void en_ard_s3r_uc_Load(object sender, EventArgs e)
        {
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
           
        }
        DataTable customers_table;
        private void customers_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            customers_table = connection_class.select("select customer_id as 'id',customer_name as 'customer',customer_mobile as 'mobile' from customers_table order by customer_name");

        }
        DataTable products_table;
        private void products_worker_DoWork_1(object sender, DoWorkEventArgs e)
        {
            products_table = connection_class.select($"select id , product_name as 'product' from products_table");
        }

        private void products_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lookup_edit_class.fill_lookup(products_table, repositoryItemLookUpEdit1, "product","id");
        }
        private void customers_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            classes.lookup_edit_class.fill_lookup(customers_table, customer_name_cb, "customer");
            run_worker_class.run(products_worker);
        }
        public static bool is_bill_agel = false;
        public static bool is_gomla = false;
        public static int col_number_for_open_unit_form = 0;
        private void customer_name_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customer_name_cb.Text != "Cash")
            {
                is_bill_agel = true;

            }
            else is_bill_agel = false;
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

        private void close_btn_Click(object sender, EventArgs e)
        {
            if (notifications_class.my_messageBoxRightYesNo("Are you sure ?") == DialogResult.Yes)
            {
                classes.form_close_class.close("en_ard_s3r_form");
            }
        }
    }
}
