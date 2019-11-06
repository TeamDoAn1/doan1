using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1_QL_BBKH.DB
{
    class DBconnect
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        public DBconnect()
        {
            string ConnStr = "Data Source=DESKTOP-B3EEN8H\\SQLEXPRESS;Initial Catalog=QuanLi_BaiBaoKhoaHoc;Integrated Security=True";
            conn = new SqlConnection(ConnStr);
        }
        public DataSet ExecuteQueryDataSet(string strSQL)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public bool MyExecuteNonQuery(string strSQL)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            comm = new SqlCommand(strSQL, conn);
            comm.Connection.Open();
            try
            {

                comm.ExecuteNonQuery();
                f = true;
            }
            catch
            {
                
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        public string[] FindExecute(string strSQL)
        {
            string[] ok = null;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            comm = new SqlCommand(strSQL, conn);
            comm.Connection.Open();
            try
            {
                var reader = comm.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    
                    ok[i] = reader.GetString(1);
                    i++;
                }

            }
            catch 
            {

            }
            finally
            {
                conn.Close();
            }
            return ok;
        }
    }

}
