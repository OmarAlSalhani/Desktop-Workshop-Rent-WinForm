﻿using app7.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app7.storages_forms.en
{
    public partial class en_storage_operations_form : DevExpress.XtraEditors.XtraForm
    {
        public en_storage_operations_form()
        {
            InitializeComponent();
            first_date.DateTime = last_date.DateTime = DateTime.Now;

            my_grid_view_class.set_find_panel_font2(gridView2, gridControl2, true, true);
            my_grid_view_class.set_font_and_hover_effect(gridView2);
            my_grid_view_class.show_empty_message2(gridView2);

        }
        string query()
        {
            DataTable userIDTable = connection_class.select($"select user_id from users_table where username=N'{username_cb.Text}'");
            DataTable storageIDTable = connection_class.select($"select id from storage_table where storage_name=N'{storage_name_cb.Text}'");
            int storageID = 0;
            int userID = 0;
            if (userIDTable.Rows.Count != 0)
            {
                userID = Convert.ToInt32(userIDTable.Rows[0][0]);
            }
            if (storageIDTable.Rows.Count != 0)
            {
                storageID = Convert.ToInt32(storageIDTable.Rows[0][0]);
            }
            string f = first_date.DateTime.ToString("dd-MM-yyyy");
            string l = last_date.DateTime.ToString("dd-MM-yyyy");
            // date
            if (search_by_date_cbx.Checked == true && search_by_storage_cbx.Checked == false && search_by_username_cbx.Checked == false)
            {
                return $@"select id as 'ID'
,(select storage_name from storage_table where storage_table.id=storage_id) as 'Safe'
,storage_event as 'Event'
,the_rsed as 'Balance'
,convert(nvarchar,the_date,105) as 'Date'
,the_time as 'Time'
,user_id as 'Username'
from storage_logs_table
where the_date between convert(date,'{f}',105) and convert(date,'{l}',105)";

            }
            // date and storage
            if (search_by_date_cbx.Checked && search_by_storage_cbx.Checked && search_by_username_cbx.Checked == false)
            {
                return $@"select id as 'ID'
,(select storage_name from storage_table where storage_table.id=storage_id) as 'Safe'
,storage_event as 'Event'
,the_rsed as 'Balance'
,convert(nvarchar,the_date,105) as 'Date'
,the_time as 'Time'
,user_id as 'Username'
from storage_logs_table
where storage_id={storageID} and the_date between convert(date,'{f}',105) and convert(date,'{l}',105)";
            }
            // date and storage and username
            if (search_by_date_cbx.Checked && search_by_storage_cbx.Checked && search_by_username_cbx.Checked)
            {
                return $@"select id as 'ID'
,(select storage_name from storage_table where storage_table.id=storage_id) as 'Safe'
,storage_event as 'Event'
,the_rsed as 'Balance'
,convert(nvarchar,the_date,105) as 'Date'
,the_time as 'Time'
,user_id as 'Username'
from storage_logs_table
where storage_id={storageID} and user_id={userID} and the_date between convert(date,'{f}',105) and convert(date,'{l}',105)";
            }
            //storage
            if (search_by_storage_cbx.Checked && search_by_date_cbx.Checked == false && search_by_username_cbx.Checked == false)
            {
                return $@"select id as 'ID'
,(select storage_name from storage_table where storage_table.id=storage_id) as 'Safe'
,storage_event as 'Event'
,the_rsed as 'Balance'
,convert(nvarchar,the_date,105) as 'Date'
,the_time as 'Time'
,user_id as 'Username'
from storage_logs_table
where storage_id={storageID}";

            }
            //username
            if (search_by_username_cbx.Checked && search_by_date_cbx.Checked == false && search_by_date_cbx.Checked == false)
            {
                return $@"select id as 'ID'
,(select storage_name from storage_table where storage_table.id=storage_id) as 'Safe'
,storage_event as 'Event'
,the_rsed as 'Balance'
,convert(nvarchar,the_date,105) as 'Date'
,the_time as 'Time'
,user_id as 'Username'
from storage_logs_table
where user_id={userID}";
            }
            // storage and username
            if (search_by_storage_cbx.Checked && search_by_username_cbx.Checked)
            {
                return $@"select id as 'ID'
,(select storage_name from storage_table where storage_table.id=storage_id) as 'Safe'
,storage_event as 'Event'
,the_rsed as 'Balance'
,convert(nvarchar,the_date,105) as 'Date'
,the_time as 'Time'
,user_id as 'Username'
from storage_logs_table
where storage_id={storageID} and user_id={userID}";
            }
            // date and username
            if (search_by_date_cbx.Checked && search_by_storage_cbx.Checked == false && search_by_username_cbx.Checked)
            {
                return $@"select id as 'ID'
,(select storage_name from storage_table where storage_table.id=storage_id) as 'Safe'
,storage_event as 'Event'
,the_rsed as 'Balance'
,convert(nvarchar,the_date,105) as 'Date'
,the_time as 'Time'
,user_id as 'Username'
from storage_logs_table
where user_id={userID} and the_date between convert(date,'{f}',105) and convert(date,'{l}',105)";
            }

            return string.Empty;
        }
        private void show_report_btn_Click(object sender, EventArgs e)
        {
            if (search_by_date_cbx.Checked == false && search_by_storage_cbx.Checked == false && search_by_username_cbx.Checked == false)
            {
                OmarNotifications.Alert.ShowInformation("Select search options");
                return;
            }
            else
            {
                DataTable table = connection_class.select(query());
                if (table.Rows.Count == 0)
                {
                    notifications_class.grid_message();
                    gridControl2.DataSource = null;
                    return;
                }
                my_grid_view_class.set_datasource(gridControl2, gridView2, table);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount == 0)
            {
                notifications_class.select_data_message();
                return;
            }
            if (gridView2.SelectedRowsCount != 0)
            {
                DialogResult dr = notifications_class.my_messageBox("Are you sure ?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (int i in gridView2.GetSelectedRows())
                    {
                        int ID = Convert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns[0].FieldName));
                        connection_class.command($"delete from storage_logs_table where id={ID}");
                        logs_class.log_add($"Delete safe operations with id : {ID}", 0, "Safes");

                    }
                    show_report_btn.PerformClick();
                    classes.notifications_class.success_message();
                }
            }

        }
        public static string from_date, to_date;
        DataTable users_table, storage_table;

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lookup_edit_class.fill_lookup(users_table, username_cb, "Username");
            lookup_edit_class.fill_lookup(storage_table, storage_name_cb, "Safe");
        }

        private void en_storage_operations_form_Load(object sender, EventArgs e)
        {
            DataTable table = connection_class.select(@"select id as 'ID'
, (select storage_name from storage_table where storage_table.id=storage_id) as 'Safe'
, storage_event as 'Event'
, the_rsed as 'Balance'
, convert(nvarchar, the_date, 105) as 'Date'
, the_time as 'Time'
, user_id as 'Username'
from storage_logs_table
where 1=2");
            my_grid_view_class.set_datasource(gridControl2, gridView2, table);
            run_worker_class.run(backgroundWorker1);
        }

        private void pdf_btn_Click(object sender, EventArgs e)
        {
            repost_pos.en_storage_operations1.to_pdf(my_grid_view_class.gridview_to_data_table(gridView2));
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
             repost_pos.en_storage_operations1.to_excel(my_grid_view_class.gridview_to_data_table(gridView2));
        }

        private void word_btn_Click(object sender, EventArgs e)
        {
            repost_pos.en_storage_operations1.to_word(my_grid_view_class.gridview_to_data_table(gridView2));
        }

        private void groupControl6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Balance")
            {
                if (Convert.ToDouble(e.CellValue) > 0)
                    e.Appearance.ForeColor = Color.RoyalBlue;
                else if (Convert.ToDouble(e.CellValue) < 0)
                    e.Appearance.ForeColor = Color.Red;
                else
                    e.Appearance.ForeColor = Color.Black;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            users_table = connection_class.select("select distinct username as 'Username' from users_table");
            storage_table = connection_class.select("select  storage_name  as 'Safe',storage_value as 'Balance' from storage_table");
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            repost_pos.en_storage_operations1.print(my_grid_view_class.gridview_to_data_table(gridView2), null);
        }
    }
}
