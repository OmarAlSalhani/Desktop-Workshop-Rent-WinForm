using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using app7.classes;

namespace app7.products_forms
{
    public partial class en_products_form : DevExpress.XtraEditors.XtraForm
    {
        public en_products_form()
        {
            InitializeComponent();
            my_grid_view_class.set_font_and_hover_effect(main_gridview);
            my_grid_view_class.show_empty_message2(main_gridview);
            my_grid_view_class.set_find_panel_font2(main_gridview, quantites_grid_control, false, true);
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            if (product_name_tb.Text.Length == 0)
            {
                OmarNotifications.Alert.ShowInformation("Enter product name");
                return;
            }
            if (Convert.ToDouble(daily_rent_tb.Text) <= 0)
            {
                OmarNotifications.Alert.ShowInformation("Enter Price");
                return;
            }
            connection_class.command($"insert into products_table values ({Convert.ToInt32(id_tb.Text)},N'{product_name_tb.Text}',{Convert.ToDouble(daily_rent_tb.Text)})");
            notifications_class.success_message();
            run_worker_class.run(backgroundWorker1);
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            run_worker_class.run(backgroundWorker1);
        }
        void clear()
        {
            product_name_tb.Text = daily_rent_tb.Text = "";
            id_tb.Text = get_id().ToString();

        }
        int get_id()
        {
            DataTable table = connection_class.select("select isnull(max(id)+1,1) from products_table");
            return Convert.ToInt32(table.Rows[0][0]);
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (main_gridview.SelectedRowsCount > 1)
            {
                OmarNotifications.Alert.ShowInformation("Select one product at time");
                return;
            }
            DialogResult dr = notifications_class.my_messageBox("Are you sure ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                connection_class.command($"update products_table set product_name=N'{product_name_tb.Text}',daily_rent={Convert.ToDouble(daily_rent_tb.Text)} where id={Convert.ToInt32(id_tb.Text)}");
            }
            notifications_class.success_message();
            run_worker_class.run(backgroundWorker1);

        }
        string old_name;
        void navigate_btn(string query)
        {
            DataTable table = connection_class.select(query);
            if (table.Rows.Count == 0)
            {
                DataTable table1 = connection_class.select("select * from products_table");
                if (table1.Rows.Count == 0)
                {
                    OmarNotifications.Alert.ShowInformation("No Data!");
                    return;
                }
                else
                {
                    if (is_next_clicked)
                        first_btn.PerformClick();
                    else
                        last_btn.PerformClick();
                }
            }
            else
            {
                int id = Convert.ToInt32(table.Rows[0]["id"]);
                id_tb.Text = id.ToString();
                product_name_tb.Text = table.Rows[0]["product_name"].ToString();
                daily_rent_tb.Text = table.Rows[0]["daily_rent"].ToString();
                old_name = product_name_tb.Text.Trim();
            }
            delete_btn.Enabled = true;
            update_btn.Enabled = true;
            save_btn.Enabled = false;
        }

        private void first_btn_Click(object sender, EventArgs e)
        {
            navigate_btn($"select * from products_table where id=(select min(id) from products_table)");

        }
        bool is_next_clicked = false;

        private void next_btn_Click(object sender, EventArgs e)
        {
            navigate_btn(navigation_class.next_navigatoin("products_table", "id", id_tb.Text));
            is_next_clicked = true;
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            navigate_btn(navigation_class.prev_navigation("products_table", "id", id_tb.Text));
            is_next_clicked = false;
        }

        private void last_btn_Click(object sender, EventArgs e)
        {
            navigate_btn($"select * from products_table where id=(select max(id) from products_table)");

        }

        private void en_products_form_Load(object sender, EventArgs e)
        {
            run_worker_class.run(backgroundWorker1);

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {

            if (main_gridview.SelectedRowsCount == 0)
            {
                notifications_class.select_data_message();
            }
            if (main_gridview.SelectedRowsCount > 0)
            {
                foreach (int i in main_gridview.GetSelectedRows())
                {
                    string the_name = main_gridview.GetRowCellValue(i, main_gridview.Columns[1].FieldName).ToString();
                    if (!validate_class.is_customer_agel_clean(the_name))
                    {
                        return;
                    }
                }
                DialogResult dr = classes.notifications_class.my_messageBox("Are you sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    foreach (int i in main_gridview.GetSelectedRows())
                    {
                        int id = Convert.ToInt32(main_gridview.GetRowCellValue(i, main_gridview.Columns[0].FieldName));
                        string name = (main_gridview.GetRowCellValue(i, main_gridview.Columns[1].FieldName)).ToString();
                        connection_class.command($"delete from products_table where id={Convert.ToInt32(main_gridview.GetRowCellValue(i, main_gridview.Columns[0].FieldName))}");
                        logs_class.log_add($"Delete product with id {id_tb.Text}", 0, "products");
                    }
                    new_btn.PerformClick();
                    notifications_class.success_message();
                }

            }
        }
        private void main_gridview_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (main_gridview.RowCount != 0)
            {
                navigate_btn($"select * from products_table where id={Convert.ToInt32(main_gridview.GetFocusedRowCellValue(main_gridview.Columns[0]))}");
                delete_btn.Enabled = true;
                update_btn.Enabled = true;
                save_btn.Enabled = false;
            }
            if (main_gridview.SelectedRowsCount == 0)
            {
                delete_btn.Enabled = false;
                update_btn.Enabled = false;
                save_btn.Enabled = true;
                new_btn.PerformClick();
            }
        }
        DataTable get_data_table;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            get_data_table = connection_class.select("select id as 'ID' , product_name as 'Product name',daily_rent as 'Price before tax' from products_table order by id desc");
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            my_grid_view_class.set_datasource(quantites_grid_control, main_gridview, get_data_table);
            main_gridview.ClearSelection();
            update_btn.Enabled = false;
            delete_btn.Enabled = false;
            save_btn.Enabled = true;
            clear();

        }
        private void print_btn_Click(object sender, EventArgs e)
        {
            if (main_gridview.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            repost_pos.manage_customers.print(my_grid_view_class.gridview_to_data_table(main_gridview), null);
        }

        private void word_btn_Click(object sender, EventArgs e)
        {
            repost_pos.manage_customers.to_word(my_grid_view_class.gridview_to_data_table(main_gridview));
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            repost_pos.manage_customers.to_excel(my_grid_view_class.gridview_to_data_table(main_gridview));
        }

        private void pdf_btn_Click(object sender, EventArgs e)
        {
            repost_pos.manage_customers.to_pdf(my_grid_view_class.gridview_to_data_table(main_gridview));
        }

    }
}