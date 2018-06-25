namespace TrackingProducts
{
    partial class Form_ReportCurrentTransaction
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReportCurrentTransaction));
            this.btn_Report = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.date_2 = new DevExpress.XtraEditors.DateEdit();
            this.date_1 = new DevExpress.XtraEditors.DateEdit();
            this.tb_current = new DevExpress.XtraEditors.TextEdit();
            this.sendExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid_report = new DevExpress.XtraGrid.GridControl();
            this.grid_currentSearch = new DevExpress.XtraGrid.GridControl();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.date_2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_current.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_currentSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Report
            // 
            this.btn_Report.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_Report.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Report.ImageOptions.Image")));
            this.btn_Report.Location = new System.Drawing.Point(487, 22);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(110, 42);
            this.btn_Report.TabIndex = 3;
            this.btn_Report.Text = "Show report";
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(75, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Current";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(209, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(102, 16);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Departure Date";
            // 
            // date_2
            // 
            this.date_2.EditValue = null;
            this.date_2.Location = new System.Drawing.Point(336, 28);
            this.date_2.Name = "date_2";
            this.date_2.Properties.AutoHeight = false;
            this.date_2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.date_2.Size = new System.Drawing.Size(150, 30);
            this.date_2.TabIndex = 2;
            this.date_2.EditValueChanged += new System.EventHandler(this.date_2_EditValueChanged);
            this.date_2.Leave += new System.EventHandler(this.date_2_Leave);
            // 
            // date_1
            // 
            this.date_1.EditValue = null;
            this.date_1.Location = new System.Drawing.Point(181, 28);
            this.date_1.Name = "date_1";
            this.date_1.Properties.AutoHeight = false;
            this.date_1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.date_1.Size = new System.Drawing.Size(150, 30);
            this.date_1.TabIndex = 1;
            this.date_1.EditValueChanged += new System.EventHandler(this.date_1_EditValueChanged);
            // 
            // tb_current
            // 
            this.tb_current.EditValue = "";
            this.tb_current.Location = new System.Drawing.Point(26, 28);
            this.tb_current.Name = "tb_current";
            this.tb_current.Properties.AutoHeight = false;
            this.tb_current.Size = new System.Drawing.Size(150, 30);
            this.tb_current.TabIndex = 0;
            this.tb_current.TextChanged += new System.EventHandler(this.tb_current_TextChanged);
            // 
            // sendExcelToolStripMenuItem
            // 
            this.sendExcelToolStripMenuItem.Name = "sendExcelToolStripMenuItem";
            this.sendExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendExcelToolStripMenuItem.Text = "Send As Excel";
            this.sendExcelToolStripMenuItem.Click += new System.EventHandler(this.sendExcelToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendExcelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Balance";
            this.gridColumn9.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "CARI_BAKY";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Receivable";
            this.gridColumn8.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "CARI_ALCK";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Debt";
            this.gridColumn7.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "CARI_BORC";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.btn_Report);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.date_2);
            this.panelControl1.Controls.Add(this.date_1);
            this.panelControl1.Controls.Add(this.tb_current);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1302, 70);
            this.panelControl1.TabIndex = 215;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(370, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 16);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Expiry Date";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Miktar";
            this.gridColumn6.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "MIKTAR";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Açıklama";
            this.gridColumn10.FieldName = "ACIKLAMA";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.ShowUnboundExpressionMenu = true;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Belge Numarası";
            this.gridColumn4.FieldName = "BELGE_NO";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Due Date";
            this.gridColumn3.FieldName = "VADE_TARIHI";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.FieldName = "HARK_TARH";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Current";
            this.gridColumn1.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "CARI_KOD";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn10,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridView1.GridControl = this.grid_report;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Net Fiyat";
            this.gridColumn5.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "NET_FIYAT";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // grid_report
            // 
            this.grid_report.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_report.Location = new System.Drawing.Point(0, 70);
            this.grid_report.MainView = this.gridView1;
            this.grid_report.Name = "grid_report";
            this.grid_report.Size = new System.Drawing.Size(1302, 740);
            this.grid_report.TabIndex = 216;
            this.grid_report.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // grid_currentSearch
            // 
            this.grid_currentSearch.EmbeddedNavigator.Appearance.Options.UseTextOptions = true;
            this.grid_currentSearch.EmbeddedNavigator.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grid_currentSearch.Location = new System.Drawing.Point(305, 330);
            this.grid_currentSearch.MainView = this.gridView8;
            this.grid_currentSearch.Name = "grid_currentSearch";
            this.grid_currentSearch.Size = new System.Drawing.Size(693, 150);
            this.grid_currentSearch.TabIndex = 218;
            this.grid_currentSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView8});
            this.grid_currentSearch.Visible = false;
            this.grid_currentSearch.DoubleClick += new System.EventHandler(this.grid_currentSearch_DoubleClick);
            // 
            // gridView8
            // 
            this.gridView8.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView8.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridView8.Appearance.Row.Options.UseFont = true;
            this.gridView8.Appearance.Row.Options.UseForeColor = true;
            this.gridView8.AppearancePrint.Preview.Options.UseTextOptions = true;
            this.gridView8.AppearancePrint.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn56,
            this.gridColumn57});
            this.gridView8.GridControl = this.grid_currentSearch;
            this.gridView8.GroupPanelText = "Gruplama yapmak istediğiniz kolonu bu alana sürekleyiniz.";
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView8.OptionsBehavior.Editable = false;
            this.gridView8.OptionsBehavior.ReadOnly = true;
            this.gridView8.OptionsView.ColumnAutoWidth = false;
            this.gridView8.OptionsView.ShowGroupPanel = false;
            this.gridView8.OptionsView.ShowIndicator = false;
            this.gridView8.PaintStyleName = "(Default)";
            // 
            // gridColumn56
            // 
            this.gridColumn56.Caption = "Current Name";
            this.gridColumn56.FieldName = "CARI_ISIM";
            this.gridColumn56.Name = "gridColumn56";
            this.gridColumn56.Visible = true;
            this.gridColumn56.VisibleIndex = 1;
            this.gridColumn56.Width = 553;
            // 
            // gridColumn57
            // 
            this.gridColumn57.Caption = "Current Code";
            this.gridColumn57.FieldName = "CARI_KOD";
            this.gridColumn57.Name = "gridColumn57";
            this.gridColumn57.Visible = true;
            this.gridColumn57.VisibleIndex = 0;
            this.gridColumn57.Width = 138;
            // 
            // Form_ReportCurrentTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 810);
            this.Controls.Add(this.grid_currentSearch);
            this.Controls.Add(this.grid_report);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ReportCurrentTransaction";
            this.Text = "Current Transaction Report";
            this.Load += new System.EventHandler(this.Form_CurrentTransactionReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.date_2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_current.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_currentSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_Report;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit date_2;
        private DevExpress.XtraEditors.DateEdit date_1;
        private DevExpress.XtraEditors.TextEdit tb_current;
        private System.Windows.Forms.ToolStripMenuItem sendExcelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.GridControl grid_report;
        private DevExpress.XtraGrid.GridControl grid_currentSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn56;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn57;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}