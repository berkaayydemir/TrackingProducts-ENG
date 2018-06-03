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
    public partial class Form_ReportCurrentTransaction : DevExpress.XtraEditors.XtraForm
    {
        GeneralClasses _general = new GeneralClasses();
        DAL _data = new DAL();
        DataTable _reportTable = new DataTable();


        string _date1, _date2, _currentCode, _currentName;
        DateTime _d1, _d2;

        private void ReportFunction()
        {
            if (_currentCode == null || _currentCode == "")
            {
                _reportTable.Clear();
                _reportTable = _data.fetchQuery("SELECT * FROM VW_CARIRAPOR WHERE HARK_TARH BETWEEN '" + _date1 + "' AND '" + _date2 + "' ORDER BY HARK_TARH");
                grid_report.DataSource = _reportTable;
            }
            else
            {
                _reportTable.Clear();
                _reportTable = _data.fetchQuery("SELECT * FROM VW_CARIRAPOR WHERE CARI_KOD = '" + _currentCode + "' AND  HARK_TARH BETWEEN '" + _date1 + "' AND '" + _date2 + "' ORDER BY CARI_KOD, HARK_TARH ");
                grid_report.DataSource = _reportTable;
            }

        }

        private void date_1_EditValueChanged(object sender, EventArgs e)
        {
            _d1 = Convert.ToDateTime(date_1.EditValue);
            _date1 = _general.editDateFormat(_d1, 0);
        }

        private void date_2_EditValueChanged(object sender, EventArgs e)
        {
            _d2 = Convert.ToDateTime(date_2.EditValue);
            _date2 = _date1 = _general.editDateFormat(_d2, 0);
        }

        private void sendExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Kunde Transaktion Report(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")";
            save.Filter = "Excel-Arbeitsmappe |*.xls";
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (save.ShowDialog() == DialogResult.OK) //Pencerede kayıt düğmesine basıldıysa
            {
                grid_report.ExportToXls(save.FileName);
            }

            if (MessageBox.Show("Öffnen Sie die exportierte Datei?", "Excel-Datei", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Kaydedilen Excel Dosyasını açar.
                System.Diagnostics.Process.Start(save.FileName);
            }
        }

        private void date_2_Leave(object sender, EventArgs e){
            _d1 = Convert.ToDateTime(date_1.Text);
            _d2 = Convert.ToDateTime(date_2.Text);

            if (_d2 < _d1)
            {
                MessageBox.Show("Zweites Datum, kann vom ersten Datum an nicht klein sein!");
                date_1.Focus();
            }
            else
            {
                _date1 = _general.editDateFormat(_d1, 0);
                _date2 = _general.editDateFormat(_d2, 0);
            }
        }

        private void tb_current_TextChanged(object sender, EventArgs e)
        {
            DataTable Cari = new DataTable();
            int satirsay = 0;

            if (tb_current.Text == "")
            {
                grid_currentSearch.Visible = false;
            }
            else
            {
                Cari = _data.fetchQuery("SELECT COUNT(CARI_KOD) AS SAY FROM TBL_CARISABIT WHERE CARI_ISIM LIKE '%" + _general.changeCharacter(tb_current.Text) + "%'");
                satirsay = Cari.Rows.Count;

                if (satirsay == 0)
                {
                    grid_currentSearch.Visible = false;
                }
                else
                {
                    grid_currentSearch.Location = new Point(12, 49);
                    //grid_currentSearch.Size = new Size(583, 150);
                    grid_currentSearch.Visible = true;

                    Cari.Clear();

                    Cari = _data.fetchQuery("SELECT TOP 25 CARI_KOD,CARI_ISIM FROM TBL_CARISABIT WHERE CARI_ISIM LIKE '%" + _general.changeCharacter(tb_current.Text) + "%'");

                    grid_currentSearch.DataSource = Cari;
                }
            }
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            if (_date1 == "" && _date2 == "")
            {
                MessageBox.Show("Bitte Datum wählen!");
            }
            else
            {
                grid_report.Visible = true;
                ReportFunction();
            }
        }

        private void Form_CurrentTransactionReport_Load(object sender, EventArgs e)
        {
            date_1.Text = DateTime.Now.ToShortDateString();
            date_2.Text = DateTime.Now.ToShortDateString();
            _d1 = Convert.ToDateTime(date_1.Text);
            _d2 = Convert.ToDateTime(date_2.Text);
            _date1 = _general.editDateFormat(_d1, 0);
            _date2 = _general.editDateFormat(_d2, 0);
            grid_report.Visible = true;
        }

        private void grid_currentSearch_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr1 = null;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
                hi = gridView8.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0) dr1 = gridView8.GetDataRow(hi.RowHandle);
            else
            if (gridView8.FocusedRowHandle >= 0) dr1 = gridView8.GetDataRow(gridView8.FocusedRowHandle);
            else dr1 = null;

            if (dr1 != null)
            {
                _currentCode = dr1["CARI_KOD"].ToString();
                _currentName = dr1["CARI_ISIM"].ToString();
            }


            tb_current.Text = _currentName;
            grid_currentSearch.Visible = false;
            ReportFunction();
        }

        private void date_1_Leave(object sender, EventArgs e)
        {
            _d1 = Convert.ToDateTime(date_1.Text);
            _d2 = Convert.ToDateTime(date_2.Text);
            if (_d2 < _d1)
            {
                MessageBox.Show("Zweite Datum, kann nicht vom ersten Datum klein sein!");
                date_1.Focus();
            }
            else
            {
                _date1 = _general.editDateFormat(_d1, 0);
                _date2 = _general.editDateFormat(_d2, 0);
            }
        }

        public Form_ReportCurrentTransaction()
        {
            InitializeComponent();
        }
    }
}