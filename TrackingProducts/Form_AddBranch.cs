using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TrackingProducts
{
    public partial class Form_AddBranch : DevExpress.XtraEditors.XtraForm
    {
        DAL _data = new DAL();
        GeneralClasses _general = new GeneralClasses();
        DataTable _table = new DataTable();

        public int _id;
        public static string _branchCode, _branchName;

        public Form_AddBranch()
        {
            InitializeComponent();
        }

        private void Save()
        {
            try
            {
                _data.commandQuery("INSERT INTO [dbo].[TBL_SUBE] ([SUBE_KOD],[SUBE_AD]) VALUES ('" + _branchCode + "','"+ _branchName +"')");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public void Refresh_()
        {
            _id = 0;
            _branchCode = null;
            _branchName = null;
            tb_branchCode.Text = _branchCode;
            tb_BranchName.Text = _branchName;
        }

        public void Delete()
        {
            _data.commandQuery("DELETE FROM TBL_SUBE WHERE SUBE = '" + _branchCode + "' AND ID = " + _id + "");

            _table.Clear();
            _table = _data.fetchQuery("SELECT * FROM [dbo].[TBL_SUBE]");

            grid_Branch.DataSource = _table;
        }

        private void Form_AddBranch_Load(object sender, EventArgs e)
        {
            _table = _data.fetchQuery("SELECT * FROM [dbo].[TBL_SUBE]");
            grid_Branch.DataSource = _table;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Save();
            _table.Clear();
            _table = _data.fetchQuery("SELECT * FROM [dbo].[TBL_SUBE]");
            grid_Branch.DataSource = _table;
            Refresh_();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Delete();
            Refresh_();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Refresh_();
            _table.Clear();
        }

        private void tb_branchCode_Leave(object sender, EventArgs e)
        {
            _branchCode = tb_branchCode.Text;
        }

        private void tb_BranchName_Leave(object sender, EventArgs e)
        {
            _branchName = tb_BranchName.Text;
        }

        private void grid_Branch_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr1 = null;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
                hi = gridView1.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0) dr1 = gridView1.GetDataRow(hi.RowHandle);
            else
            if (gridView1.FocusedRowHandle >= 0) dr1 = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            else dr1 = null;

            if (dr1 != null)
            {
                _id = Convert.ToInt16(dr1["ID"]);
                _branchCode = dr1["SUBE"].ToString();
            }

            tb_branchCode.Text = _branchCode;
        }
    }
}