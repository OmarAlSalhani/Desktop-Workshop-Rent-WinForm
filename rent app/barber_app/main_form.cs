﻿using app7.classes;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app7
{
    public partial class main_form : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public main_form()
        {
            InitializeComponent();
            run_worker_class.run(backgroundWorker1);
            if (settings_files.permissions_settings.Default.customers_kshf_7sab == 0)
            {
                customer_kshf_7sab_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_customers == 0)
            {
                customers_manage_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.customers_mdeonee == 0)
            {
                customers_deon_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.customers_paied_money == 0)
            {
                customers_paied_money_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.open_pos == 0)
            {
                pos_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.sales_report == 0)
            {
                sales_report_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_products == 0)
            {
                services_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_categories == 0)
            {
            }

            if (settings_files.permissions_settings.Default.manage_settings == 0)
            {
            }
            if (settings_files.permissions_settings.Default.manage_storages == 0)
            {
                storages_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.storages_operations == 0)
            {
                storages_operations_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_users == 0)
            {
                users_btn.Enabled = false;
            }

            if (settings_files.permissions_settings.Default.manage_blackbox == 0)
            {
                blackbox_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.snd_qbd == 0)
            {
                snd_qbd_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.snd_srf == 0)
            {
                snds_srf_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.snds_report == 0)
            {
                snds_report_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_daily_brief == 0)
            {
                daily_brief_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_today_agle == 0)
            {
                today_agel_btn.Enabled = false;
            }
        }


        void openForm(XtraForm form, bool m = false,bool is_sizalbe=false)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.IconOptions.ShowIcon = false;
            form.FormBorderStyle =is_sizalbe?FormBorderStyle.Sizable: FormBorderStyle.FixedSingle;
            form.MaximizeBox = m;
            form.Text = "";
            form.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress);
            form.Show();
        }

        private void services_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void pos_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new fatora_forms.pos_form(), true,true);
        }

        private void categories_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void settings_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_settings_forms.ar.ar_main_settings_form());
        }

        private void storages_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new storages_forms.ar_storages_form());
        }

        private void storages_operations_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new storages_forms.ar_storage_operations_form());
        }

        private void sales_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new fatora_forms.ar_sell_report_form(),false,true);
        }

        private void customers_deon_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new customers_forms.ar_customers_mdeonee_form());
        }

        private void customers_paied_money_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new customers_forms.ar_customers_paied_money_form());
        }

        private void customer_kshf_7sab_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new customers_forms.ar_customers_kshf_7sab_form());
        }

        private void snd_qbd_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_snds_forms.ar.ar_snd_qbd_form());
        }

        private void snds_srf_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_snds_forms.ar.ar_snd_srf_form());
        }

        private void snds_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_snds_forms.ar.ar_snds_report_form());
        }

        private void customers_manage_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new customers_forms.ar_customers_form());
        }

        private void users_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new users_forms.ar_users_form());
        }

        private void blackbox_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_blackbox_forms.ar.ar_blackbox_form());
        }

        private void daily_brief_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new ar_daily_report_form());
        }

        private void today_agel_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new ar_agel_notifications_form());
        }

        private void ash3ar_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new ash3ar_forms.da2en_ash3ar_form());
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_settings_forms.ar.backup_form());
        }
        bool create_auto_backup()
        {
            try
            {
                string folder = settings_files.main_settings.Default.backup_folder;
                if(folder.Length==0)
                {
                    return false;
                }
                string name = $"app7_database manual_backup {DateTime.Now.ToString("dd-MM-yyyy hh_mm tt")}.bak";
                string backup_path = System.IO.Path.Combine(folder, name);
                if (System.IO.Directory.Exists(folder) == false)
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                if (System.IO.File.Exists(backup_path))
                {
                    return false;
                }
                Backup bkpDBFull = new Backup();
                bkpDBFull.Action = BackupActionType.Database;
                bkpDBFull.Database = "app7_database";
                bkpDBFull.Devices.AddDevice(backup_path, DeviceType.File);
                bkpDBFull.Initialize = false;
                bkpDBFull.SqlBackup(new Server(settings_files.database_settings.Default.server_name));
                return true;
            }
            catch
            {
                return false;
            }

        }
        bool create_manual_backup()
        {
            try
            {
                string folder = settings_files.main_settings.Default.backup_folder;
                if (folder.Length == 0)
                {
                    return false;
                }
                string name = $"app7_database manual_backup {DateTime.Now.ToString("dd-MM-yyyy hh_mm_ss tt")}.bak";
                string backup_path = System.IO.Path.Combine(folder, name);
                if (System.IO.Directory.Exists(folder) == false)
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                if (System.IO.File.Exists(backup_path))
                {
                    return false;
                }
                Backup bkpDBFull = new Backup();
                bkpDBFull.Action = BackupActionType.Database;
                bkpDBFull.Database = "app7_database";
                bkpDBFull.Complete += Backup_Completed;
                bkpDBFull.Devices.AddDevice(backup_path, DeviceType.File);
                bkpDBFull.Initialize = false;
                bkpDBFull.SqlBackup(new Server(settings_files.database_settings.Default.server_name));
                return true;
            }
            catch
            {
                return false;
            }

        }
        void createAutoBackup()
        {
            DataTable table = classes.connection_class.select($"select * from backup_scheduale_table where the_time=N'{DateTime.Now.ToString("hh:mm tt")}'");
            if (table.Rows.Count == 0)
                return;
            else
            {
                create_auto_backup();
            }
        }
        private void clock_timer_Tick(object sender, EventArgs e)
        {
            clock_lbl.Caption = DateTime.Now.ToString("hh:mm:ss tt");
            createAutoBackup();

        }
        private void Backup_Completed(object sender, ServerMessageEventArgs args)
        {
                classes.notifications_class.success_message();
        }
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (texts_class.is_null(settings_files.main_settings.Default.backup_folder))
            {
                OmarNotifications.Alert.ShowInformation("الرجاء إختيار مجلد النسخ الأحتياطي");
                return;
            }
            create_manual_backup();
        }
        private void Restore_Completed(object sender, ServerMessageEventArgs args)
        {
            logs_class.log_add("إستعادة نسخة إحتياطية", 0, "قواعد البيانات");
            classes.notifications_class.success_message();
        }
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Server server = new Server(settings_files.database_settings.Default.server_name);
                    server.KillAllProcesses("app7_database");
                    Restore restoreDB = new Restore();
                    restoreDB.Database = "app7_database";
                    restoreDB.Action = RestoreActionType.Database;
                    restoreDB.Devices.AddDevice(openFileDialog1.FileName, DeviceType.File);
                    restoreDB.ReplaceDatabase = true;
                    restoreDB.Complete += Restore_Completed;
                    restoreDB.SqlRestore(server);
                    logs_class.log_add($"إستعادة نسخة إحتياطية بالإسم {openFileDialog1.FileName}", 0, "الإعدادات");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Directory lookup for the file"))
                {
                    OmarNotifications.Alert.ShowInformation("النسخة المطلوب أستعادتها لا تتوافق مع نسخة سيرفر قواعد البيانات المثبت على الحاسوب");
                    return;
                }
                if (ex.Message.Contains("Restore failed for Server"))
                {
                    OmarNotifications.Alert.ShowInformation("لا يمكن لملف النسخة الأحتياطية أن يكون موجود على قرص النظام");
                    return;
                }
                else
                {
                    classes.notifications_class.database_error_messageBox(ex.Message);
                    return;
                }
            }
        }

        DataTable get_customers;
        DataTable get_bills;
        DataTable get_users;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            get_customers = connection_class.select($"select isnull(count(customer_id),0) from customers_table");
            get_bills = connection_class.select($"select isnull(count(fatora_id),0) from sales_head_table");
            get_users = connection_class.select($"select isnull(count(user_id),0) from users_table");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                customers_count_lbl.Text = get_customers.Rows[0][0].ToString();
                bills_count_lbl.Text = get_bills.Rows[0][0].ToString();
                users_count_lbl.Text = get_users.Rows[0][0].ToString();
            }
            catch
            {

            }
        }

        private void ard_s3r_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new fatora_forms.ard_s3r_form(),true,true);
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new products_forms.ar_products_form());
        }
    }
}