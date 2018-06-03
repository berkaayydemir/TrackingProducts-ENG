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
    public partial class Form_AddColor : DevExpress.XtraEditors.XtraForm
    {
        DAL _data = new DAL();
        GeneralClasses _general = new GeneralClasses();
        DataTable _table = new DataTable();

        public int _id;
        public static string _colorName;

        public Form_AddColor()
        {
            InitializeComponent();
        }

        private void Save()
        {
            try
            {
                _data.commandQuery("INSERT INTO [dbo].[TBL_COLOR] ([COLOR]) VALUES ('" + _colorName + "')");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public void Refresh_()
        {
            _id = 0; _colorName = null;
            tb_colorName.Text = _colorName;
        }

        public void Delete()
        {
            _data.commandQuery("DELETE FROM TBL_COLOR WHERE COLOR = '" + _colorName + "' AND ID = " + _id + "");

            _table.Clear();
            _table = _data.fetchQuery("SELECT * FROM [dbo].[TBL_COLOR]");

            grid_Color.DataSource = _table;
        }

        private void Form_AddColor_Load(object sender, EventArgs e)
        {
            _table = _data.fetchQuery("SELECT * FROM [dbo].[TBL_COLOR]");
            grid_Color.DataSource = _table;
        }

        private void tb_colorName_Leave(object sender, EventArgs e)
        {
            _colorName = tb_colorName.Text;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Save();
            _table.Clear();
            _table = _data.fetchQuery("SELECT * FROM [dbo].[TBL_COLOR]");
            grid_Color.DataSource = _table;
            Refresh_();
        }

        private void grid_Color_DoubleClick(object sender, EventArgs e)
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
                _colorName = dr1["COLOR"].ToString();
            }

            tb_colorName.Text = _colorName;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Delete();
            Refresh();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Refresh_();
            _table.Clear();
        }


    }
}