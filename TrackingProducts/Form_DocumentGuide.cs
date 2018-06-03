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
    public partial class Form_DocumentGuide : DevExpress.XtraEditors.XtraForm
    {
        DAL Data = new DAL();
        DataTable Guide = new DataTable();
        public static string CurrentCode, CurrentName, DocumentNo;

        public Form_DocumentGuide()
        {
            InitializeComponent();
        }

        private void Form_DocumentGuide_Load(object sender, EventArgs e)
        {
            Guide = Data.fetchQuery("SELECT TOP 30 * FROM VW_REHBER");
            grid_guide.DataSource = Guide;
        }

        private void grid_guide_DoubleClick(object sender, EventArgs e)
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
                CurrentCode = dr1["CARI_KOD"].ToString();
                CurrentName = dr1["CARI_ISIM"].ToString();
                DocumentNo = dr1["BELGE_NO"].ToString();
            }

            grid_guide.Visible = true;
            this.Close();
        }
    }
}