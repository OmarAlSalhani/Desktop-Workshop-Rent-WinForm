﻿using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using app7.classes;
using System.Security.Cryptography;
using System.Text;
using DevExpress.Utils.Localization;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using System.Threading;
using System.IO;

namespace app7
{

    public partial class first_form : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public first_form()
        {
            InitializeComponent();

            XtraLocalizer.QueryLocalizedString += XtraLocalizer_QueryLocalizedString;
            timer.Tick += Timer_Tick;
            timer.Interval = 25;
            dont_run_app_if_screen_width800();
        }
        private void XtraLocalizer_QueryLocalizedString(object sender, XtraLocalizer.QueryLocalizedStringEventArgs e)
        {
            if (e.StringIDType == typeof(StringId))
            {
                if ((StringId)e.StringID == StringId.XtraMessageBoxYesButtonText)
                {

                    e.Value = "نعم";

                }
                if ((StringId)e.StringID == StringId.XtraMessageBoxNoButtonText)
                {

                    e.Value = "لا";

                }
                if ((StringId)e.StringID == StringId.XtraMessageBoxOkButtonText)
                {
                    e.Value = "حسناً";

                }

            }
        }
        /// <summary>
        /// this is the entry point for system
        /// on load we will check screen width
        /// then we will check if this is first run or not
        /// if this is first run we will launch database_connection_form
        /// else we will launch new_login_form
        /// </summary>
        void if_there_is_no_users_add_root_user()
        {
            DataTable check_table = connection_class.select("select * from users_table");
            if (check_table.Rows.Count == 0)
            {
                DataTable table = connection_class.select("select isnull(max(user_id)+1,1) from users_table");
                int id = Convert.ToInt32(table.Rows[0][0]);
                SqlCommand command = new SqlCommand("insert into users_table values (@id,@username,@password,@user_image,@storage_id)", connection_class.connection());
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@username", "admin");
                command.Parameters.AddWithValue("@password", "admin");
                command.Parameters.AddWithValue("@user_image", convert_class.image_to_byte(user_pic.Image));
                command.Parameters.AddWithValue("@storage_id", 1);
                if (command.ExecuteNonQuery() == 1)
                {
                    connection_class.command($"insert into roles_table values (1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1)");
                }
            }
        }
        void if_there_is_no_storages_add_main_storage()
        {
            DataTable table = connection_class.select("select * from storage_table");
            if (table.Rows.Count == 0)
            {
                connection_class.command("insert into storage_table values(1,N'الخزنة الرئيسية',0)");
            }
        }
        void dont_run_app_if_screen_width800()
        {
            if (System.Windows.SystemParameters.PrimaryScreenWidth <= 800)
            {
                classes.notifications_class.my_messageBox("لا يمكن تشغيل نظام مايكرو للمبيعات على هذه الشاشة\nلأن أبعادها أقل من المتطلبات المطلوبة\n" +
                 "يرجى أستبدال الشاشة أو ضبط أعدادات العرض على 1024 فما فوق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        void reset_first_time()
        {
            settings_files.main_settings.Default.first_run = true;
            settings_files.main_settings.Default.Save();
        }
        bool check_connection()
        {
            if (connection_class.check_connection())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void first_form_Load(object sender, EventArgs e)
        {
            if (check_connection() == false)
            {
                 reset_first_time();
            }
            if (settings_files.main_settings.Default.first_run == true)
            {
                Hide();
                first_launch_form form = new first_launch_form();
                form.ShowDialog();
            }
            if (settings_files.main_settings.Default.is_activated==false)
            {
                Hide();
                activate_form f = new activate_form();
                f.ShowDialog();
            }
            if(settings_files.main_settings.Default.first_run==false && settings_files.main_settings.Default.is_activated==true)
            {
                timer.Enabled = true;
                timer.Start();
                run_worker_class.run(backgroundWorker1);
            }
           
        }
        bool connection_error = false;
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (check_connection() == false)
            {
                connection_error = true;
                backgroundWorker1.CancelAsync();
            }
            if_there_is_no_storages_add_main_storage();
            if_there_is_no_users_add_root_user();
        }
        int i = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            progressBarControl1.Position = i;
            progress_label.Text = i.ToString() + "%";
            if (i == 100)
                timer.Stop();
            i++;
            if (connection_error)
            {
                notifications_class.my_messageBox("خطأ في الأتصال مع قاعدة البيانات\nسيتم إغلاق البرنامج الرجاء التأكد من فتح الإتصال وإعادة فتح البرنامج من جديد");
                Application.Exit();
            }
            else
           if (progressBarControl1.Position == 100)
            {
                Hide();
                login_form form = new login_form();
                form.ShowDialog();
            }
        }
    }
}
