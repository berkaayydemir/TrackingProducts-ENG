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
    public partial class Form_Current : DevExpress.XtraEditors.XtraForm
    {
        DAL Data = new DAL();
        GeneralClasses General = new GeneralClasses();
        DataTable _currentTable = new DataTable();
        DataTable _currentMovement = new DataTable();
        DataTable _list = new DataTable();
        DataTable _controlCurrent = new DataTable();

        string _currentCode = null, _currentName = null, _address = null, _province = null, _district = null, _taxOffice = null, _taxNo = null, _idNo = null, _phone = null, _telephone = null, _fax = null, _authorized = null, _email = null, _description = null, _type = null, _type2 = null;

        string _documentNo = null, _descriptionMove = null, _typeMove = null;
        DateTime _date, _maturityDate;
        double _amountMove, _payerMove, _payeeMove;

        int _id;

        int _lineCount = 0;

        public Form_Current()
        {
            InitializeComponent();
        }

        private void Save()
        {
            try
            {
                if (_currentCode != null)
                {
                    Data.commandQuery("IF NOT EXISTS (SELECT * FROM [TBL_CARISABIT] WHERE CARI_KOD='" + _currentCode + "') "
               + "INSERT INTO [dbo].[TBL_CARISABIT]([CARI_KOD],[CARI_ISIM],[ADRES],[IL],[ILCE],[TEL],[FAKS],[GSM],[VERGIDAIRESI],[VERGINUMARASI],[TCKIMLIKNO],[YETKILI],[EMAIL],[ACIKLAMA],[CARI_TIP],[CARI_TIP2])" + "VALUES('" + _currentCode + "','" + _currentName + "','" + _address + "','" + _province + "','" + _district + "','" + _phone + "','" + _fax + "','" + _telephone + "','" + _taxOffice + "','" + _taxNo + "','" + _idNo + "','" + _authorized + "','" + _email + "','" + _description + "','" + _type + "','" + _type2 + "') ELSE UPDATE [TBL_CARISABIT] SET [CARI_ISIM] = '" + _currentName + "',[ADRES] = '" + _address + "',[IL] = '" + _province + "',[ILCE] = '" + _district + "',[TEL] = '" + _phone + "',[FAKS] = '" + _fax + "',[GSM] = '" + _telephone + "',[VERGIDAIRESI] = '" + _taxOffice + "',[VERGINUMARASI] = '" + _taxNo + "',[TCKIMLIKNO] = '" + _idNo + "',[YETKILI] = '" + _authorized + "',[EMAIL] = '" + _email + "',[ACIKLAMA] = '" + _description + "',[CARI_TIP] = '" + _type + "',[CARI_TIP2] = '" + _type2 + "' WHERE CARI_KOD = '" + General.changeCharacter(_currentCode) + "' ");

                    _currentTable = Data.fetchQuery("SELECT * FROM TBL_CARISABIT");
                    grid_current.DataSource = _currentTable;
                }

                else
                {
                    MessageBox.Show("Der kunden Code darf nicht leer sein!");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Delete(string ck)
        {
            try
            {
                if (ck != null)
                {
                    DataTable CariSil = new DataTable();
                    CariSil = Data.fetchQuery("SELECT COUNT(CARI_KOD) AS SAY FROM TBL_CARIHAREKET WHERE CARI_KOD = '" + ck + "'");

                    int rowcount = Convert.ToInt32(CariSil.Rows[0]["SAY"]);

                    if (rowcount > 0)
                    {
                        MessageBox.Show("Current cannot be deleted from the current list. Please check previous operations and delete motion.");
                    }
                    else
                    {
                        Data.commandQuery("DELETE FROM [TBL_CARISABIT] WHERE CARI_KOD='" + ck + "'");
                        _currentTable = Data.fetchQuery("SELECT * FROM TBL_CARISABIT");
                        grid_current.DataSource = _currentTable;
                    }
                }
                else
                {
                    MessageBox.Show("Der kunden Code darf nicht leer sein!");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            Refresh_();
            _currentMovement.Clear();
            RefreshMove();
        }

        private void Refresh_()
        {
            _currentCode = null; _currentName = null; _address = null; _province = null; _district = null; _taxOffice = null; _taxNo = null; _idNo = null; _phone = null; _telephone = null; _fax = null; _authorized = null; _email = null; _description = null; _type = null; _type2 = null;

            tb_currentCode.Text = _currentCode;
            tb_currentName.Text = _currentName;
            tb_address.Text = _address;
            tb_province.Text = _province;
            tb_district.Text = _district;
            tb_taxOffice.Text = _taxOffice;
            tb_taxNumber.Text = _taxNo;
            tb_idNumber.Text = _idNo;
            tb_phone.Text = _phone;
            tb_telephone.Text = _telephone;
            tb_fax.Text = _fax;
            tb_authorized.Text = _authorized;
            tb_eMail.Text = _email;
            tb_description.Text = _description;

            rg_type.SelectedIndex = 0;
            rg_type2.SelectedIndex = 0;

            _type = "A";
            _type2 = "K";

            _currentMovement.Clear();
            tb_currentCode.Enabled = true;
        }

        private void SaveMove()
        {
            try
            {
                Data.commandQuery("INSERT INTO [dbo].[TBL_CARIHAREKET] ([CARI_KOD],[TARIH],[VADE_TARIHI],[BELGE_NO],[ACIKLAMA],[BORC],[ALACAK],[DOVIZ_TURU],[DOVIZ_TUTAR],[HAREKET_TURU]) VALUES ('" + _currentCode + "','" + General.editDateFormat(_date, 0) + "','" + General.editDateFormat(_maturityDate, 0) + "','" + _documentNo + "','" + General.changeCharacter(_descriptionMove) + "', " + _payerMove.ToString().Replace(",", ".") + "," + _payeeMove.ToString().Replace(",", ".") + ",0,0,'" + "A" + "')");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void RefreshMove()
        {
            _documentNo = null; _descriptionMove = null; rg_amounttypeMOVE.SelectedIndex = 0; _typeMove = "B"; _date = DateTime.Now; _maturityDate = DateTime.Now; _amountMove = 0; _payerMove = 0; _payeeMove = 0;

            tb_documentNoMOVE.Text = _documentNo;
            tb_descriptionMOVE.Text = _descriptionMove;
            dt_dateMOVE.Text = _date.ToShortDateString();
            dt_maturityDatemMOVE.Text = _maturityDate.ToShortDateString();
            tb_amountMOVE.Text = _amountMove.ToString("N");

            _currentMovement.Clear();
        }

        private void FetchData(string ck)
        {
            DataTable _dataTable;

            _dataTable = Data.fetchQuery("SELECT * FROM TBL_CARISABIT WHERE CARI_KOD = '" + ck + "'");

            if (_dataTable.Rows.Count != 0)
            {
                _currentName = _dataTable.Rows[0]["CARI_ISIM"].ToString();
                _address = _dataTable.Rows[0]["ADRES"].ToString();
                _province = _dataTable.Rows[0]["IL"].ToString();
                _district = _dataTable.Rows[0]["ILCE"].ToString();
                _taxOffice = _dataTable.Rows[0]["VERGIDAIRESI"].ToString();
                _taxNo = _dataTable.Rows[0]["VERGINUMARASI"].ToString();
                _idNo = _dataTable.Rows[0]["TCKIMLIKNO"].ToString();
                _phone = _dataTable.Rows[0]["TEL"].ToString();
                _telephone = _dataTable.Rows[0]["GSM"].ToString();
                _fax = _dataTable.Rows[0]["FAKS"].ToString();
                _authorized = _dataTable.Rows[0]["YETKILI"].ToString();
                _email = _dataTable.Rows[0]["EMAIL"].ToString();
                _description = _dataTable.Rows[0]["ACIKLAMA"].ToString();
                _type = _dataTable.Rows[0]["CARI_TIP"].ToString();
                _type2 = _dataTable.Rows[0]["CARI_TIP2"].ToString();

                tb_currentCode.Text = ck;
                tb_currentName.Text = _currentName;
                tb_address.Text = _address;
                tb_province.Text = _province;
                tb_district.Text = _district;
                tb_taxOffice.Text = _taxOffice;
                tb_taxNumber.Text = _taxNo;
                tb_idNumber.Text = _idNo;
                tb_phone.Text = _phone;
                tb_telephone.Text = _telephone;
                tb_fax.Text = _fax;
                tb_authorized.Text = _authorized;
                tb_eMail.Text = _email;
                tb_description.Text = _description;

                if (_type == "A")
                    rg_type.SelectedIndex = 0;

                else if (_type == "S")
                    rg_type.SelectedIndex = 1;

                else if (_type == "D")
                    rg_type.SelectedIndex = 2;


                if (_type2 == "K")
                    rg_type2.SelectedIndex = 0;

                else if (_type2 == "A")
                    rg_type2.SelectedIndex = 1;

                else if (_type2 == "D")
                    rg_type2.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("Sie haben keine Kunden ausgewählt!");
            }

            _currentMovement.Clear();
            _currentMovement = Data.fetchQuery("SELECT ID, CARI_KOD,HARK_TARH,BELGE_NO,VADE_TARIHI,ACIKLAMA,CARI_BORC,CARI_ALCK,CARI_BAKY,HAREKET_TURU FROM VW_CARI_HAREKET WHERE CARI_KOD = '" + _currentCode + "'");
            grid_currentMovement.DataSource = _currentMovement;

        }

        private void FetchDataMove(string ck, int s)
        {
            DataTable carihar = new DataTable();

            carihar = Data.fetchQuery("SELECT * FROM TBL_CARIHAREKET WHERE CARI_KOD = '" + ck + "' AND ID = '" + s + "'");

            _documentNo = carihar.Rows[0]["BELGE_NO"].ToString();
            _descriptionMove = carihar.Rows[0]["ACIKLAMA"].ToString();
            _date = Convert.ToDateTime(carihar.Rows[0]["TARIH"]);
            _maturityDate = Convert.ToDateTime(carihar.Rows[0]["VADE_TARIHI"]);
            _payerMove = Convert.ToDouble(carihar.Rows[0]["BORC"]);
            _payeeMove = Convert.ToDouble(carihar.Rows[0]["ALACAK"]);

            if (_payerMove > 0)
            {
                rg_amounttypeMOVE.SelectedIndex = 0;
                _amountMove = _payerMove;
            }
            else
            {
                rg_amounttypeMOVE.SelectedIndex = 1;
                _amountMove = _payeeMove;
            }

            dt_dateMOVE.Text = _date.ToShortDateString();
            dt_maturityDatemMOVE.Text = _date.ToShortDateString();
            tb_documentNoMOVE.Text = _documentNo;
            tb_descriptionMOVE.Text = General.readCharacter(_descriptionMove);
            tb_amountMOVE.Text = _amountMove.ToString("N");

        }

        private void Form_Current_Load(object sender, EventArgs e)
        {
            _currentTable = Data.fetchQuery("SELECT CARI_KOD, CARI_ISIM FROM TBL_CARISABIT");
            grid_current.DataSource = _currentTable;

            _typeMove = "B";
        }

        private void tb_currentCode_Leave(object sender, EventArgs e)
        {
            int satirsay = 0;
            _currentCode = tb_currentCode.Text;

            _controlCurrent =
                Data.fetchQuery("SELECT COUNT(CARI_KOD) AS SAY FROM [dbo].[TBL_CARISABIT] WHERE CARI_KOD = '" +
                                General.changeCharacter(_currentCode) + "'");
            satirsay = Convert.ToInt32(_controlCurrent.Rows[0]["SAY"]);

            if (satirsay == 1)
            {
                MessageBox.Show("Dieser aktuelle Code wird verwendet. Bitte geben Sie einen neuen Code an.");
                Refresh_();
            }

            if (_currentCode == "") _currentCode = null;

        }

        private void tb_currentCode_TextChanged(object sender, EventArgs e)
        {
            //carikodbul();
        }

        private void tb_currentName_Leave(object sender, EventArgs e)
        {
            _currentName = tb_currentName.Text;

            if (_currentName == "") _currentName = null;

        }

        private void tb_currentName_TextChanged(object sender, EventArgs e)
        {
            string a = tb_currentName.Text;
            DataTable Cari = new DataTable();

            if (a == "" || a == null)
            {
            }
            else
            {
                Cari = Data.fetchQuery(
                    "SELECT COUNT(CARI_KOD) AS SAY FROM TBL_CARISABIT WHERE CARI_ISIM LIKE '%" +
                    General.changeCharacter(a) + "%'");
                _lineCount = Convert.ToInt32(Cari.Rows[0]["SAY"]);

                if (_lineCount == 0)
                {
                }
                else
                {

                    Cari.Clear();

                    Cari = Data.fetchQuery(
                        "SELECT TOP 25 CARI_KOD,CARI_ISIM FROM TBL_CARISABIT WHERE CARI_ISIM LIKE '%" +
                        General.changeCharacter(a) + "%'");


                }
            }
        }

        private void tb_currentName_Click(object sender, EventArgs e)
        {
            //cariisimbul();
        }

        private void tb_address_Leave(object sender, EventArgs e)
        {
            _address = tb_address.Text;
        }

        private void tb_province_Leave(object sender, EventArgs e)
        {
            _province = tb_province.Text;
        }

        private void tb_district_Leave(object sender, EventArgs e)
        {
            _district = tb_district.Text;
        }

        private void tb_phone_Leave(object sender, EventArgs e)
        {
            _phone = tb_phone.Text;
        }

        private void tb_telephone_Leave(object sender, EventArgs e)
        {
            _telephone = tb_telephone.Text;
        }

        private void tb_fax_Leave(object sender, EventArgs e)
        {
            _fax = tb_fax.Text;
        }

        private void tb_idNumber_Leave(object sender, EventArgs e)
        {
            _idNo = tb_idNumber.Text;
        }

        private void tb_taxOffice_Leave(object sender, EventArgs e)
        {
            _taxOffice = tb_taxOffice.Text;
        }

        private void tb_taxNumber_Leave(object sender, EventArgs e)
        {
            _taxNo = tb_taxNumber.Text.Replace(" ", "");
        }

        private void tb_authorized_Leave(object sender, EventArgs e)
        {
            _authorized = tb_authorized.Text;
        }

        private void sendAsExcelForCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Kunden Transaktion Reporter(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")";
            save.Filter = "Excel-Arbeitsmappe |*.xls";
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (save.ShowDialog() == DialogResult.OK) //Pencerede kayıt düğmesine basıldıysa
            {
                grid_current.ExportToXls(save.FileName);
            }

            if (MessageBox.Show("Öffnen Sie die exportierte Datei?", "Excel-Datei", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Kaydedilen Excel Dosyasını açar.
                System.Diagnostics.Process.Start(save.FileName);
            }
        }

        private void tb_eMail_Leave(object sender, EventArgs e)
        {
            _email = tb_eMail.Text;
        }

        private void tb_description_Leave(object sender, EventArgs e)
        {
            _description = tb_description.Text;
        }

        private void rg_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rg_type.SelectedIndex == 0)
                _type = "A";
            else if (rg_type.SelectedIndex == 1)
                _type = "S";
            else if (rg_type.SelectedIndex == 2)
                _type = "D";
        }

        private void rg_type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rg_type2.SelectedIndex == 0)
                _type2 = "K";
            else if (rg_type2.SelectedIndex == 1)
                _type2 = "A";
            else if (rg_type2.SelectedIndex == 2)
                _type2 = "D";
        }

        private void grid_current_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr1 = null;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
                hi = gridView1.CalcHitInfo((grid_current as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0) dr1 = gridView1.GetDataRow(hi.RowHandle);
            else if (gridView1.FocusedRowHandle >= 0) dr1 = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            else dr1 = null;

            if (dr1 != null)
            {
                _currentCode = dr1["CARI_KOD"].ToString();
            }

            FetchData(_currentCode);
            tb_currentCode.Enabled = false;
        }

        private void btn_currentList_Click(object sender, EventArgs e)
        {
            Form_CurrentList rehber = new Form_CurrentList();
            rehber.ShowDialog();

            _list = Data.fetchQuery("SELECT * FROM TBL_CARISABIT WHERE CARI_KOD LIKE '%" +
                                     General.changeCharacter(Form_CurrentList.currentCode) + "%'");

            if (_list.Rows.Count != 0)
            {
                _currentCode = _list.Rows[0]["CARI_KOD"].ToString();
                _currentName = _list.Rows[0]["CARI_ISIM"].ToString();
                _address = _list.Rows[0]["ADRES"].ToString();
                _province = _list.Rows[0]["IL"].ToString();
                _district = _list.Rows[0]["ILCE"].ToString();
                _phone = _list.Rows[0]["TEL"].ToString();
                _fax = _list.Rows[0]["FAKS"].ToString();
                _telephone = _list.Rows[0]["GSM"].ToString();
                _taxOffice = _list.Rows[0]["VERGIDAIRESI"].ToString();
                _taxNo = _list.Rows[0]["VERGINUMARASI"].ToString();
                _idNo = _list.Rows[0]["TCKIMLIKNO"].ToString();
                _authorized = _list.Rows[0]["YETKILI"].ToString();
                _email = _list.Rows[0]["EMAIL"].ToString();
                _description = _list.Rows[0]["ACIKLAMA"].ToString();
                _type = _list.Rows[0]["CARI_TIP"].ToString();
                _type2 = _list.Rows[0]["CARI_TIP2"].ToString();

                tb_currentCode.Text = _currentCode;
                tb_currentName.Text = _currentName;
                tb_address.Text = _address;
                tb_province.Text = _province;
                tb_district.Text = _district;
                tb_phone.Text = _phone;
                tb_fax.Text = _fax;
                tb_telephone.Text = _telephone;
                tb_taxOffice.Text = _taxOffice;
                tb_taxNumber.Text = _taxNo;
                tb_idNumber.Text = _idNo;
                tb_authorized.Text = _authorized;
                tb_eMail.Text = _email;
                tb_description.Text = _description;

                if (_type == "A")
                    rg_type.SelectedIndex = 0;

                else if (_type == "S")
                    rg_type.SelectedIndex = 1;

                else if (_type == "D")
                    rg_type.SelectedIndex = 2;


                if (_type2 == "K")
                    rg_type2.SelectedIndex = 0;

                else if (_type2 == "A")
                    rg_type2.SelectedIndex = 1;

                else if (_type2 == "D")
                    rg_type2.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("Sie haben keine Kunden ausgewählt!");
            }

            _currentMovement.Clear();
            grid_currentMovement.Visible = true;
            _currentMovement =
                Data.fetchQuery(
                    "SELECT ID, CARI_KOD,HARK_TARH,BELGE_NO,VADE_TARIHI,ACIKLAMA,CARI_BORC,CARI_ALCK,CARI_BAKY,HAREKET_TURU FROM VW_CARI_HAREKET WHERE CARI_KOD = '" +
                    General.changeCharacter(_currentCode) + "'");
            grid_currentMovement.DataSource = _currentMovement;
            tb_currentCode.Enabled = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();
            Refresh_();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Delete(_currentCode);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Refresh_();
            _currentMovement.Clear();
            RefreshMove();
        }

        private void dt_dateMOVE_EditValueChanged(object sender, EventArgs e)
        {
            _date = Convert.ToDateTime(dt_dateMOVE.EditValue);
            dt_dateMOVE.Text = _date.ToShortDateString();
        }

        private void tb_documentNoMOVE_Leave(object sender, EventArgs e)
        {
            _documentNo = tb_documentNoMOVE.Text;
        }

        private void dt_maturityDatemMOVE_EditValueChanged(object sender, EventArgs e)
        {
            _maturityDate = Convert.ToDateTime(dt_maturityDatemMOVE.EditValue);
            dt_maturityDatemMOVE.Text = _maturityDate.ToShortDateString();
        }

        private void tb_descriptionMOVE_Leave(object sender, EventArgs e)
        {
            _descriptionMove = tb_descriptionMOVE.Text;
        }

        private void rg_amounttypeMOVE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rg_amounttypeMOVE.SelectedIndex == 0) _typeMove = "B";
            else if (rg_amounttypeMOVE.SelectedIndex == 1) _typeMove = "A";
        }

        private void tb_amountMOVE_Leave(object sender, EventArgs e)
        {
            try
            {
                _amountMove = Convert.ToDouble(tb_amountMOVE.Text);

                if (_typeMove == "B")
                {
                    _payerMove = _amountMove;
                    _payeeMove = 0;
                }
                else if (_typeMove == "A")
                {
                    _payeeMove = _amountMove;
                    _payerMove = 0;
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                throw;
            }
        }

        private void btn_addMOVE_Click(object sender, EventArgs e)
        {
            if (_amountMove != 0)
            {
                SaveMove();
            }
            else
            {
                MessageBox.Show("Betrag kann nicht null sein!");
            }

            _currentMovement.Clear();
            _currentMovement =
                Data.fetchQuery(
                    "SELECT ID, CARI_KOD,HARK_TARH,BELGE_NO,VADE_TARIHI,ACIKLAMA,CARI_BORC,CARI_ALCK,CARI_BAKY,HAREKET_TURU FROM VW_CARI_HAREKET WHERE CARI_KOD = '" +
                    _currentCode + "'");
            grid_currentMovement.DataSource = _currentMovement;
        }

        private void grid_currentMovement_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr1 = null;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
                hi = gridView2.CalcHitInfo((grid_currentMovement as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0) dr1 = gridView2.GetDataRow(hi.RowHandle);
            else if (gridView2.FocusedRowHandle >= 0) dr1 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            else dr1 = null;

            if (dr1 != null)
            {
                _id = Convert.ToInt32(dr1["ID"]);
                _typeMove = dr1["HAREKET_TURU"].ToString();
            }

            FetchDataMove(_currentCode, _id);
        }

        private void btn_deleteMOVE_Click(object sender, EventArgs e)
        {
            if (_typeMove == "A")
            {
                Data.commandQuery("DELETE FROM TBL_CARIHAREKET WHERE CARI_KOD = '" + _currentCode + "' AND ID = " +
                                  _id + "");
                _currentMovement.Clear();
                _currentMovement =
                    Data.fetchQuery(
                        "SELECT ID, CARI_KOD,HARK_TARH,BELGE_NO,VADE_TARIHI,ACIKLAMA,CARI_BORC,CARI_ALCK,CARI_BAKY,HAREKET_TURU FROM VW_CARI_HAREKET WHERE CARI_KOD = '" +
                        _currentCode + "'");
                grid_currentMovement.DataSource = _currentMovement;
            }
            else
            {
                MessageBox.Show("Bitte löschen Sie aus dem Abschnitt, den Sie eingegeben haben.");
            }

            //Refresh_();
            //RefreshMove();
        }

        private void btn_refreshMOVE_Click(object sender, EventArgs e)
        {
            Refresh_();
            _currentMovement.Clear();
            RefreshMove();
        }

        //private void grid_cariisimara_DoubleClick(object sender, EventArgs e)
        //{
        //    DataRow dr1 = null;
        //    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
        //    hi = gridView8.CalcHitInfo((grid_cariler as Control).PointToClient(Control.MousePosition));

        //    if (hi.RowHandle >= 0) dr1 = gridView8.GetDataRow(hi.RowHandle);
        //    else
        //        if (gridView8.FocusedRowHandle >= 0) dr1 = gridView8.GetDataRow(gridView8.FocusedRowHandle);
        //    else dr1 = null;

        //    if (dr1 != null)
        //    {
        //        currentCode = dr1["CARI_KOD"].ToString();
        //    }

        //    fetchData(currentCode);
        //    grid_cariisimara.Visible = false;
        //
        //}

        private void sendExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Kunden Transaktion Reporter(" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ")";
            save.Filter = "Excel-Arbeitsmappe |*.xls";
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (save.ShowDialog() == DialogResult.OK) //Pencerede kayıt düğmesine basıldıysa
            {
                grid_currentMovement.ExportToXls(save.FileName);
            }

            if (MessageBox.Show("Öffnen Sie die exportierte Datei?", "Excel-Datei", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Kaydedilen Excel Dosyasını açar.
                System.Diagnostics.Process.Start(save.FileName);
            }
        }
    }
}
