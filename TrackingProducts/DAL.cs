using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingProducts
{
    public class DAL
    {
        string strCon = "";

        private void RegisterRead()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"DESPRO\DBCONNECTION", true);

            try
            {
                if (key != null)
                {
                    string strSQLServer = "";
                    string strSQLUserName = "";
                    string strSQLPass = "";
                    string strDB = "";

                    if (key.GetValue("SQLSERVER").ToString() != null)
                    {
                        strSQLServer = key.GetValue("SQLSERVER").ToString();
                    }

                    if (key.GetValue("SQLUSERNAME").ToString() != null)
                    {
                        strSQLUserName = key.GetValue("SQLUSERNAME").ToString();
                    }

                    if (key.GetValue("SQLPASS").ToString() != null)
                    {
                        strSQLPass = FormMain.Passencodedecode(1, key.GetValue("SQLPASS").ToString());
                    }

                    if (key.GetValue("DB").ToString() != null)
                    {
                        strDB = key.GetValue("DB").ToString();
                    }

                    if (strSQLServer.Length > 0 && strSQLUserName.Length > 0 && strSQLPass.Length > 0 && strDB.Length > 0)
                    {
                        strCon = String.Format("SERVER={0};UID={1};PWD={2};DATABASE={3}", strSQLServer, strSQLUserName, strSQLPass, strDB);
                    }
                    else
                    {
                        strCon = "";
                    }
                }
                else
                {
                    strCon = "";
                }
            }
            catch
            {
                strCon = "";
            }
        }

        public string sqlConnection()
        {
            return strCon;
        }

        public DataTable fetchQuery(string query)
        {
            try
            {
                if (strCon.Length == 0)
                {
                    RegisterRead();
                }

                SqlConnection con = new SqlConnection();
                con.ConnectionString = strCon;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandText = query;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Hata", typeof(string));
                DataRow dr = dt.NewRow();
                dr["Hata"] = ex.Message;
                dt.Rows.Add(dr);
                return dt;
            }
        }

        public string commandQuery(SqlCommand cmd)
        {
            try
            {
                if (strCon.Length == 0)
                {
                    RegisterRead();
                }

                SqlConnection con = new SqlConnection();
                con.ConnectionString = strCon;

                cmd.Connection = con;
                cmd.CommandTimeout = 0;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string commandQuery(string sorgu)
        {
            try
            {
                if (strCon.Length == 0)
                {
                    RegisterRead();
                }

                SqlConnection con = new SqlConnection();
                con.ConnectionString = strCon;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                cmd.CommandText = sorgu;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
