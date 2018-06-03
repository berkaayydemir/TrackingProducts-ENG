namespace TrackingProducts
{
    partial class Form_ReportStockTransaction
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
            DevExpress.XtraPivotGrid.PivotGridFormatRule pivotGridFormatRule1 = new DevExpress.XtraPivotGrid.PivotGridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleAboveBelowAverage formatConditionRuleAboveBelowAverage1 = new DevExpress.XtraEditors.FormatConditionRuleAboveBelowAverage();
            DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings formatRuleTotalTypeSettings1 = new DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ReportStockTransaction));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pGrid_Report = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pGrid_Report)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pGrid_Report);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1250, 822);
            this.panelControl1.TabIndex = 0;
            // 
            // pGrid_Report
            // 
            this.pGrid_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid_Report.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField6,
            this.pivotGridField2,
            this.pivotGridField7,
            this.pivotGridField8,
            this.pivotGridField9});
            pivotGridFormatRule1.Name = "Format0";
            pivotGridFormatRule1.Rule = formatConditionRuleAboveBelowAverage1;
            pivotGridFormatRule1.Settings = formatRuleTotalTypeSettings1;
            this.pGrid_Report.FormatRules.Add(pivotGridFormatRule1);
            this.pGrid_Report.Location = new System.Drawing.Point(2, 2);
            this.pGrid_Report.Name = "pGrid_Report";
            this.pGrid_Report.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.LegacyOptimized;
            this.pGrid_Report.Size = new System.Drawing.Size(1246, 818);
            this.pGrid_Report.TabIndex = 0;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Lagercode";
            this.pivotGridField1.FieldName = "STOK_KODU";
            this.pivotGridField1.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField6.AreaIndex = 1;
            this.pivotGridField6.Caption = "Branchencode";
            this.pivotGridField6.FieldName = "SUBE_KOD";
            this.pivotGridField6.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.pivotGridField6.Name = "pivotGridField6";
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField2.AreaIndex = 0;
            this.pivotGridField2.Caption = "Branchenname";
            this.pivotGridField2.FieldName = "SUBE_AD";
            this.pivotGridField2.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField7.AreaIndex = 1;
            this.pivotGridField7.Caption = "Farbe";
            this.pivotGridField7.FieldName = "COLOR";
            this.pivotGridField7.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.pivotGridField7.Name = "pivotGridField7";
            // 
            // pivotGridField8
            // 
            this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField8.AreaIndex = 2;
            this.pivotGridField8.Caption = "Größe";
            this.pivotGridField8.FieldName = "SIZE";
            this.pivotGridField8.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.pivotGridField8.Name = "pivotGridField8";
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField9.AreaIndex = 0;
            this.pivotGridField9.Caption = "Menge";
            this.pivotGridField9.CellFormat.FormatString = "#,##0.00";
            this.pivotGridField9.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField9.FieldName = "MIKTAR";
            this.pivotGridField9.GrandTotalCellFormat.FormatString = "#,##0.00";
            this.pivotGridField9.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField9.Name = "pivotGridField9";
            this.pivotGridField9.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.pivotGridField9.UseNativeFormat = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridField9.ValueFormat.FormatString = "#,##0.00";
            this.pivotGridField9.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // Form_ReportStockTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 822);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ReportStockTransaction";
            this.Text = "Bestands Detail Bericht";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_StockTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pGrid_Report)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pGrid_Report;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField8;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
    }
}