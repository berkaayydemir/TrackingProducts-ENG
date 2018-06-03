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
    }
}