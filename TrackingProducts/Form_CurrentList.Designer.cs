namespace TrackingProducts
{
    partial class Form_CurrentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CurrentList));
            this.grid_currentList = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_currentName = new DevExpress.XtraEditors.TextEdit();
            this.tb_currentCode = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_currentList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_currentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_currentCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_currentList
            // 
            this.grid_currentList.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_currentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_currentList.Location = new System.Drawing.Point(200, 0);
            this.grid_currentList.MainView = this.gridView1;
            this.grid_currentList.Name = "grid_currentList";
            this.grid_currentList.Size = new System.Drawing.Size(1084, 823);
            this.grid_currentList.TabIndex = 203;
            this.grid_currentList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grid_currentList.DoubleClick += new System.EventHandler(this.grid_currentList_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendExcelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 26);
            // 
            // sendExcelToolStripMenuItem
            // 
            this.sendExcelToolStripMenuItem.Name = "sendExcelToolStripMenuItem";
            this.sendExcelToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.sendExcelToolStripMenuItem.Text = "Send As Excel";
            this.sendExcelToolStripMenuItem.Click += new System.EventHandler(this.sendExcelToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.grid_currentList;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Current Code";
            this.gridColumn1.FieldName = "CARI_KOD";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Current Name";
            this.gridColumn2.FieldName = "CARI_ISIM";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 201;
            this.label2.Text = "Current Name";
            // 
            // tb_currentName
            // 
            this.tb_currentName.Location = new System.Drawing.Point(8, 77);
            this.tb_currentName.Name = "tb_currentName";
            this.tb_currentName.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_currentName.Properties.Appearance.Options.UseFont = true;
            this.tb_currentName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.tb_currentName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_currentName.Size = new System.Drawing.Size(180, 26);
            this.tb_currentName.TabIndex = 200;
            this.tb_currentName.Tag = "Cari Kod";
            this.tb_currentName.TextChanged += new System.EventHandler(this.tb_currentName_TextChanged);
            this.tb_currentName.Leave += new System.EventHandler(this.tb_currentName_Leave);
            // 
            // tb_currentCode
            // 
            this.tb_currentCode.Location = new System.Drawing.Point(8, 26);
            this.tb_currentCode.Name = "tb_currentCode";
            this.tb_currentCode.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_currentCode.Properties.Appearance.Options.UseFont = true;
            this.tb_currentCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.tb_currentCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_currentCode.Size = new System.Drawing.Size(180, 26);
            this.tb_currentCode.TabIndex = 198;
            this.tb_currentCode.Tag = "Cari Kod";
            this.tb_currentCode.TextChanged += new System.EventHandler(this.tb_currentCode_TextChanged);
            this.tb_currentCode.Leave += new System.EventHandler(this.tb_currentCode_Leave);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.tb_currentName);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.tb_currentCode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(200, 823);
            this.panelControl1.TabIndex = 202;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 199;
            this.label1.Text = "Current Code";
            // 
            // Form_CurrentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 823);
            this.Controls.Add(this.grid_currentList);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CurrentList";
            this.Text = "Current Guide";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_CustomersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_currentList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_currentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_currentCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_currentList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendExcelToolStripMenuItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit tb_currentName;
        private DevExpress.XtraEditors.TextEdit tb_currentCode;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
    }
}