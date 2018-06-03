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
using DevExpress.XtraLayout.Resizing;

namespace TrackingProducts
{
    public partial class Form_Sales : DevExpress.XtraEditors.XtraForm
    {
        string _currentCode, _currentName, _documentNo, _stockCode, _stockName, _type, _type2, _inputOutputCode, _gridControl, _documentTypeDescription, _groupCode, _color, _size;
        double _quantity, _price, _amount, _disocunt1, _discount2, _disocunt3, _discount4, _netPrice, _netAmount, _amountWithTax, _grossAmount, _discount, _subtotal, _kdv, _grandTotal;
        DateTime _date, _expiryDate, _deliveryDate;
        int _queue, _openingControl, _correctionCheck, _id, _variation;

        string _search1, _search2;

        GeneralClasses _general = new GeneralClasses();
        DAL _data = new DAL();
        DataTable _itemInfo = new DataTable();
        DataTable _table = new DataTable();

         DataRow _rowItem;
        private string _branchCode;
        private string _lbSize;
        private string _lbColor;
        private string _lbBrach;

        public Form_Sales()
        {
            InitializeComponent();
        }

        private void Opening()
        {
            if (_openingControl == 0)
            {
                _itemInfo.Columns.Add("STOK_KODU", typeof(string));
                _itemInfo.Columns.Add("VARYASYON_KODU", typeof(int));
                _itemInfo.Columns.Add("STOK_ADI", typeof(string));
                _itemInfo.Columns.Add("GRUP_KODU", typeof(string));
                _itemInfo.Columns.Add("FISNO", typeof(string));
                _itemInfo.Columns.Add("SUBE_KOD", typeof(string));
                _itemInfo.Columns.Add("COLOR", typeof(string));
                _itemInfo.Columns.Add("SIZE", typeof(string));
                _itemInfo.Columns.Add("MIKTAR", typeof(double));
                _itemInfo.Columns.Add("GC_KOD", typeof(string));
                _itemInfo.Columns.Add("TARIH", typeof(DateTime));
                _itemInfo.Columns.Add("TES_TARIH", typeof(DateTime));
                _itemInfo.Columns.Add("NET_FIYAT", typeof(double));
                _itemInfo.Columns.Add("BRUT_FIYAT", typeof(double));
                _itemInfo.Columns.Add("AMOUNT", typeof(double));
                _itemInfo.Columns.Add("KDV_ORAN", typeof(double));
                _itemInfo.Columns.Add("ACIKLAMA", typeof(string));
                _itemInfo.Columns.Add("ISK1", typeof(double));
                _itemInfo.Columns.Add("ISK2", typeof(double));
                _itemInfo.Columns.Add("ISK3", typeof(double));
                _itemInfo.Columns.Add("ISK4", typeof(double));
                _itemInfo.Columns.Add("FTIRSIP", typeof(string));
                _itemInfo.Columns.Add("HAR_TUR", typeof(string));
                _itemInfo.Columns.Add("BELGE_TIPI", typeof(string));
                _itemInfo.Columns.Add("CARI_KOD", typeof(string));
                _itemInfo.Columns.Add("SIRA", typeof(Int16));
            }
            else
            {
                _itemInfo.Clear();
            }

            rg_type.SelectedIndex = 0;
            _type = "S";

            rg_type2.SelectedIndex = 1;
            _type2 = "S";

            _documentNo = _general.DocumentNo(_type, _type2);

            _currentCode = null;
            _currentName = null;

            _stockCode = null;
            _stockName = null;

            _branchCode = null;
            _color = null;
            _size = null;

            _quantity = 0; _price = 0; _amount = 0; _disocunt1 = 0; _discount2 = 0; _disocunt3 = 0; _discount4 = 0; _netPrice = 0; _netAmount = 0; _amountWithTax = 0; _grossAmount = 0; _discount = 0; _subtotal = 0; _kdv = 0; _grandTotal = 0; _correctionCheck = 0;

            _gridControl = "Ok";
            tb_currentName.Text = _currentName;
            tb_documentNo.Text = _documentNo;
            tb_stockCode.Text = _stockCode;
            tb_stockName.Text = _stockName;

            cb_branch.Text = _branchCode;
            cb_color.Text = _color;
            cb_size.Text = _size;

            tb_quantity.Text = _quantity.ToString("N");
            tb_price.Text = _price.ToString("N");
            tb_amount.Text = _amount.ToString("N");
            tb_discount1.Text = _disocunt1.ToString("N");
            tb_discount2.Text = _discount2.ToString("N");
            tb_discount3.Text = _disocunt3.ToString("N");
            tb_discount4.Text = _discount4.ToString("N");
            tb_netPrice.Text = _netPrice.ToString("N");
            tb_netAmount.Text = _netAmount.ToString("N");
            tb_kdvdahilnettutar.Text = _amountWithTax.ToString("N");

            tb_grossAmount.Text = _grossAmount.ToString("N");
            tb_discount.Text = _discount.ToString("N");
            tb_subTotal.Text = _subtotal.ToString("N");
            tb_kdv.Text = _kdv.ToString("N");
            tb_grandTotal.Text = _grandTotal.ToString("N");

            _date = DateTime.Now;
            _deliveryDate = DateTime.Now;
            _expiryDate = DateTime.Now;

            dt_date.Text = _date.ToShortDateString();
            dt_deliveryDate.Text = _deliveryDate.ToShortDateString();
            dt_expiryDate.Text = _expiryDate.ToShortDateString();
        }

        private void Save()
        {
            try
            {
                DataTable _checkDocument = new DataTable();
                _checkDocument = _data.fetchQuery("SELECT COUNT(BELGE_NO) AS SAY FROM TBL_FATUIRS WHERE BELGE_NO = '" + _documentNo + "' ");

                if (_checkDocument.Rows.Count > 0)
                {
                    _data.commandQuery("DELETE FROM TBL_FATUIRS WHERE BELGE_NO = '" + _documentNo + "'");
                    _data.commandQuery("DELETE FROM TBL_CARIHAREKET WHERE BELGE_NO = '" + _documentNo + "'");
                    _data.commandQuery("DELETE FROM TBL_STOKHAREKET WHERE FISNO = '" + _documentNo + "'");
                }

                //FATURA ÜST BİLGİ KAYIT
                _data.commandQuery("INSERT INTO [dbo].[TBL_FATUIRS] ([FTIRSIP] ,[TIP] ,[BELGE_NO] ,[CARI_KOD] ,[TARIH] ,[VADE_TARIHI] , [BRUT_TUTAR] ,[SAT_ISKT] ,[KDV] ,[GENEL_TOPLAM]) VALUES ('" + _type2 + "', '" + _type + "', '" + _documentNo + "', '" + _currentCode + "', '" + _general.editDateFormat(_date, 0) + "','" + _general.editDateFormat(_expiryDate, 0) + "'," + _grossAmount.ToString().Replace(',', '.') + ", " + _discount.ToString().Replace(',', '.') + "," + _kdv.ToString().Replace(',', '.') + "," + _grandTotal.ToString().Replace(',', '.') + ")");

                //CARİ HAREKET KAYIT
                _data.commandQuery("INSERT INTO [dbo].[TBL_CARIHAREKET] ([CARI_KOD],[TARIH],[VADE_TARIHI],[BELGE_NO],[ACIKLAMA],[BORC],[ALACAK],[DOVIZ_TURU],[DOVIZ_TUTAR],[HAREKET_TURU]) VALUES ('" + _currentCode + "','" + _general.editDateFormat(_date, 0) + "','" + _general.editDateFormat(_expiryDate, 0) + "','" + _documentNo + "','" + _general.changeCharacter(_documentTypeDescription) + "', " + _grandTotal.ToString().Replace(",", ".") + ",0,0,0,'" + _type2 + "')");

                //STOK HAREKET KAYIT
                for (int i = 0; i < _itemInfo.Rows.Count; i++)
                {
                    DateTime trh, tstrh;
                    trh = Convert.ToDateTime(_itemInfo.Rows[i]["TARIH"]);
                    tstrh = Convert.ToDateTime(_itemInfo.Rows[i]["TES_TARIH"]);
                    _data.commandQuery("INSERT INTO [dbo].[TBL_STOKHAREKET]([STOK_KODU],[VARYASYON_KODU],[GC_KOD],[TARIH],[TES_TARIH],[FTIRSIP],[FISNO],[HAR_TUR],[SIPNO],[IRSNO],[ACIKLAMA],[CARI_KOD],[SUBE_KOD],[COLOR],[SIZE],[MIKTAR],[BRUT_FIYAT],[NET_FIYAT],[ISK1],[ISK2],[ISK3],[ISK4],[KDV_ORAN],[BELGE_TIPI],[SIRA]) VALUES('" + _itemInfo.Rows[i]["STOK_KODU"].ToString() + "','" + _itemInfo.Rows[i]["VARYASYON_KODU"].ToString() + "','" + _itemInfo.Rows[i]["GC_KOD"].ToString() + "','" + _general.editDateFormat(trh, 0) + "','" + _general.editDateFormat(tstrh, 0) + "','" + _itemInfo.Rows[i]["FTIRSIP"].ToString() + "','" + _itemInfo.Rows[i]["FISNO"].ToString() + "','" + _itemInfo.Rows[i]["HAR_TUR"].ToString() + "',NULL,NULL,'" + _itemInfo.Rows[i]["ACIKLAMA"].ToString() + "','" + _itemInfo.Rows[i]["CARI_KOD"].ToString() + "','" + _itemInfo.Rows[i]["SUBE_KOD"].ToString() + "','" + _itemInfo.Rows[i]["COLOR"].ToString() + "','" + _itemInfo.Rows[i]["SIZE"].ToString() + "'," + _itemInfo.Rows[i]["MIKTAR"].ToString().Replace(",", ".") + "," + _itemInfo.Rows[i]["BRUT_FIYAT"].ToString().Replace(",", ".") + "," + _itemInfo.Rows[i]["NET_FIYAT"].ToString().Replace(",", ".") + "," + _itemInfo.Rows[i]["ISK1"].ToString().Replace(",", ".") + "," + _itemInfo.Rows[i]["ISK2"].ToString().Replace(",", ".") + "," + _itemInfo.Rows[i]["ISK3"].ToString().Replace(",", ".") + " ," + _itemInfo.Rows[i]["ISK4"].ToString().Replace(",", ".") + "," + _itemInfo.Rows[i]["KDV_ORAN"].ToString().Replace(",", ".") + ",'" + _itemInfo.Rows[i]["BELGE_TIPI"].ToString() + "'," + _itemInfo.Rows[i]["SIRA"].ToString() + ")");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                MessageBox.Show(@"Die Aufnahme ist abgeschlossen.");
            }
        }

        private void RefreshPage()
        {
            _openingControl = 1;
            Opening();
        }

        private void btn_itemRefresh_Click(object sender, EventArgs e)
        {
            ItemRefresh();
        }

        private void Delete()
        {
            try
            {
                _data.commandQuery("DELETE FROM TBL_FATUIRS WHERE BELGE_NO = '" + _documentNo + "'");

                _data.commandQuery("DELETE FROM TBL_CARIHAREKET WHERE BELGE_NO = '" + _documentNo + "'");

                _data.commandQuery("DELETE FROM TBL_STOKHAREKET WHERE FISNO = '" + _documentNo + "'");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                MessageBox.Show(@"Das ausgewählte Dokument wurde gelöscht.");
            }
        }

        private void CalculateLineInformation()
        {
            _price = Convert.ToDouble(tb_price.Text);
            tb_price.Text = _price.ToString("N");
            _amount = _quantity * _price;
            tb_amount.Text = _amount.ToString("N");

            _netPrice = _price;
            _netPrice = _netPrice - ((_netPrice * _disocunt1) / 100);
            _netPrice = _netPrice - ((_netPrice * _discount2) / 100);
            _netPrice = _netPrice - ((_netPrice * _disocunt3) / 100);
            _netPrice = _netPrice - ((_netPrice * _discount4) / 100);

            tb_netPrice.Text = _netPrice.ToString("N");

            _netAmount = _netPrice * _quantity;
            tb_netAmount.Text = _netAmount.ToString("N");

            _amountWithTax = _netAmount * 1.08;

            tb_kdvdahilnettutar.Text = _amountWithTax.ToString("N");
        }

        private void CalculateSubInfo()
        {
            double btutar = 0, i1 = 0, i2 = 0, i3 = 0, i4 = 0, ntutar = 0, miktarhesap = 0;

            _grossAmount = 0;
            _discount = 0;
            _subtotal = 0;
            _kdv = 0;
            _grandTotal = 0;

            for (int i = 0; i < _itemInfo.Rows.Count; i++)
            {
                btutar = Convert.ToDouble(_itemInfo.Rows[i]["BRUT_FIYAT"].ToString());
                miktarhesap = Convert.ToDouble(_itemInfo.Rows[i]["MIKTAR"].ToString());
                i1 = Convert.ToDouble(_itemInfo.Rows[i]["ISK1"].ToString());
                i2 = Convert.ToDouble(_itemInfo.Rows[i]["ISK2"].ToString());
                i3 = Convert.ToDouble(_itemInfo.Rows[i]["ISK3"].ToString());
                i4 = Convert.ToDouble(_itemInfo.Rows[i]["ISK4"].ToString());

                btutar = btutar * miktarhesap;

                ntutar = btutar - (btutar * i1 / 100);
                ntutar = ntutar - (ntutar * i2 / 100);
                ntutar = ntutar - (ntutar * i3 / 100);
                ntutar = ntutar - (ntutar * i4 / 100);

                _grossAmount = _grossAmount + btutar;
                _discount = _discount + (btutar - ntutar);
            }

            _subtotal = _grossAmount - _discount;
            _kdv = _subtotal * 0 / 100;
            _grandTotal = _subtotal + _kdv;

            tb_grossAmount.Text = _grossAmount.ToString("N");
            tb_discount.Text = _discount.ToString("N");
            tb_subTotal.Text = _subtotal.ToString("N");
            tb_kdv.Text = _kdv.ToString("N");
            tb_grandTotal.Text = _grandTotal.ToString("N");
        }

        private void AddItem()
        {
            if (_correctionCheck == 1)
            {
                if (_gridControl == "Ok")
                {
                    _itemInfo.Rows.Remove(_itemInfo.Rows[_id]);
                    GridAddItem("New");
                }
                else
                {
                    _gridControl = "Ok";
                }
            }
            else
            {
                //if (_gridControl == "Ok")
                //{
                //    GridAddItem("New");
                //}
                //else
                //{
                //    _gridControl = "Ok";
                //}
                GridAddItem("New");
            }

            //tb_stockCode.Focus();
        }

        private void GridAddItem(string strParam)
        {
            if (tb_stockCode.Text == "" && strParam.Length == 0)
            {
                MessageBox.Show(@"Keine Artikel zum Hinzufügen!!");
            }
            else
            {
                _rowItem = _itemInfo.NewRow();

                _rowItem["STOK_KODU"] = _stockCode;
                _rowItem["VARYASYON_KODU"] = _variation;
                _rowItem["STOK_ADI"] = _stockName;
                _rowItem["FISNO"] = _documentNo;
                _rowItem["COLOR"] = _color;
                _rowItem["SUBE_KOD"] = _branchCode;
                _rowItem["SIZE"] = _size;
                _rowItem["MIKTAR"] = _quantity;
                _rowItem["GC_KOD"] = _inputOutputCode;
                _rowItem["TARIH"] = _date;
                _rowItem["TES_TARIH"] = _general.editDateFormat(_date, 0);
                _rowItem["NET_FIYAT"] = _netPrice;
                _rowItem["BRUT_FIYAT"] = _price;
                _rowItem["AMOUNT"] = _netAmount;
                _rowItem["KDV_ORAN"] = 0;
                _rowItem["ACIKLAMA"] = _currentCode;
                _rowItem["ISK1"] = _disocunt1;
                _rowItem["ISK2"] = _discount2;
                _rowItem["ISK3"] = _disocunt3;
                _rowItem["ISK4"] = _discount4;
                _rowItem["FTIRSIP"] = _type2;
                _rowItem["HAR_TUR"] = _type;
                _rowItem["BELGE_TIPI"] = _type2;
                _rowItem["SIRA"] = _itemInfo.Rows.Count + 1;
                _rowItem["CARI_KOD"] = _currentCode;


                if (_stockCode == null || _stockCode == "" || _currentCode == null || _currentCode == "" )
                {

                    _rowItem.ClearErrors();
                    MessageBox.Show("Bitte überprüfen Sie den Lagerbestand oder den aktuellen Stand und versuchen Sie es später erneut.");
                }
                else
                {
                    _itemInfo.Rows.Add(_rowItem);
                }
                
            }

            CalculateSubInfo();
            ItemRefresh();
            _gridControl = "No";
            grid_items.DataSource = _itemInfo;
        }

        private void ItemRefresh()
        {
            _quantity = 0; _price = 0; _amount = 0; _disocunt1 = 0; _discount2 = 0; _disocunt3 = 0; _discount4 = 0; _netPrice = 0; _netAmount = 0; _amountWithTax = 0;
            _stockCode = null;
            _stockName = null;
            _branchCode = null;
            _color = null;
            _size = null;
            _lbBrach = null;
            _lbColor = null;
            _lbSize = null;

            cb_branch.Text = _branchCode;
            cb_color.Text = _color;
            cb_size.Text = _size;
            lb_brachName.Text = _lbBrach;
            lb_color.Text = _lbColor;
            lb_size.Text = _lbSize;
            cb_color.Text = _color;
            cb_size.Text = _size;

            tb_stockCode.Text = _stockCode;
            tb_stockName.Text = _stockName;

            tb_quantity.Text = _quantity.ToString("N");
            tb_price.Text = _price.ToString("N");
            tb_amount.Text = _amount.ToString("N");
            tb_discount1.Text = _disocunt1.ToString("N");
            tb_discount2.Text = _discount2.ToString("N");
            tb_discount3.Text = _disocunt3.ToString("N");
            tb_discount4.Text = _discount4.ToString("N");

            tb_netPrice.Text = _netPrice.ToString("N");
            tb_netAmount.Text = _netAmount.ToString("N");
            tb_kdvdahilnettutar.Text = _amountWithTax.ToString("N");
        }

        public void FetchDataToCombobox()
        {
            DataTable _branchTable;
            DataTable _colorTable;
            DataTable _sizeTable;

            _branchTable = _data.fetchQuery("SELECT * FROM TBL_SUBE");
            _colorTable = _data.fetchQuery("SELECT * FROM TBL_COLOR");
            _sizeTable = _data.fetchQuery("SELECT * FROM TBL_SIZE");

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

        private void Form_Sales_Load(object sender, EventArgs e)
        {
            _openingControl = 0;
            Opening();
            FetchDataToCombobox();
        }

        private void rg_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rg_type.SelectedIndex == 0)
            {
                _type = "S";
                _inputOutputCode = "C";
            }
            else if (rg_type.SelectedIndex == 1)
            {
                _type = "A";
                _inputOutputCode = "G";
            }
        }

        private void rg_type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rg_type2.SelectedIndex == 0)
            {
                _type2 = "T";
                _documentTypeDescription = "TEKLİF";
            }
            else if (rg_type2.SelectedIndex == 1)
            {
                _type2 = "S";
                _documentTypeDescription = "SİPARİŞ";
            }
            else if (rg_type2.SelectedIndex == 2)
            {
                _type2 = "I";
                _documentTypeDescription = "İRSALİYE";
            }
            else if (rg_type2.SelectedIndex == 3)
            {
                _type2 = "F";
                _documentTypeDescription = "FATURA";
            }
        }

        private void dt_date_EditValueChanged(object sender, EventArgs e)
        {
            _date = Convert.ToDateTime(dt_date.EditValue);
            dt_date.Text = _date.ToShortDateString();
        }

        private void tb_documentNo_Leave(object sender, EventArgs e)
        {
            _documentNo = tb_documentNo.Text;
        }

        private void dt_deliveryDate_EditValueChanged(object sender, EventArgs e)
        {
            _deliveryDate = Convert.ToDateTime(dt_deliveryDate.EditValue);
            dt_deliveryDate.Text = _deliveryDate.ToShortDateString();
        }

        private void tb_currentName_TextChanged(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            int lineCount = 0;

            if (tb_currentName.Text == "")
            {
                grid_currentSearch.Visible = false;
            }
            else
            {
                Table = _data.fetchQuery("SELECT COUNT(CARI_KOD) AS SAY FROM TBL_CARISABIT WHERE CARI_ISIM LIKE '%" + _general.changeCharacter(tb_currentName.Text) + "%'");
                lineCount = Table.Rows.Count;

                if (lineCount == 0)
                {
                    grid_currentSearch.Visible = false;
                }
                else
                {
                    grid_currentSearch.Location = new Point(1234, 35);
                    grid_currentSearch.Size = new Size(650, 150);
                    grid_currentSearch.Visible = true;

                    Table.Clear();

                    Table = _data.fetchQuery("SELECT TOP 25 CARI_KOD,CARI_ISIM FROM TBL_CARISABIT WHERE CARI_ISIM LIKE '%" + _general.changeCharacter(tb_currentName.Text) + "%'");

                    grid_currentSearch.DataSource = Table;
                }
            }
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

            tb_currentName.Text = _currentName;
            grid_currentSearch.Visible = false;
        }

        private void tb_stockCode_TextChanged(object sender, EventArgs e)
        {
            grid_stockGuide.Visible = false;
            _search1 = tb_stockCode.Text;

            if (tb_stockCode.Text != "")
            {
                int satirsay = 0;
                grid_stockGuide.Visible = false;

                DAL q3 = new DAL();
                DataTable Dt2 = new DataTable();
                Dt2 = q3.fetchQuery("SELECT COUNT(STOK_KODU) AS SAY FROM VW_STOKBILGI WHERE STOK_KODU LIKE '" + _search1 + "%' AND VARYASYON_ACIKLAMA LIKE '%" + _search2 + "%'");
                satirsay = Convert.ToInt32(Dt2.Rows[0]["SAY"].ToString());
                Dt2.Clear();

                if (satirsay == 0)
                {
                    grid_stockGuide.Visible = false;
                }
                else
                {
                    grid_stockGuide.Location = new Point(6, 60);
                    grid_stockGuide.Size = new Size(650, 150);
                    grid_stockGuide.Visible = true;
                    grid_stockGuide.Visible = true;

                    DAL q4 = new DAL();
                    DataTable ttt = new DataTable();
                    ttt = q3.fetchQuery("SELECT TOP 25 STOK_KODU,VARYASYON_KODU,VARYASYON_ACIKLAMA,GRUP_KODU FROM VW_STOKBILGI WHERE VARYASYON_ACIKLAMA LIKE '%" + _search2 + "%' AND STOK_KODU LIKE '" + _search1 + "%'");
                    grid_stockGuide.DataSource = ttt;
                }
            }
        }

        private void tb_stockName_TextChanged(object sender, EventArgs e)
        {
            grid_stockGuide.Visible = false;
            _search2 = tb_stockName.Text;

            if (tb_stockName.Text != "")
            {
                int lineCount = 0;
                DataTable Table = new DataTable();
                DAL aaa = new DAL();
                grid_stockGuide.Visible = false;

                Table = aaa.fetchQuery("SELECT COUNT(STOK_KODU) AS SAY FROM VW_STOKBILGI WHERE STOK_KODU LIKE '" + _search1 + "%' AND VARYASYON_ACIKLAMA LIKE '%" + _search2 + "%'");
                lineCount = Convert.ToInt32(Table.Rows[0]["SAY"].ToString());
                Table.Clear();

                if (lineCount == 0)
                {
                    grid_stockGuide.Visible = false;
                }
                else
                {
                    grid_stockGuide.Visible = true;
                    Table.Clear();

                    Table = aaa.fetchQuery("SELECT TOP 25 STOK_KODU,VARYASYON_KODU,VARYASYON_ACIKLAMA,GRUP_KODU FROM VW_STOKBILGI WHERE VARYASYON_ACIKLAMA LIKE '%" + _search2 + "%' AND STOK_KODU LIKE '" + _search1 + "%'");
                    grid_stockGuide.DataSource = Table;
                }
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

                _branchControl = _data.fetchQuery("SELECT COUNT(SUBE_KOD) AS SAY FROM TBL_SUBE WHERE SUBE_KOD = '" + _branchCode + "' ");
                control = Convert.ToInt32(_branchControl.Rows[0]["SAY"].ToString());

                if (control != 0)
                {
                    _branchTable = _data.fetchQuery("SELECT SUBE_AD FROM TBL_SUBE WHERE SUBE_KOD = '" + _branchCode + "' ");

                    _lbBrach = _branchTable.Rows[0]["SUBE_AD"].ToString();
                    lb_brachName.Text = _lbBrach;
                }
                else
                {
                    lb_brachName.Text = null;
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

                _branchControl = _data.fetchQuery("SELECT COUNT(COLOR) AS SAY FROM TBL_COLOR WHERE COLOR = '" + _color + "' ");
                control = Convert.ToInt32(_branchControl.Rows[0]["SAY"].ToString());

                if (control != 0)
                {
                    _branchTable = _data.fetchQuery("SELECT COLOR FROM TBL_COLOR WHERE COLOR = '" + _color + "' ");

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

        private void cb_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            _size = cb_size.Text;

            try
            {
                DataTable _branchTable;
                DataTable _branchControl;
                int control = 0;

                _branchControl = _data.fetchQuery("SELECT COUNT(SIZE) AS SAY FROM TBL_SIZE WHERE SIZE = '" + _size + "' ");
                control = Convert.ToInt32(_branchControl.Rows[0]["SAY"].ToString());

                if (control != 0)
                {
                    _branchTable = _data.fetchQuery("SELECT SIZE FROM TBL_SIZE WHERE SIZE = '" + _size + "' ");

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

        private void tb_quantity_Leave(object sender, EventArgs e)
        {
            _quantity = Convert.ToDouble(tb_quantity.Text);
        }

        private void tb_price_Leave(object sender, EventArgs e)
        {
            if (tb_price.Text == "" || tb_price.Text == null)
            {
                _price = 0;
            }
            else
            {
                _price = Convert.ToDouble(tb_price.Text);
                CalculateLineInformation();
            }
        }

        private void grid_items_DoubleClick(object sender, EventArgs e)
        {
            _correctionCheck = 1;
            _id = gridView1.FocusedRowHandle;
            DataRow dr1 = null;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
            hi = gridView1.CalcHitInfo((grid_items as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0) dr1 = gridView1.GetDataRow(hi.RowHandle);
            else
                if (gridView1.FocusedRowHandle >= 0)
            {
                dr1 = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            }
            else dr1 = null;

            if (dr1 != null)
            {
                _queue = Convert.ToInt32(dr1["SIRA"].ToString());
                _stockCode = dr1["STOK_KODU"].ToString();
                _stockName = dr1["STOK_ADI"].ToString();
                _branchCode = dr1["SUBE_KOD"].ToString();
                _color = dr1["COLOR"].ToString();
                _size = dr1["SIZE"].ToString();
                _quantity = Convert.ToDouble(dr1["MIKTAR"].ToString());
                _price = Convert.ToDouble(dr1["NET_FIYAT"].ToString());
                _disocunt1 = Convert.ToDouble(dr1["ISK1"].ToString());
                _discount2 = Convert.ToDouble(dr1["ISK2"].ToString());
                _disocunt3 = Convert.ToDouble(dr1["ISK3"].ToString());
                _discount4 = Convert.ToDouble(dr1["ISK4"].ToString());
            }

            tb_stockCode.Text = _stockCode;
            tb_stockName.Text = _stockName;
            cb_branch.Text = _branchCode;
            cb_color.Text = _color;
            cb_size.Text = _size;
            tb_quantity.Text = _quantity.ToString();
            tb_price.Text = _price.ToString("N");
            tb_discount1.Text = _disocunt1.ToString("N");
            tb_discount2.Text = _discount2.ToString("N");
            tb_discount3.Text = _disocunt3.ToString("N");
            tb_discount4.Text = _discount4.ToString("N");

            CalculateLineInformation();
            CalculateSubInfo();

            grid_stockGuide.Visible = false;
        }

        private void btn_addItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void grid_stockGuide_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr1 = null;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
            hi = gridView5.CalcHitInfo((grid_stockGuide as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0) dr1 = gridView5.GetDataRow(hi.RowHandle);
            else
                if (gridView5.FocusedRowHandle >= 0) dr1 = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            else dr1 = null;

            if (dr1 != null)
            {
                _stockCode = dr1["STOK_KODU"].ToString();
                _stockName = dr1["VARYASYON_ACIKLAMA"].ToString();
                _variation = Convert.ToInt32(dr1["VARYASYON_KODU"]);
                _groupCode = dr1["GRUP_KODU"].ToString();
            }

            tb_stockCode.Text = _stockCode;
            tb_stockName.Text = _stockName;

            grid_stockGuide.Visible = false;
        }

        private void tb_discount1_Leave(object sender, EventArgs e)
        {
            _disocunt1 = Convert.ToDouble(tb_discount1.Text);
            CalculateLineInformation();
        }

        private void tb_discount2_Leave(object sender, EventArgs e)
        {
            _discount2 = Convert.ToDouble(tb_discount2.Text);
            CalculateLineInformation();
        }

        private void tb_discount3_Leave(object sender, EventArgs e)
        {
            _disocunt3 = Convert.ToDouble(tb_discount3.Text);
            CalculateLineInformation();
        }

        private void tb_discount4_Leave(object sender, EventArgs e)
        {
            _discount4 = Convert.ToDouble(tb_discount4.Text);
            CalculateLineInformation();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();
            RefreshPage();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Delete();
            RefreshPage();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshPage();
            _table.Clear();
        }

        private void tb_documentNo_DoubleClick(object sender, EventArgs e)
        {
            Form_DocumentGuide frm = new Form_DocumentGuide();
            frm.ShowDialog();
            _documentNo = Form_DocumentGuide.DocumentNo;

            if (_documentNo == null || _documentNo == "")
            {
                RefreshPage();
            }
            else
            {
                _table = _data.fetchQuery("SELECT * FROM VW_BELGE WHERE BELGE_NO = '" + _documentNo + "' ");

                _currentCode = _table.Rows[0]["CARI_KOD"].ToString();
                _currentName = _table.Rows[0]["CARI_ISIM"].ToString();
                _documentNo = _table.Rows[0]["BELGE_NO"].ToString();
                _date = Convert.ToDateTime(_table.Rows[0]["TARIH"]);

                _expiryDate = Convert.ToDateTime(_table.Rows[0]["VADE_TARIHI"]);

                tb_currentName.Text = _currentName;
                grid_currentSearch.Visible = false;
                tb_documentNo.Text = _documentNo;
                dt_date.Text = _date.ToString();
                dt_deliveryDate.Text = _expiryDate.ToString();

                _itemInfo.Clear();
                _itemInfo = _data.fetchQuery("SELECT A.* , B.STOK_ADI, MIKTAR*NET_FIYAT AS AMOUNT  FROM TBL_STOKHAREKET A LEFT OUTER JOIN TBL_STOKSABITEK B ON A.STOK_KODU = B.STOK_KODU WHERE FISNO = '" + _documentNo + "' ");

                CalculateSubInfo();

                grid_items.DataSource = _itemInfo;
                frm.Visible = false;
                grid_items.Visible = true;

            }

        }
    }
}