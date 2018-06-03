using System;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace TrackingProducts
{
    public partial class FormMain : XtraForm
    {
        
        string _sqlservername, _sqlusername, _sqlpass, _database;

        public FormMain()
        {
            InitializeComponent();
        }

        public void RegisterWrite()
        {
            Registry.CurrentUser.CreateSubKey("DESPRO").CreateSubKey("DBCONNECTION");
            Registry.CurrentUser.CreateSubKey("DESPRO").CreateSubKey("DBCONNECTION").SetValue("SQLSERVER", _sqlservername);
            Registry.CurrentUser.CreateSubKey("DESPRO").CreateSubKey("DBCONNECTION").SetValue("SQLUSERNAME", _sqlusername);
            Registry.CurrentUser.CreateSubKey("DESPRO").CreateSubKey("DBCONNECTION").SetValue("SQLPASS", Passencodedecode(0, _sqlpass));
            Registry.CurrentUser.CreateSubKey("DESPRO").CreateSubKey("DBCONNECTION").SetValue("DB", _database);
            Registry.CurrentUser.Flush();
            Registry.CurrentUser.Close();
        }

        public void RegisterRead()
        {
            RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"DESPRO\DBCONNECTION", true);

            if (key1 == null)
            {
                grp_serverconnect.Visible = true;
            }

            else
            {
                _sqlservername = key1.GetValue("SQLSERVER").ToString();
                _sqlusername = key1.GetValue("SQLUSERNAME").ToString();
                _sqlpass = key1.GetValue("SQLPASS").ToString();
                _database = key1.GetValue("DB").ToString();

                tb_sqlservername.Text = _sqlservername;
                tb_sqlusername.Text = _sqlusername;
                tb_sqlpass.Text = Passencodedecode(1, _sqlpass);
                tb_database.Text = _database;
            }
        }

        public static string Passencodedecode(byte x, string y)
        {
            int a = y.Length;
            string passchar1 = null;
            string[] passchar = new string[a];
            byte[] array = Encoding.ASCII.GetBytes(y);

            if (x == 0)
            {
                for (int i = 0; i < a; i++)
                {
                    passchar[i] = Convert.ToChar(array[i] + 7).ToString();
                    passchar1 = passchar1 + passchar[i];
                }
            }
            else
            {
                for (int i = 0; i < a; i++)
                {
                    passchar[i] = Convert.ToChar(array[i] - 7).ToString();
                    passchar1 = passchar1 + passchar[i];
                }
            }

            return passchar1;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            RegisterRead();
        }

        private void barbtn_Customers_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_Current chldfrm = new Form_Current();
            chldfrm.MdiParent = this;
            chldfrm.Show();

        }

        private void barbtn_Stocks_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_Stocks chldfrm = new Form_Stocks();
            chldfrm.MdiParent = this;
            chldfrm.Show();
        }

        private void barbtn_Sales_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_Sales chldfrm = new Form_Sales();
            chldfrm.MdiParent = this;
            chldfrm.Show();
        }

        private void m_Report_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_ReportCurrentTransaction childform = new Form_ReportCurrentTransaction();
            childform.MdiParent = this;
            childform.Show();
        }

        private void barbtn_Exit_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActiveForm.Close();
        }

        private void barbtn_Color_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_AddColor rehber = new Form_AddColor();
            rehber.ShowDialog();
        }

        private void bar_btnSize_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_AddSize rehber = new Form_AddSize();
            rehber.ShowDialog();
        }

        private void barbtn_branch_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_AddBranch rehber = new Form_AddBranch();
            rehber.ShowDialog();
        }

        private void barbtn_currentTransactionReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_ReportCurrentTransaction childform = new Form_ReportCurrentTransaction();
            childform.MdiParent = this;
            childform.Show();
        }

        private void barbtn_StockTransactionReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_ReportStockTransaction childform = new Form_ReportStockTransaction();
            childform.MdiParent = this;
            childform.Show();
        }

        private void barbtn_Help_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form_About childform = new Form_About();
            childform.ShowDialog();
        }

        private void tb_sqlservername_Leave(object sender, EventArgs e)
        {
            _sqlservername = tb_sqlservername.Text;
        }

        private void tb_sqlusername_Leave(object sender, EventArgs e)
        {
            _sqlusername = tb_sqlusername.Text;
        }

        private void tb_sqlpass_Leave(object sender, EventArgs e)
        {
            _sqlpass = tb_sqlpass.Text;
        }

        private void tb_database_Leave(object sender, EventArgs e)
        {
            _database = tb_database.Text;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            RegisterWrite();
            MessageBox.Show(@"Bitte schließen Sie das Programm und führen Sie es erneut für den Betrieb der neuen Einstellungen aus.");
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null) ActiveForm.Close();
        }
    }
}
