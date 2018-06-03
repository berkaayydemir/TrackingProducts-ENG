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
    public partial class Form_AddSize : DevExpress.XtraEditors.XtraForm
    {
        DAL _data = new DAL();
        GeneralClasses _general = new GeneralClasses();
        DataTable _table = new DataTable();

        public int _id;
        public static string _sizeNumber;

        public Form_AddSize()
        {
            InitializeComponent();
        }

        private void Save()
        {
            try
            {
                _data.commandQuery("INSERT INTO [dbo].[TBL_SIZE] ([SIZE]) VALUES ('" + _sizeNumber + "')");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public void Refresh_()
        {
            _id = 0; _sizeNumber = null;
            tb_sizeNumber.Text = _sizeNumber;
        }

        public void Delete()
        {
            _data.commandQuery("DELETE FROM TBL_SIZE WHERE SIZE = '" + _sizeNumber + "' AND ID = " + _id + "");

            _table.Clear();
            _table = _data.fetchQuery("SELECT * FROM [dbo].[TBL_SIZE]");

            grid_Size.DataSource = _table;
        }

        private void Form_AddSize_Load(object sender, EventArgs e)
        {
            _table = _data.fetchQuery("SELECT * FROM [dbo].[TBL_SIZE]");
            grid_Size.DataSource = _table;
        }

        private void tb_sizeNumber_Leave(object sender, EventArgs e)
        {
            _sizeNumber = tb_sizeNumber.Text;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Save();
            _table.Clear();
            _table = _data.fetchQuery("SELECT * FROM [dbo].[TBL_SIZE]");
            grid_Size.DataSource = _table;
            Refresh_();
        }

        private void grid_Size_DoubleClick(object sender, EventArgs e)
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
                _sizeNumber = dr1["SIZE"].ToString();
            }

            tb_sizeNumber.Text = _sizeNumber;
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
    }
}