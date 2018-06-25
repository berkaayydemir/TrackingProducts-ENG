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
using System.Data.SqlClient;
using System.IO;

namespace TrackingProducts
{
    public partial class Form_Stocks : DevExpress.XtraEditors.XtraForm
    {
        GeneralClasses _general = new GeneralClasses();
        DAL Data = new DAL();
        DataTable _stockTable = new DataTable();
        DataTable _stocksMovement = new DataTable();

        string _search1, _search2, _stockCode, _stockName, _storeCode, _description, _code1, _groupCode, _r1, _r2, _r3, _r4, _r5, _r6, _r7, _r8, _r9, _r10, _b1, _b2, _b3, _b4, _b5, _b6, _b7, _b8, _b9, _b10, _groupCode2, _k1, _k2, _k3, _k4, _k5, _imagePath;

        public string _branchCode, _color, _size;
        public string _gckod, _typeMove;
        private DateTime trh;
        private double _zeroVariable = 0;
        public double _entryquantity,_price;
        public int _oneVariable;

        private string _stokCodeMove;
        private int _variationMove;


        private void dt_date_EditValueChanged(object sender, EventArgs e)
        {
            _date = Convert.ToDateTime(dt_date.EditValue);
            dt_date.Text = _date.ToShortDateString();
        }

        private void tb_price_Leave(object sender, EventArgs e)
        {
            _price = Convert.ToDouble(tb_price.Text);
        }

        private void tb_entryQuantity_Leave(object sender, EventArgs e)
        {
            _entryquantity = Convert.ToDouble(tb_entryQuantity.Text);
        }

        private void btn_itemRefresh_Click(object sender, EventArgs e)
        {
            movementRefresh();
            //_stocksMovement.Clear();
        }

        private void btn_deleteMOVE_Click(object sender, EventArgs e)
        {
            Data.commandQuery("DELETE FROM TBL_STOKHAREKET WHERE STOK_KODU = '" + _stockCode + "' AND VARYASYON_KODU = " + _variation + " AND ID ='"+_id+"' ");
            movementRefresh();
            _stocksMovement.Clear();
            _stocksMovement =
                _stocksMovement = Data.fetchQuery("SELECT *,dbo.FNC_STOK_YURUYEN_BAKIYE(ID,STOK_KODU,SUBE_KOD,'E') AS BAKIYE FROM TBL_STOKHAREKET WHERE STOK_KODU = '" + _stockCode + "' AND VARYASYON_KODU='" + _variation + "'");
            grid_StockMotion.DataSource = _stocksMovement;

            
            //xtraTabControl1.Visible = false;
            //MessageBox.Show(@"Erfolgreich gelöscht.");
        }

        private void grid_StockMotion_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr1 = null;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
                hi = gridView2.CalcHitInfo((grid_StockMotion as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0) dr1 = gridView2.GetDataRow(hi.RowHandle);
            else if (gridView2.FocusedRowHandle >= 0) dr1 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            else dr1 = null;

            if (dr1 != null)
            {
                _id = Convert.ToInt32(dr1["ID"]);
                _typeMove = dr1["HAR_TUR"].ToString();
            }

            FetchDataMove(_stockCode, _variation, _id);
        }

        private void tb_desciptionMove_Leave(object sender, EventArgs e)
        {
            _description = tb_desciptionMove.Text;
        }

        private void sendenSieExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Kunde Transaktion Report(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")";
            save.Filter = "Excel-Arbeitsmappe |*.xls";
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (save.ShowDialog() == DialogResult.OK) //Pencerede kayıt düğmesine basıldıysa
            {
                grid_StockMotion.ExportToXls(save.FileName);
            }

            if (MessageBox.Show("Öffnen Sie die exportierte Datei?", "Excel-Datei", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Kaydedilen Excel Dosyasını açar.
                System.Diagnostics.Process.Start(save.FileName);
            }
        }

        private void sendAsExcelForStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Kunden Transaktion Reporter(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")";
            save.Filter = "Excel-Arbeitsmappe |*.xls";
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (save.ShowDialog() == DialogResult.OK) //Pencerede kayıt düğmesine basıldıysa
            {
                grid_stockList.ExportToXls(save.FileName);
            }

            if (MessageBox.Show("Öffnen Sie die exportierte Datei?", "Excel-Datei", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Kaydedilen Excel Dosyasını açar.
                System.Diagnostics.Process.Start(save.FileName);
            }
        }

        public void FetchDataMove(string sk, int vr, int id)
        {
            DataTable _stockTable = new DataTable();

            _stockTable = Data.fetchQuery("SELECT * FROM TBL_STOKHAREKET WHERE STOK_KODU = '" + sk + "' AND VARYASYON_KODU = '" + vr + "' AND ID = '" + id + "'");

            _branchCode = _stockTable.Rows[0]["SUBE_KOD"].ToString();
            _color = _stockTable.Rows[0]["COLOR"].ToString();
            _size = _stockTable.Rows[0]["SIZE"].ToString();
            _entryquantity = Convert.ToDouble(_stockTable.Rows[0]["MIKTAR"].ToString());
            _price = Convert.ToDouble(_stockTable.Rows[0]["NET_FIYAT"].ToString());
            trh = Convert.ToDateTime(_stockTable.Rows[0]["TARIH"].ToString());
            _gckod = _stockTable.Rows[0]["GC_KOD"].ToString();
            _description = _stockTable.Rows[0]["ACIKLAMA"].ToString();

            if (_gckod == "G")
            {
                radioGroup1.SelectedIndex = 0;
                _gckod = "G";
            }
            else
            {
                radioGroup1.SelectedIndex = 1;
                _gckod = "C";
            }

            cb_branch.Text = _branchCode;
            cb_color.Text = _color;
            cb_size.Text = _size;
            tb_entryQuantity.Text = _entryquantity.ToString();
            tb_price.Text = _price.ToString();
            dt_date.Text = _date.ToShortDateString();
            tb_desciptionMove.Text = _description;
        }



        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                _gckod = "G";
            }
            else
            {
                _gckod = "C";
            }
        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            _stocksMovement.Clear();
            Data.commandQuery("INSERT INTO [dbo].[TBL_STOKHAREKET](" +
                              "[STOK_KODU]," +
                              "[VARYASYON_KODU]," +
                              "[GC_KOD]," +
                              "[TARIH]," +
                              "[TES_TARIH]" +
                              ",[FTIRSIP]" +
                              ",[FISNO]" +
                              ",[HAR_TUR]" +
                              ",[SIPNO]" +
                              ",[IRSNO]" +
                              ",[ACIKLAMA]" +
                              ",[CARI_KOD]" +
                              ",[SUBE_KOD]" +
                              ",[COLOR]" +
                              ",[SIZE]" +
                              ",[MIKTAR]" +
                              ",[BRUT_FIYAT]" +
                              ",[NET_FIYAT]" +
                              ",[ISK1]" +
                              ",[ISK2]" +
                              ",[ISK3]" +
                              ",[ISK4]" +
                              ",[KDV_ORAN]" +
                              ",[BELGE_TIPI]" +
                              ",[SIRA]) " +
                              "VALUES('" 
                              + _stockCode + "','"
                              + _variation + "','" 
                              + _gckod + "','" 
                              + _general.editDateFormat(trh, 0) + "','" 
                              + _general.editDateFormat(trh, 0) + "'," +
                              "'S'," +
                              "'MANUELKAYIT'," +
                              "'S'," +
                              "NULL," +
                              "NULL,'" 
                              + _description + "'," +
                              "'MANUELCARIKAYIT','" 
                              + _branchCode + "','" 
                              + _color + "','" 
                              + _size + "'," 
                              + _entryquantity + "," 
                              + _price.ToString().Replace(",", ".") + "," 
                              + _price.ToString().Replace(",", ".") + "," 
                              + _zeroVariable.ToString().Replace(",", ".") + "," 
                              + _zeroVariable.ToString().Replace(",", ".") + "," 
                              + _zeroVariable.ToString().Replace(",", ".") + " ," 
                              + _zeroVariable.ToString().Replace(",", ".") + "," 
                              + _zeroVariable.ToString().Replace(",", ".") + "," +
                              "'S'," 
                              + _oneVariable.ToString() + ")");

           

            _stocksMovement = Data.fetchQuery("SELECT *,dbo.FNC_STOK_YURUYEN_BAKIYE(ID,STOK_KODU,SUBE_KOD,'E') AS BAKIYE FROM TBL_STOKHAREKET WHERE STOK_KODU = '" + _stockCode + "' AND VARYASYON_KODU='" + _variation + "'");
            grid_StockMotion.DataSource = _stocksMovement;

            movementRefresh();
        }

        public string _lbBrach, _lbColor, _lbSize;

        private void cb_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            _size = cb_size.Text;

            try
            {
                DataTable _branchTable;
                DataTable _branchControl;
                int control = 0;

                _branchControl =
                    Data.fetchQuery("SELECT COUNT(SIZE) AS SAY FROM TBL_SIZE WHERE SIZE = '" + _size + "' ");
                control = Convert.ToInt32(_branchControl.Rows[0]["SAY"].ToString());

                if (control != 0)
                {
                    _branchTable = Data.fetchQuery("SELECT SIZE FROM TBL_SIZE WHERE SIZE = '" + _size + "' ");

                    _lbSize = _branchTable.Rows[0]["SIZE"].ToString();
                    lb_size.Text = _lbSize;
                }
                else
                {
                    lb_size.Text = null;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void cb_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            _color = cb_color.Text;

            try
            {
                DataTable _branchTable;
                DataTable _branchControl;
                int control = 0;

                _branchControl = Data.fetchQuery("SELECT COUNT(COLOR) AS SAY FROM TBL_COLOR WHERE COLOR = '" + _color + "' ");
                control = Convert.ToInt32(_branchControl.Rows[0]["SAY"].ToString());

                if (control != 0)
                {
                    _branchTable = Data.fetchQuery("SELECT COLOR FROM TBL_COLOR WHERE COLOR = '" + _color + "' ");

                    _lbColor = _branchTable.Rows[0]["COLOR"].ToString();
                    lb_color.Text = _lbColor;
                }
                else
                {
                    lb_color.Text = null;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cb_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            _branchCode = cb_branch.Text;
            try
            {
                DataTable _branchTable;
                DataTable _branchControl;
                int control = 0;

                _branchControl = Data.fetchQuery("SELECT COUNT(SUBE_KOD) AS SAY FROM TBL_SUBE WHERE SUBE_KOD = '" + _branchCode + "' ");
                control = Convert.ToInt32(_branchControl.Rows[0]["SAY"].ToString());

                if (control != 0)
                {
                    _branchTable = Data.fetchQuery("SELECT SUBE_AD FROM TBL_SUBE WHERE SUBE_KOD = '" + _branchCode + "' ");

                    _lbBrach = _branchTable.Rows[0]["SUBE_AD"].ToString();
                    lb_brachName.Text = _lbBrach;
                }
                else
                {
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        DateTime _date;

        int _colorNumber, _variation, _id, _id2;


        public Form_Stocks()
        {
            InitializeComponent();
        }

        private void Save()
        {
            DataTable kontrol = new DataTable();
            try
            {
                if (_variation != 0)
                {

                    if (StockControl(1) == 0)
                    {
                        string sorgu = "IF NOT EXISTS (SELECT KOD FROM [VW_STOKBILGI] WHERE STOK_KODU='" + _stockCode + _variation.ToString() + "') INSERT INTO [TBL_STOKSABITEK] ([STOK_KODU],[STOK_ADI],[GRUP_KODU],[KOD1],[KOD2],[KOD3],[KOD4],[KOD5])"
                         + " VALUES ('" + _stockCode + "','" + _stockName + "','" + _groupCode2 + "','" + _k1 + "','" + _k2 + "','" + _k3 + "','" + _k4 + "','" + _k5 + "') ";
                        Data.commandQuery(sorgu);
                    }

                    string sorgu1 = "IF NOT EXISTS (SELECT KOD FROM [VW_STOKBILGI] WHERE STOK_KODU='" + _stockCode + _variation.ToString() + "') INSERT INTO [dbo].[TBL_STOKSABIT] ([STOK_KODU],[VARYASYON_KODU],[KOD_1],[GRUP_KODU],[ACIKLAMA],[DEPO_KODU],[RENK_ADET],[RENK1],[BOBIN1],[RENK2],[BOBIN2],[RENK3],[BOBIN3],[RENK4],[BOBIN4],[RENK5],[BOBIN5],[RENK6],[BOBIN6],[RENK7],[BOBIN7],[RENK8],[BOBIN8],[RENK9],[BOBIN9],[RENK10],[BOBIN10],[VARYASYON_ACIKLAMA])"
                    + " VALUES ('" + _stockCode + "','" + _variation + "','" + _code1 + "','" + _groupCode + "','" + _description + "','" + _storeCode + "','" + _colorNumber + "','" + _r1 + "','" + _b1 + "','" + _r2 + "','" + _b2 + "','" + _r3 + "','" + _b3 + "','" + _r4 + "','" + _b4 + "','" + _r5 + "','" + _b5 + "','" + _r6 + "','" + _b6 + "','" + _r7 + "','" + _b7 + "','" + _r8 + "','" + _b8 + "','" + _r9 + "','" + _b9 + "','" + _r10 + "','" + _b10 + "' , '" + _stockName + "') ";
                    Data.commandQuery(sorgu1);

                    MessageBox.Show(@"Die Aufzeichnung ist abgeschlossen.");
                }
                else
                    MessageBox.Show(@"Der Variationscode darf nicht null sein!");
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            _stockTable = Data.fetchQuery("SELECT * FROM VW_STOKBILGI");
            grid_stocks.DataSource = _stockTable;

        }

        private void Edit()
        {
            try
            {
                string sorgu = "UPDATE [dbo].[TBL_STOKSABITEK] SET [STOK_KODU] = '" + _stockCode + "',[DEPO_KODU] = '" + _storeCode + "',[STOK_ADI] = '" + _stockName + "',[KOD_1] = '" + _code1 + "',[GRUP_KODU] = '" + _groupCode2 + "',[KOD1] = '" + _k1 + "',[KOD2] = '" + _k2 + "',[KOD3] = '" + _k3 + "',[KOD4] = '" + _k4 + "',[KOD5] = '" + _k5 + "' WHERE ID = '" + _id2 + "' AND STOK_KODU = '" + _stockCode + "' ";
                string sorgu1 = "UPDATE [dbo].[TBL_STOKSABIT] SET [STOK_KODU] = '" + _stockCode + "',[GRUP_KODU] = '" + _groupCode + "',[ACIKLAMA] = '" + _description + "',[DEPO_KODU] = '" + _storeCode + "',[RENK_ADET] = '" + _colorNumber + "',[RENK1] = '" + _r1 + "',[BOBIN1] = '" + _b1 + "',[RENK2] = '" + _r2 + "',[BOBIN2] = '" + _b2 + "',[RENK3] = '" + _r3 + "',[BOBIN3] = '" + _b3 + "',[RENK4] = '" + _r4 + "',[BOBIN4] = '" + _b4 + "',[RENK5] = '" + _r5 + "',[BOBIN5] = '" + _b5 + "',[RENK6] = '" + _r6 + "',[BOBIN6] = '" + _b6 + "',[RENK7] = '" + _r7 + "',[BOBIN7] = '" + _b7 + "',[RENK8] = '" + _r8 + "',[BOBIN8] = '" + _b8 + "',[RENK9] = '" + _r9 + "',[BOBIN9] = '" + _b9 + "',[RENK10] = '" + _r10 + "',[BOBIN10] = '" + _b10 + "'WHERE ID= '" + _id + "' AND STOK_KODU = '" + _stockCode + "' AND VARYASYON_KODU = '" + _variation + "' ";
                Data.commandQuery(sorgu);
                Data.commandQuery(sorgu1);

                MessageBox.Show(@"Die Aufzeichnung ist abgeschlossen.");
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            _stockTable = Data.fetchQuery("SELECT * FROM VW_STOKBILGI");
            grid_stocks.DataSource = _stockTable;

        }

        private void Delete()
        {
            try
            {
                if (_stockCode != null && _stockCode != "")
                {

                    int x = 0;
                    DataTable kontrol = new DataTable();
                    kontrol = Data.fetchQuery("SELECT COUNT(STOK_KODU) AS SAY FROM VW_STOKBILGI WHERE STOK_KODU = '" + _stockCode + "' ");
                    x = Convert.ToInt32(kontrol.Rows[0]["SAY"]);


                    if (x > 1)
                    {
                        Data.commandQuery("DELETE FROM [dbo].[TBL_STOKSABIT] WHERE STOK_KODU ='" + _stockCode + "' AND VARYASYON_KODU ='" + _variation + "'");
                    }
                    else
                    {
                        Data.commandQuery("DELETE FROM [dbo].[TBL_STOKSABIT] WHERE STOK_KODU ='" + _stockCode + "' AND VARYASYON_KODU ='" + _variation + "'");
                        Data.commandQuery("DELETE FROM [dbo].[TBL_STOKSABITEK] WHERE STOK_KODU = '" + _stockCode + "'");
                    }
                }
                else
                {
                    MessageBox.Show(@"Kann nicht gelöscht werden, ohne den Bestand auszuwählen.");
                }
            }
            catch (Exception)
            {

                throw;
            }
            Refresh_();
        }

        private void Refresh_()
        {
            _stockCode = null; _variation = 1; _stockName = null; _code1 = null; _groupCode = null; _storeCode = null; _description = null; _r1 = null; _b1 = null; _r2 = null; _b2 = null; _r3 = null; _b3 = null; _r4 = null; _b4 = null; _r5 = null; _b5 = null;
            _r6 = null; _b6 = null; _r7 = null; _b7 = null; _r8 = null; _b8 = null; _r9 = null; _b9 = null; _r10 = null; _b10 = null;

            _colorNumber = 0;
            //cb_renkadet.SelectedIndex = colorNumber;

            foreach (Control item in panelControl2.Controls)
            {
                if (item is TextEdit)
                {
                    TextEdit tbox = (TextEdit)item;
                    tbox.Text = null;
                }
            }


            foreach (Control item in panelControl3.Controls)
            {
                if (item is TextEdit)
                {
                    TextEdit tbox = (TextEdit)item;
                    tbox.Text = null;
                }
            }

            tb_stockcode.Text = _stockCode;
            tb_variationCode.Text = _variation.ToString();
            tb_stockName.Text = _stockName;
            tb_groupCode.Text = _groupCode;
            tb_description.Text = _description;
            tb_storeCode.Text = _storeCode;
            tb_code1.Text = _code1;
            //cb_renkadet.Text = colorNumber.ToString();

            pic_box1.Image = null;

            panelControl2.Visible = false;

            _stockTable.Clear();
            _stockTable = Data.fetchQuery("SELECT * FROM VW_STOKBILGI");
            grid_stocks.DataSource = _stockTable;
            btn_imageadd.Enabled = false;
            btn_imageremove.Enabled = false;
            xtraTabControl1.Visible = false;
        }

        public void movementRefresh()
        {
            _branchCode = null;
            _color = null;
            _size = null;
            _gckod = null;
            _description = null;
            trh = DateTime.Now;
            _zeroVariable = 0;
            _oneVariable = 1;
            _entryquantity = 0;
            _price = 0;

            tb_entryQuantity.Text = _entryquantity.ToString();
            tb_desciptionMove.Text = _description;
            cb_branch.Text = _branchCode;
            cb_color.Text = _color;
            cb_size.Text = _size;

            lb_brachName.Text = null;
            lb_color.Text = null;
            lb_size.Text = null;

            tb_entryQuantity.Text = _entryquantity.ToString();
            tb_price.Text = _price.ToString();


            trh = DateTime.Now;
            dt_date.Text = trh.ToShortDateString();

            //_stocksMovement.Clear();
            //_stocksMovement = Data.fetchQuery("SELECT SUBE_KOD, COLOR, SIZE, MIKTAR,dbo.FNC_STOK_YURUYEN_BAKIYE(ID,STOK_KODU,SUBE_KOD,'E') AS BAKIYE FROM TBL_STOKHAREKET WHERE STOK_KODU = '" + _stockCode + "' AND VARYASYON_KODU='" + _variation + "'");
            //grid_StockMotion.DataSource = _stocksMovement;
        }

        private void ImageRefresh()
        {
            _r1 = null; _b1 = null; _r2 = null; _b2 = null; _r3 = null; _b3 = null; _r4 = null; _b4 = null; _r5 = null; _b5 = null;
            _r6 = null; _b6 = null; _r7 = null; _b7 = null; _r8 = null; _b8 = null; _r9 = null; _b9 = null; _r10 = null; _b10 = null;

            foreach (Control item in panelControl2.Controls)
            {
                if (item is TextEdit)
                {
                    TextEdit tbox = (TextEdit)item;
                    tbox.Text = null;
                }
            }

        }

        private void FetchData(string a, int b)
        {
            DataTable StokBilgi = new DataTable();
            StokBilgi = Data.fetchQuery("SELECT * FROM VW_STOKBILGI WHERE STOK_KODU = '" + a + "' AND VARYASYON_KODU='" + b + "'");

            if (StokBilgi.Rows.Count != 0)
            {
                _id = Convert.ToInt32(StokBilgi.Rows[0]["ID"]);
                //id2 = Convert.ToInt32(StokBilgi.Rows[0]["ID2"]);
                _stockName = StokBilgi.Rows[0]["VARYASYON_ACIKLAMA"].ToString();
                _variation = Convert.ToInt32(StokBilgi.Rows[0]["VARYASYON_KODU"]);
                _description = StokBilgi.Rows[0]["ACIKLAMA"].ToString();
                _code1 = StokBilgi.Rows[0]["KOD_1"].ToString();
                _groupCode = StokBilgi.Rows[0]["GRUP_KODU"].ToString();
                _storeCode = StokBilgi.Rows[0]["DEPO_KODU"].ToString();
                _colorNumber = Convert.ToInt16(StokBilgi.Rows[0]["RENK_ADET"]);
                _r1 = StokBilgi.Rows[0]["RENK1"].ToString();
                _b1 = StokBilgi.Rows[0]["BOBIN1"].ToString();
                _r2 = StokBilgi.Rows[0]["RENK2"].ToString();
                _b2 = StokBilgi.Rows[0]["BOBIN2"].ToString();
                _r3 = StokBilgi.Rows[0]["RENK3"].ToString();
                _b3 = StokBilgi.Rows[0]["BOBIN3"].ToString();
                _r4 = StokBilgi.Rows[0]["RENK4"].ToString();
                _b4 = StokBilgi.Rows[0]["BOBIN4"].ToString();
                _r5 = StokBilgi.Rows[0]["RENK5"].ToString();
                _b5 = StokBilgi.Rows[0]["BOBIN5"].ToString();
                _r6 = StokBilgi.Rows[0]["RENK6"].ToString();
                _b6 = StokBilgi.Rows[0]["BOBIN6"].ToString();
                _r7 = StokBilgi.Rows[0]["RENK7"].ToString();
                _b7 = StokBilgi.Rows[0]["BOBIN7"].ToString();
                _r8 = StokBilgi.Rows[0]["RENK8"].ToString();
                _b8 = StokBilgi.Rows[0]["BOBIN8"].ToString();
                _r9 = StokBilgi.Rows[0]["RENK9"].ToString();
                _b9 = StokBilgi.Rows[0]["BOBIN9"].ToString();
                _r10 = StokBilgi.Rows[0]["RENK10"].ToString();
                _b10 = StokBilgi.Rows[0]["BOBIN10"].ToString();
                _groupCode2 = StokBilgi.Rows[0]["GRUP_KODU"].ToString();
                _k1 = StokBilgi.Rows[0]["KOD1"].ToString();
                _k2 = StokBilgi.Rows[0]["KOD2"].ToString();
                _k3 = StokBilgi.Rows[0]["KOD3"].ToString();
                _k4 = StokBilgi.Rows[0]["KOD4"].ToString();
                _k5 = StokBilgi.Rows[0]["KOD5"].ToString();

                tb_stockcode.Text = _stockCode;
                tb_stockName.Text = _stockName;
                tb_code1.Text = _code1;
                tb_variationCode.Text = _variation.ToString();
                tb_groupCode.Text = _groupCode;
                tb_description.Text = _description;
                tb_storeCode.Text = _storeCode;
                //cb_renkadet.Text = colorNumber.ToString();
                tb_renk1.Text = _r1;
                tb_bobin1.Text = _b1;
                tb_renk2.Text = _r2;
                tb_bobin2.Text = _b2;
                tb_renk3.Text = _r3;
                tb_bobin3.Text = _b3;
                tb_renk4.Text = _r4;
                tb_bobin4.Text = _b4;
                tb_renk5.Text = _r5;
                tb_bobin5.Text = _b5;
                tb_renk6.Text = _r6;
                tb_bobin6.Text = _b6;
                tb_renk7.Text = _r7;
                tb_bobin7.Text = _b7;
                tb_renk8.Text = _r8;
                tb_bobin8.Text = _b8;
                tb_renk9.Text = _r9;
                tb_bobin9.Text = _b9;
                tb_renk10.Text = _r10;
                tb_bobin10.Text = _b10;
            }
            else
            {
                MessageBox.Show("Error!");
            }

            _stocksMovement.Clear();
            _stocksMovement = Data.fetchQuery("SELECT *,dbo.FNC_STOK_YURUYEN_BAKIYE(ID,STOK_KODU,SUBE_KOD,'E') AS BAKIYE FROM TBL_STOKHAREKET WHERE STOK_KODU = '" + a + "' AND VARYASYON_KODU='" + b + "' ");
            grid_StockMotion.DataSource = _stocksMovement;

            GetImage(_stockCode, _variation);

        }

        private void GetImage(string sk, int a)
        {
            pic_box1.Image = null;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Data.sqlConnection();

                string SqlStr = "SELECT IMAGE1 FROM TBL_STOKRESIM WHERE STOK_KODU = '" + sk + "' AND VARYASYON_KODU = " + _variation + "";

                SqlCommand komut = new SqlCommand(SqlStr, con);

                SqlDataReader dr;

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                dr = komut.ExecuteReader();

                dr.Read();
                if (dr.HasRows)
                {
                    byte[] img = (byte[])(dr[0]);
                    if (img == null)
                    {
                        pic_box1.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pic_box1.Image = Image.FromStream(ms);
                        Bitmap drawBitmap;
                        drawBitmap = (Bitmap)pic_box1.Image;
                        drawBitmap.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                        pic_box1.Image = drawBitmap;
                    }
                }
                //else
                //{
                //    MessageBox.Show("Gösterilecek Öğe Yok");
                //}
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int StockCodeControl(string a)
        {
            int x = 0;

            DataTable dt = new DataTable();

            dt = Data.fetchQuery("SELECT COUNT(STOK_KODU) AS SAY FROM TBL_STOKSABITEK WHERE STOK_KODU = '" + a + "'");
            x = Convert.ToInt16(dt.Rows[0]["SAY"]);

            return x;
        }

        public int StockControl(int d)
        {
            DataTable say = new DataTable();
            int s;

            if (d == 0)
            {
                string a = _stockCode + _variation.ToString();
                say = Data.fetchQuery("SELECT COUNT(STOK_KODU) AS SAY FROM VW_STOKKODU_KONTROL WHERE STOK_KODU = '" + a + "'");
                s = Convert.ToInt32(say.Rows[0]["SAY"]);
            }
            else
            {
                say = Data.fetchQuery("SELECT COUNT(STOK_KODU) AS SAY FROM [VW_STSABITKONTROL] WHERE STOK_KODU = '" + _stockCode + "'");
                s = Convert.ToInt32(say.Rows[0]["SAY"]);
            }
            return s;
        }

        public void FetchDataToCombobox()
        {
            DataTable _branchTable;
            DataTable _colorTable;
            DataTable _sizeTable;

            _branchTable = Data.fetchQuery("SELECT * FROM TBL_SUBE");
            _colorTable = Data.fetchQuery("SELECT * FROM TBL_COLOR");
            _sizeTable = Data.fetchQuery("SELECT * FROM TBL_SIZE");

            cb_branch.Properties.Items.Clear();
            cb_color.Properties.Items.Clear();
            cb_size.Properties.Items.Clear();

            for (int i = 0; i < _colorTable.Rows.Count; i++)
            {
                cb_color.Properties.Items.Add(_colorTable.Rows[i]["COLOR"].ToString());
            }

            for (int i = 0; i < _sizeTable.Rows.Count; i++)
            {
                cb_size.Properties.Items.Add(_sizeTable.Rows[i]["SIZE"].ToString());
            }

            for (int i = 0; i < _branchTable.Rows.Count; i++)
            {
                cb_branch.Properties.Items.Add(_branchTable.Rows[i]["SUBE_KOD"].ToString());
            }
        }

        private void Form_Stocks_Load(object sender, EventArgs e)
        {
            _colorNumber = 0;
            panelControl2.Visible = false;
            _date = DateTime.Now;
            _variation = 1;
            tb_variationCode.Text = _variation.ToString();
            _colorNumber = 0;
            //cb_renkadet.Text = colorNumber.ToString();
            radioGroup1.SelectedIndex = 0;
            _gckod = "G";
            _zeroVariable = 0;
            _oneVariable = 1;

            _stockTable.Clear();
            _stockTable = Data.fetchQuery("SELECT * FROM VW_STOKBILGI");
            grid_stocks.DataSource = _stockTable;

            FetchDataToCombobox();
        }

        private void tb_stockcode_Leave(object sender, EventArgs e)
        {
            _stockCode = tb_stockcode.Text;

            if (StockCodeControl(_stockCode) != 0)
                FetchData(_stockCode, _variation);
        }

        private void tb_stockcode_TextChanged(object sender, EventArgs e)
        {
            grid_stockList.Visible = false;
            _search1 = tb_stockcode.Text;

            if (tb_stockcode.Text != "")
            {
                int satirsay = 0;
                grid_stockList.Visible = false;

                DAL q3 = new DAL();
                DataTable Dt2 = new DataTable();
                Dt2 = q3.fetchQuery("SELECT COUNT(STOK_KODU) AS SAY FROM TBL_STOKSABITEK WHERE STOK_KODU LIKE '" + _search1 + "%' AND STOK_ADI LIKE '%" + _search2 + "%'");
                satirsay = Convert.ToInt32(Dt2.Rows[0]["SAY"].ToString());
                Dt2.Clear();

                if (satirsay == 0)
                {
                    grid_stockList.Visible = false;
                }
                else
                {
                    grid_stockList.Visible = true;

                    DAL q4 = new DAL();
                    DataTable ttt = new DataTable();
                    ttt = q3.fetchQuery("SELECT TOP 25 STOK_KODU,VARYASYON_KODU,STOK_ADI FROM VW_STOKBILGI WHERE STOK_ADI LIKE '%" + _search2 + "%' AND STOK_KODU LIKE '" + _search1 + "%'");
                    grid_stockList.DataSource = ttt;
                }
            }
        }

        private void tb_variationCode_Leave(object sender, EventArgs e)
        {
            try
            {
                _variation = Convert.ToInt32(tb_variationCode.Text);
                grid_stockList.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tb_stockName_Leave(object sender, EventArgs e)
        {
            _stockName = tb_stockName.Text;
        }

        private void tb_stockName_TextChanged(object sender, EventArgs e)
        {
            grid_stockList.Visible = false;
            _search2 = tb_stockName.Text;

            if (tb_stockName.Text != "")
            {
                int satirsay = 0;
                DataTable ttt = new DataTable();
                DAL aaa = new DAL();
                grid_stockList.Visible = false;

                ttt = aaa.fetchQuery("SELECT COUNT(STOK_KODU) AS SAY FROM TBL_STOKSABITEK WHERE STOK_KODU LIKE '" + _search1 + "%' AND STOK_ADI LIKE '%" + _search2 + "%'");
                satirsay = Convert.ToInt32(ttt.Rows[0]["SAY"].ToString());
                ttt.Clear();

                if (satirsay == 0)
                {
                    grid_stockList.Visible = false;
                }
                else
                {
                    grid_stockList.Visible = true;
                    ttt.Clear();

                    ttt = aaa.fetchQuery("SELECT TOP 25 STOK_KODU,VARYASYON_KODU,STOK_ADI, KOD_1 FROM VW_STOKBILGI WHERE STOK_ADI LIKE '%" + _search2 + "%' AND STOK_KODU LIKE '" + _search1 + "%'");
                    grid_stockList.DataSource = ttt;
                }
            }
        }

        private void tb_code1_Leave(object sender, EventArgs e)
        {
            _code1 = tb_code1.Text;
        }

        private void tb_storeCode_Leave(object sender, EventArgs e)
        {
            _storeCode = tb_storeCode.Text;
        }

        private void tb_groupCode_Leave(object sender, EventArgs e)
        {
            _groupCode = tb_groupCode.Text;
        }

        private void tb_description_Leave(object sender, EventArgs e)
        {
            _description = tb_description.Text;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (StockControl(0) == 0)
            {
                if (_stockCode != null && _stockCode != "" && _stockName != null && _stockName != "")
                {
                    Save();
                }
                else
                {
                    MessageBox.Show(@"Bitte füllen Sie die Felder für Lagerbestand und Lagerbestand aus.");
                }
            }
            else
            {
                Edit();
            }

            Refresh_();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Refresh_();
            movementRefresh();
        }

        private void btn_imageadd_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(Data.sqlConnection());
            SqlCommand command;

            try
            {
                openFileDialog1.Title = "Wählen Sie Bild";
                openFileDialog1.Filter = "JPEG-Datei (*.jpg)|*.jpg|Gif-Datei (*.gif)|*.gif|Png-Datei (*.png)|*.png|Tif-Datei (*.tif)|*.tif";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pic_box1.Image = Image.FromFile(openFileDialog1.FileName);
                    _imagePath = openFileDialog1.FileName.ToString();
                }

                byte[] img = null;
                FileStream fs = new FileStream(_imagePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                img = br.ReadBytes((int)fs.Length);

                string cmd = "IF EXISTS (SELECT STOK_KODU FROM VW_STOKBILGI WHERE STOK_KODU = '" + _general.changeCharacter(_stockCode) + "' AND VARYASYON_KODU = '" + _variation + "' ) INSERT INTO TBL_STOKRESIM (STOK_KODU,VARYASYON_KODU,IMAGE1) VALUES('" + _stockCode + "','" + _variation + "',  @img)";

                if (SqlCon.State != ConnectionState.Open)
                    SqlCon.Open();

                command = new SqlCommand(cmd, SqlCon);
                command.Parameters.Add("@img", img);
                int x = command.ExecuteNonQuery();
                SqlCon.Close();

                Bitmap drawBitmap;
                drawBitmap = (Bitmap)pic_box1.Image;
                drawBitmap.RotateFlip(RotateFlipType.RotateNoneFlipNone);

                pic_box1.Image = drawBitmap;

                MessageBox.Show(x.ToString() + " Bild hinzugefügt.");

            }
            catch (Exception ex)
            {
                SqlCon.Close();
                MessageBox.Show(ex.Message, "Ausnahme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imageremove_Click(object sender, EventArgs e)
        {
            try
            {
                if (_stockCode != null || _stockCode != "")
                {
                    DataTable varmi = new DataTable();
                    varmi = Data.fetchQuery("SELECT * FROM TBL_STOKRESIM WHERE STOK_KODU = '" + _stockCode + "'");
                    if (varmi.Rows.Count > 0)
                    {
                        Data.commandQuery("DELETE FROM TBL_STOKRESIM WHERE STOK_KODU ='" + _stockCode + "'");
                        pic_box1.Image = null;
                    }
                    else
                    {
                        MessageBox.Show(@"Ausgewählter Bestand hat kein Bild.");
                    }
                }
                else
                {
                    MessageBox.Show(@"Kann nicht gelöscht werden, ohne den Bestand auszuwählen.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void grid_stocks_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr1 = null;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
                hi = gridView1.CalcHitInfo((grid_stocks as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0) dr1 = gridView1.GetDataRow(hi.RowHandle);
            else
            if (gridView1.FocusedRowHandle >= 0) dr1 = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            else dr1 = null;

            if (dr1 != null)
            {
                _stockCode = dr1["STOK_KODU"].ToString();
                _stokCodeMove = _stockCode;
                _variation = Convert.ToInt32(dr1["VARYASYON_KODU"]);
                _variationMove = _variation;
                _id = Convert.ToInt32(dr1["ID"]);
                // id2 = Convert.ToInt32(dr1["ID2"]); 
            }

            string a = _stockCode + _variation.ToString();

            FetchData(_stockCode, _variation);
            grid_stockList.Visible = false;
            btn_imageadd.Enabled = true;
            btn_imageremove.Enabled = true;
            xtraTabControl1.Visible = true;
        }

        private void grid_stockList_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr1 = null;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
                hi = gridView5.CalcHitInfo((grid_stockList as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0) dr1 = gridView5.GetDataRow(hi.RowHandle);
            else
            if (gridView5.FocusedRowHandle >= 0) dr1 = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            else dr1 = null;

            if (dr1 != null)
            {
                _stockCode = dr1["STOK_KODU"].ToString();
                _variation = Convert.ToInt32(dr1["VARYASYON_KODU"]);
                _code1 = dr1["KOD_1"].ToString();
            }
            string a = _stockCode + _variation.ToString();
            FetchData(_stockCode, _variation);
            grid_stockList.Visible = false;
        }

    }
}