using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.CodeParser;
using Microsoft.Win32;

namespace TrackingProducts
{
    public class GeneralClasses
    {
        DAL Data = new DAL();
        public static string sirket, sube, user, usr, sqlsn, sqlun, sqlup, npass;

        public string editDateFormat(DateTime t, int kont)
        {
            string date = null;

            string day, month, year;

            day = t.Day.ToString();
            month
                 = t.Month.ToString();
            year = t.Year.ToString();

            if (kont == 1 || kont == 2)
            {
                day = t.Day.ToString();
                month
                 = t.Month.ToString();
                year = t.Year.ToString();
            }

            if (day.Length == 1)
                day = "0" + day;

            if (month
                .Length == 1)
                month
                 = "0" + month
                ;

            if (kont == 0) date = year + "-" + month
                 + "-" + day;
            else if (kont == 1) date = year + month
                ;
            else if (kont == 2) date = day + month
                 + year;

            return date;
        }

        public string changeCharacter(string data)
        {
            if (data != null)
            {
                foreach (char c in data)
                {
                    switch (c)
                    {
                        case 'ş':
                            data = data.Replace(c, 'þ');
                            break;
                        case 'Ş':
                            data = data.Replace(c, 'Þ');
                            break;
                            ;
                        case 'ı':
                            data = data.Replace(c, 'ý');
                            break;
                        case 'İ':
                            data = data.Replace(c, 'Ý');
                            break;
                        case 'ğ':
                            data = data.Replace(c, 'ð');
                            break;
                        case 'Ğ':
                            data = data.Replace(c, 'Ð');
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error.");
                data = "";
            }
            return data;
        }

        public string readCharacter(string data)
        {
            foreach (char c in data)
            {
                switch (c)
                {
                    case 'þ':
                        data = data.Replace(c, 'ş');
                        break;
                    case 'Þ':
                        data = data.Replace(c, 'Ş');
                        break; ;
                    case 'ý':
                        data = data.Replace(c, 'ı');
                        break;
                    case 'Ý':
                        data = data.Replace(c, 'İ');
                        break;
                    case 'ð':
                        data = data.Replace(c, 'ğ');
                        break;
                    case 'Ð':
                        data = data.Replace(c, 'Ğ');
                        break;
                }
            }
            return data;
        }

        public double exchangeRate(int tip, DateTime date)
        {
            double value = 0;

            DataTable dataTable = new DataTable();
            dataTable = Data.fetchQuery("SELECT ISNULL(DOV_ALIS,0) AS KUR FROM NETSIS..DOVIZ WHERE SIRA = " + tip + " AND TARIH = '" + editDateFormat(date, 0) + "'");
            if (dataTable.Rows.Count == 0)
                value = 0;
            else
                value = Convert.ToDouble(dataTable.Rows[0]["KUR"]);

            return value;
        }

        public string fetchOrderNo(string user)
        {
            DataTable dataTable = new DataTable();
            string orderNo = null;
            int no;
            string user1 = user.Substring(0, 3) + user.Substring(user.Length - 1, 1);
            dataTable = Data.fetchQuery("SELECT CONVERT(INT,SUBSTRING(FATIRS_NO,5,11)) AS SIPNO FROM " + sirket + "..TBLSIPAMAS WHERE FATIRS_NO LIKE '" + user1 + "%'");

            if (dataTable.Rows.Count != 0)
            {
                no = Convert.ToInt32(dataTable.Rows[0]["SIPNO"]);
                no = no + 1;
            }
            else
            {
                no = 1;
            }

            int say = no.ToString().Length + user1.Length;

            for (int i = 0; i < (15 - say); i++)
            {
                user1 = user1 + "0";
            }

            orderNo = user1 + no.ToString();

            return orderNo;
        }

        public string fetchCustomerCode()
        {
            string ck = null;
            int code, control;

            DataTable ff = new DataTable();
            ff = Data.fetchQuery("SELECT MAX(SUBSTRING(CARI_KOD,2,9)) AS KOD FROM TBLCASABIT WHERE CARI_KOD LIKE 'M%'");
            code = Convert.ToInt32(ff.Rows[0]["KOD"]);
            code = code + 1;

            control = 9 - code.ToString().Length;

            for (int i = 0; i < control; i++)
            {
                ck = "0" + ck;
            }

            ck = "M" + ck + code;

            return ck;
        }

        public string passencodedecode(byte x, string y)
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

        public Boolean FirmaVergiKontrol(string vno) // Vergi Numarası Doğrulama
        {
            if (vno.ToString().Length != 10) return false;

            Int32 V_LAST_DIGIT, V_1, V_2, V_3, V_4, V_5, V_6, V_7, V_8, V_9, V_11, V_22, V_33, V_44, V_55, V_66, V_77, V_88, V_99, TOPLAM;
            bool R;

            V_1 = (Int32.Parse(vno.Substring(0, 1)) + 9) % 10;
            V_2 = (Int32.Parse(vno.Substring(1, 1)) + 8) % 10;
            V_3 = (Int32.Parse(vno.Substring(2, 1)) + 7) % 10;
            V_4 = (Int32.Parse(vno.Substring(3, 1)) + 6) % 10;
            V_5 = (Int32.Parse(vno.Substring(4, 1)) + 5) % 10;
            V_6 = (Int32.Parse(vno.Substring(5, 1)) + 4) % 10;
            V_7 = (Int32.Parse(vno.Substring(6, 1)) + 3) % 10;
            V_8 = (Int32.Parse(vno.Substring(7, 1)) + 2) % 10;
            V_9 = (Int32.Parse(vno.Substring(8, 1)) + 1) % 10;
            V_LAST_DIGIT = Int32.Parse(vno.Substring(9, 1));

            V_11 = (V_1 * 512) % 9;
            V_22 = (V_2 * 256) % 9;
            V_33 = (V_3 * 128) % 9;
            V_44 = (V_4 * 64) % 9;
            V_55 = (V_5 * 32) % 9;
            V_66 = (V_6 * 16) % 9;
            V_77 = (V_7 * 8) % 9;
            V_88 = (V_8 * 4) % 9;
            V_99 = (V_9 * 2) % 9;

            if (V_1 != 0 && V_11 == 0) V_11 = 9;
            if (V_2 != 0 && V_22 == 0) V_22 = 9;
            if (V_3 != 0 && V_33 == 0) V_33 = 9;
            if (V_4 != 0 && V_44 == 0) V_44 = 9;
            if (V_5 != 0 && V_55 == 0) V_55 = 9;
            if (V_6 != 0 && V_66 == 0) V_66 = 9;
            if (V_7 != 0 && V_77 == 0) V_77 = 9;
            if (V_8 != 0 && V_88 == 0) V_88 = 9;
            if (V_9 != 0 && V_99 == 0) V_99 = 9;

            TOPLAM = V_11 + V_22 + V_33 + V_44 + V_55 + V_66 + V_77 + V_88 + V_99;

            if (TOPLAM % 10 == 0)
            {
                TOPLAM = 0;
            }
            else
            {
                TOPLAM = (10 - (TOPLAM % 10));
            }

            if (TOPLAM == V_LAST_DIGIT)
            {
                R = true;
            }
            else
            {
                R = false;
            }

            return R;
        }

        public Boolean TCNoKontrol(string tcno)
        {
            bool a = false;
            int toplam = 0, tc11, kont, tc;

            for (int i = 0; i < 10; i++)
            {
                tc = Convert.ToInt32(tcno.Substring(i, 1));
                toplam = toplam + tc;
            }

            kont = toplam % 10;

            tc11 = Convert.ToInt32(tcno.Substring(10, 1));

            if (kont == tc11)
            {
                a = true;
            }
            else
            {
                a = false;
            }

            return a;
        } // T.C. No Kontrol

        public Boolean eMailControl(string emailAddress)
        {
            const string patternLenient = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex reLenient = new Regex(patternLenient);
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\null]+"
                  + @"(\.[^<>()[\]\\.,;:\s@\null]+)*)|(\null.+\null))@"
                  + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                  + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                  + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);

            bool isLenientMatch = reLenient.IsMatch(emailAddress);
            return isLenientMatch;
        }

        public string DocumentNo(string tip2, string tip)
        {
            DataTable DataTableDocument = new DataTable();
            string documentNo = null;
            int bn = 0, say = 0;

            if (tip == "S" && tip2 == "S")
            {
                DataTableDocument = Data.fetchQuery("SELECT COUNT(BELGE_NO) AS SAY FROM TBL_FATUIRS WHERE FTIRSIP = '" + tip2 + "' AND TIP = '" + tip + "'");
                say = Convert.ToInt32(DataTableDocument.Rows[0]["SAY"]);
                if (say == 0) bn = 0;
                else
                {
                    DataTableDocument = Data.fetchQuery("SELECT MAX(CONVERT(INT,ISNULL(BELGE_NO,0))) AS NO FROM TBL_FATUIRS WHERE FTIRSIP = '" + tip2 + "' AND TIP = '" + tip + "'");
                    bn = Convert.ToInt32(DataTableDocument.Rows[0]["NO"]);
                }

                bn = bn + 1;
                int uzn = bn.ToString().Length;
                int don = 16 - uzn;
                documentNo = bn.ToString();
                for (int i = 0; i < don; i++)
                {
                    documentNo = "0" + documentNo;
                }
            }
            return documentNo;
        }
    }
}
