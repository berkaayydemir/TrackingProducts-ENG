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
    public partial class Form_CurrentList : DevExpress.XtraEditors.XtraForm
    {
        DAL Data = new DAL();
        GeneralClasses General = new GeneralClasses();
        DataTable CurrentList = new DataTable();

        public static string currentCode, currentName;

        public Form_CurrentList()
        {
            InitializeComponent();
        }

        private void Form_CustomersList_Load(object sender, EventArgs e)
        {
            CurrentList = Data.fetchQuery("SELECT * FROM [dbo].[TBL_CARISABIT]");
            grid_currentList.DataSource = CurrentList;
        }

        private void tb_currentCode_Leave(object sender, EventArgs e)
        {
            currentCode = tb_currentCode.Text;
        }

        private void tb_currentCode_TextChanged(object sender, EventArgs e)
        {
            string a = tb_currentCode.Text;
            DataTable CariRehber = new DataTable();
            int satirsay = 0;

            if (a == "" || a == null)
            {
                FullList();
            }
            else
            {
                CariRehber = Data.fetchQuery("SELECT COUNT(CARI_KOD) AS SAY FROM TBL_CARISABIT WHERE CARI_KOD LIKE '%" + General.changeCharacter(a) + "%'");
                satirsay = CariRehber.Rows.Count;

                if (satirsay == 0)
                {
                    CariRehber = Data.fetchQuery("SELECT CARI_KOD, CARI_ISIM FROM TBL_CARISABIT ");
                    grid_currentList.Visible = false;
                }
                else
                {
                    grid_currentList.Visible = true;
                    CariRehber.Clear();
                    CariRehber = Data.fetchQuery("SELECT TOP 25 CARI_KOD,CARI_ISIM FROM TBL_CARISABIT WHERE CARI_KOD LIKE '%" + General.changeCharacter(a) + "%'");

                    grid_currentList.DataSource = CariRehber;
                }
            }
        }

        private void tb_currentName_Leave(object sender, EventArgs e)
        {
            currentName = tb_currentName.Text;
        }

        private void tb_currentName_TextChanged(object sender, EventArgs e)
        {
            string a = tb_currentName.Text;
            DataTable CariRehber = new DataTable();
            int satirsay = 0;

            if (a == "" || a == null)
            {
                FullList();
            }
            else
            {
                CariRehber = Data.fetchQuery("SELECT COUNT(CARI_ISIM) AS SAY FROM TBL_CARISABIT WHERE CARI_ISIM LIKE '%" + General.changeCharacter(a) + "%'");
                satirsay = Convert.ToInt32(CariRehber.Rows[0]["SAY"]);

                if (satirsay == 0)
                {
                    CariRehber = Data.fetchQuery("SELECT CARI_KOD, CARI_ISIM FROM TBL_CARISABIT ");
                    grid_currentList.Visible = false;
                }
                else
                {
                    grid_currentList.Visible = true;
                    CariRehber.Clear();
                    CariRehber = Data.fetchQuery("SELECT CARI_KOD,CARI_ISIM FROM TBL_CARISABIT WHERE CARI_ISIM LIKE '%" + General.changeCharacter(a) + "%'");

                    grid_currentList.DataSource = CariRehber;
                }
            }
        }

        private void grid_currentList_DoubleClick(object sender, EventArgs e)
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
                currentCode = dr1["CARI_KOD"].ToString();
                currentName = dr1["CARI_ISIM"].ToString();
            }
            grid_currentList.Visible = true;

            this.Close();
        }

        private void sendExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Kunden Transaktion Report(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")";
            save.Filter = "Excel-Arbeitsmappe |*.xls";
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (save.ShowDialog() == DialogResult.OK) //Pencerede kayıt düğmesine basıldıysa
            {
                grid_currentList.ExportToXls(save.FileName);
            }

            if (MessageBox.Show("Öffnen Sie die exportierte Datei?", "Excel-Datei", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Kaydedilen Excel Dosyasını açar.
                System.Diagnostics.Process.Start(save.FileName);
            }
        }

        public void FullList()
        {
            CurrentList.Clear();
            CurrentList = Data.fetchQuery("SELECT TOP 25 CARI_KOD, CARI_ISIM FROM TBL_CARISABIT");
            grid_currentList.DataSource = CurrentList;
        }

    }
}