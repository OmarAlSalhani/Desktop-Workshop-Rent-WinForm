namespace app7.products_forms
{
    partial class en_products_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.daily_rent_tb = new DevExpress.XtraEditors.ButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.product_name_tb = new DevExpress.XtraEditors.ButtonEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.id_tb = new DevExpress.XtraEditors.ButtonEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupControl9 = new DevExpress.XtraEditors.GroupControl();
            this.prev_btn = new DevExpress.XtraEditors.SimpleButton();
            this.first_btn = new DevExpress.XtraEditors.SimpleButton();
            this.last_btn = new DevExpress.XtraEditors.SimpleButton();
            this.next_btn = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.delete_btn = new DevExpress.XtraEditors.SimpleButton();
            this.new_btn = new DevExpress.XtraEditors.SimpleButton();
            this.save_btn = new DevExpress.XtraEditors.SimpleButton();
            this.update_btn = new DevExpress.XtraEditors.SimpleButton();
            this.main_gridview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.quantites_grid_control = new DevExpress.XtraGrid.GridControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daily_rent_tb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_name_tb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_tb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).BeginInit();
            this.groupControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_gridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantites_grid_control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(845, 38);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(340, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products Manager";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(806, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 21);
            this.label2.TabIndex = 50;
            this.label2.Text = "ID";
            // 
            // daily_rent_tb
            // 
            this.daily_rent_tb.EditValue = "";
            this.daily_rent_tb.EnterMoveNextControl = true;
            this.daily_rent_tb.Location = new System.Drawing.Point(11, 35);
            this.daily_rent_tb.Name = "daily_rent_tb";
            this.daily_rent_tb.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.daily_rent_tb.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.daily_rent_tb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.daily_rent_tb.Properties.Appearance.Options.UseFont = true;
            this.daily_rent_tb.Properties.Appearance.Options.UseTextOptions = true;
            this.daily_rent_tb.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.daily_rent_tb.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.daily_rent_tb.Properties.BeepOnError = false;
            this.daily_rent_tb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.daily_rent_tb.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.daily_rent_tb.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.daily_rent_tb.Properties.MaskSettings.Set("mask", "f");
            this.daily_rent_tb.Properties.UseMaskAsDisplayFormat = true;
            this.daily_rent_tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.daily_rent_tb.Size = new System.Drawing.Size(149, 28);
            this.daily_rent_tb.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label3.Location = new System.Drawing.Point(658, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 53;
            this.label3.Text = "Name";
            // 
            // product_name_tb
            // 
            this.product_name_tb.EditValue = "";
            this.product_name_tb.EnterMoveNextControl = true;
            this.product_name_tb.Location = new System.Drawing.Point(327, 35);
            this.product_name_tb.Name = "product_name_tb";
            this.product_name_tb.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.product_name_tb.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.product_name_tb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.product_name_tb.Properties.Appearance.Options.UseFont = true;
            this.product_name_tb.Properties.Appearance.Options.UseTextOptions = true;
            this.product_name_tb.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.product_name_tb.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.product_name_tb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.product_name_tb.Size = new System.Drawing.Size(326, 28);
            this.product_name_tb.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label4.Location = new System.Drawing.Point(164, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 21);
            this.label4.TabIndex = 55;
            this.label4.Text = "Price without tax";
            // 
            // id_tb
            // 
            this.id_tb.EditValue = "";
            this.id_tb.Enabled = false;
            this.id_tb.Location = new System.Drawing.Point(725, 35);
            this.id_tb.Name = "id_tb";
            this.id_tb.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.id_tb.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.id_tb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.id_tb.Properties.Appearance.Options.UseFont = true;
            this.id_tb.Properties.Appearance.Options.UseTextOptions = true;
            this.id_tb.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id_tb.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.id_tb.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.id_tb.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id_tb.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.id_tb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.id_tb.Properties.ReadOnly = true;
            this.id_tb.Size = new System.Drawing.Size(76, 28);
            this.id_tb.TabIndex = 59;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "الصور |*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // groupControl9
            // 
            this.groupControl9.AppearanceCaption.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.groupControl9.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl9.AppearanceCaption.Options.UseFont = true;
            this.groupControl9.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl9.Controls.Add(this.prev_btn);
            this.groupControl9.Controls.Add(this.first_btn);
            this.groupControl9.Controls.Add(this.last_btn);
            this.groupControl9.Controls.Add(this.next_btn);
            this.groupControl9.Location = new System.Drawing.Point(455, 409);
            this.groupControl9.Name = "groupControl9";
            this.groupControl9.Size = new System.Drawing.Size(388, 78);
            this.groupControl9.TabIndex = 39;
            this.groupControl9.Text = "Navigations options";
            // 
            // prev_btn
            // 
            this.prev_btn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.prev_btn.Appearance.Options.UseFont = true;
            this.prev_btn.ImageOptions.Image = global::app7.Properties.Resources.a_prev;
            this.prev_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.prev_btn.Location = new System.Drawing.Point(111, 33);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(90, 39);
            this.prev_btn.TabIndex = 7;
            this.prev_btn.Text = "Prev";
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click);
            // 
            // first_btn
            // 
            this.first_btn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.first_btn.Appearance.Options.UseFont = true;
            this.first_btn.ImageOptions.Image = global::app7.Properties.Resources.a_first;
            this.first_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.first_btn.Location = new System.Drawing.Point(301, 34);
            this.first_btn.Name = "first_btn";
            this.first_btn.Size = new System.Drawing.Size(81, 39);
            this.first_btn.TabIndex = 5;
            this.first_btn.Text = "First";
            this.first_btn.Click += new System.EventHandler(this.first_btn_Click);
            // 
            // last_btn
            // 
            this.last_btn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.last_btn.Appearance.Options.UseFont = true;
            this.last_btn.ImageOptions.Image = global::app7.Properties.Resources.a_last;
            this.last_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.last_btn.Location = new System.Drawing.Point(27, 33);
            this.last_btn.Name = "last_btn";
            this.last_btn.Size = new System.Drawing.Size(81, 39);
            this.last_btn.TabIndex = 4;
            this.last_btn.Text = "Last";
            this.last_btn.Click += new System.EventHandler(this.last_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.next_btn.Appearance.Options.UseFont = true;
            this.next_btn.ImageOptions.Image = global::app7.Properties.Resources.a_next;
            this.next_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.next_btn.Location = new System.Drawing.Point(205, 34);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(90, 39);
            this.next_btn.TabIndex = 6;
            this.next_btn.Text = "Next";
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.delete_btn);
            this.groupControl1.Controls.Add(this.new_btn);
            this.groupControl1.Controls.Add(this.save_btn);
            this.groupControl1.Controls.Add(this.update_btn);
            this.groupControl1.Location = new System.Drawing.Point(1, 409);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(452, 78);
            this.groupControl1.TabIndex = 41;
            this.groupControl1.Text = "Actions";
            // 
            // delete_btn
            // 
            this.delete_btn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.delete_btn.Appearance.Options.UseFont = true;
            this.delete_btn.ImageOptions.Image = global::app7.Properties.Resources.a_delete;
            this.delete_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.delete_btn.Location = new System.Drawing.Point(5, 34);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(105, 39);
            this.delete_btn.TabIndex = 3;
            this.delete_btn.Text = "Delete";
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.new_btn.Appearance.Options.UseFont = true;
            this.new_btn.ImageOptions.Image = global::app7.Properties.Resources.a_new;
            this.new_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.new_btn.Location = new System.Drawing.Point(332, 34);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(105, 39);
            this.new_btn.TabIndex = 0;
            this.new_btn.Text = "New";
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.Appearance.Options.UseFont = true;
            this.save_btn.ImageOptions.Image = global::app7.Properties.Resources.a_save;
            this.save_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.save_btn.Location = new System.Drawing.Point(223, 34);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(105, 39);
            this.save_btn.TabIndex = 6;
            this.save_btn.Text = "Save";
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // update_btn
            // 
            this.update_btn.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.update_btn.Appearance.Options.UseFont = true;
            this.update_btn.ImageOptions.Image = global::app7.Properties.Resources.a_edit;
            this.update_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.update_btn.Location = new System.Drawing.Point(114, 34);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(105, 39);
            this.update_btn.TabIndex = 2;
            this.update_btn.Text = "Edit";
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // main_gridview
            // 
            this.main_gridview.Appearance.FocusedCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.main_gridview.Appearance.FocusedCell.Options.UseFont = true;
            this.main_gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.FocusedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.main_gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.main_gridview.Appearance.FocusedRow.Options.UseBackColor = true;
            this.main_gridview.Appearance.FocusedRow.Options.UseFont = true;
            this.main_gridview.Appearance.FocusedRow.Options.UseForeColor = true;
            this.main_gridview.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.main_gridview.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.main_gridview.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.main_gridview.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.main_gridview.Appearance.HeaderPanel.Options.UseFont = true;
            this.main_gridview.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.main_gridview.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.main_gridview.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.main_gridview.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.main_gridview.Appearance.Row.Options.UseFont = true;
            this.main_gridview.Appearance.Row.Options.UseTextOptions = true;
            this.main_gridview.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.main_gridview.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.main_gridview.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.main_gridview.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.main_gridview.Appearance.SelectedRow.Options.UseBackColor = true;
            this.main_gridview.Appearance.SelectedRow.Options.UseFont = true;
            this.main_gridview.Appearance.SelectedRow.Options.UseForeColor = true;
            this.main_gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.main_gridview.GridControl = this.quantites_grid_control;
            this.main_gridview.Name = "main_gridview";
            this.main_gridview.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsBehavior.AllowIncrementalSearch = true;
            this.main_gridview.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsBehavior.Editable = false;
            this.main_gridview.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.main_gridview.OptionsBehavior.UnboundColumnExpressionEditorMode = DevExpress.XtraEditors.ExpressionEditorMode.AutoComplete;
            this.main_gridview.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.main_gridview.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.main_gridview.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.main_gridview.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsFind.AllowFindPanel = false;
            this.main_gridview.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.main_gridview.OptionsFind.FindNullPrompt = "ابدأ بكتابة النص لبدء البحث";
            this.main_gridview.OptionsFind.HighlightFindResults = false;
            this.main_gridview.OptionsFind.SearchInPreview = true;
            this.main_gridview.OptionsFind.ShowClearButton = false;
            this.main_gridview.OptionsFind.ShowFindButton = false;
            this.main_gridview.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Slide;
            this.main_gridview.OptionsNavigation.AutoFocusNewRow = true;
            this.main_gridview.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.main_gridview.OptionsSelection.MultiSelect = true;
            this.main_gridview.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.main_gridview.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.main_gridview.OptionsView.ShowGroupPanel = false;
            this.main_gridview.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.main_gridview.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.main_gridview_SelectionChanged);
            // 
            // quantites_grid_control
            // 
            this.quantites_grid_control.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quantites_grid_control.Location = new System.Drawing.Point(10, 69);
            this.quantites_grid_control.MainView = this.main_gridview;
            this.quantites_grid_control.Name = "quantites_grid_control";
            this.quantites_grid_control.Size = new System.Drawing.Size(826, 293);
            this.quantites_grid_control.TabIndex = 38;
            this.quantites_grid_control.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.main_gridview});
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.quantites_grid_control);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.product_name_tb);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.daily_rent_tb);
            this.groupControl2.Controls.Add(this.id_tb);
            this.groupControl2.Location = new System.Drawing.Point(1, 40);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(842, 367);
            this.groupControl2.TabIndex = 76;
            this.groupControl2.Text = "Info";
            // 
            // en_products_form
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 489);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl9);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "en_products_form";
            this.Load += new System.EventHandler(this.en_products_form_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daily_rent_tb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product_name_tb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_tb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).EndInit();
            this.groupControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_gridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantites_grid_control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.GroupControl groupControl9;
        private DevExpress.XtraEditors.SimpleButton prev_btn;
        private DevExpress.XtraEditors.SimpleButton first_btn;
        private DevExpress.XtraEditors.SimpleButton last_btn;
        private DevExpress.XtraEditors.SimpleButton next_btn;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton delete_btn;
        private DevExpress.XtraEditors.SimpleButton new_btn;
        private DevExpress.XtraEditors.SimpleButton save_btn;
        private DevExpress.XtraEditors.SimpleButton update_btn;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ButtonEdit daily_rent_tb;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ButtonEdit product_name_tb;
        private System.Windows.Forms.Label label4;
        public DevExpress.XtraEditors.ButtonEdit id_tb;
        private DevExpress.XtraGrid.Views.Grid.GridView main_gridview;
        private DevExpress.XtraGrid.GridControl quantites_grid_control;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}