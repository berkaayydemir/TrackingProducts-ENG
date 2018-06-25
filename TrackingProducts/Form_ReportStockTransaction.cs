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
    public partial class Form_ReportStockTransaction : DevExpress.XtraEditors.XtraForm
    {
        GeneralClasses _general = new GeneralClasses();
        DAL _data = new DAL();
        DataTable _reportTable = new DataTable();

        public Form_ReportStockTransaction()
        {
            InitializeComponent();
        }

        private void Form_StockTransaction_Load(object sender, EventArgs e)
        {
            _reportTable = _data.fetchQuery("SELECT * FROM VW_STOKDETAYRAPOR");
            pGrid_Report.DataSource = _reportTable;
        }

        private void sendenSieExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Kunde Transaktion Report(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")";
            save.Filter = "Excel-Arbeitsmappe |*.xls";
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (save.ShowDialog() == DialogResult.OK) //Pencerede kayıt düğmesine basıldıysa
            {
                pGrid_Report.ExportToXls(save.FileName);
            }

            if (MessageBox.Show("Öffnen Sie die exportierte Datei?", "Excel-Datei", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Kaydedilen Excel Dosyasını açar.
                System.Diagnostics.Process.Start(save.FileName);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}