using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using DoAn1_QL_BBKH.DB;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DoAn1_QL_BBKH.Data
{
    class table_user1
    {
        DBconnect db = null;
        public table_user1()
        {
            db = new DBconnect();
        }

        public DataSet FindUser(string user, string password)
        {
            string sqlString = "select * from User1 where username='" + user + "' and password='" + password + "';";
            return db.ExecuteQueryDataSet(sqlString);
        }
        public bool DoiMK(string user, string password)
        {
            string sqlString = "Update User1 set password='" + password + "' where username='" + user + "';";
            return db.MyExecuteNonQuery(sqlString);
        }
        public DataSet LayTk()
        {
            return db.ExecuteQueryDataSet("select username as TaiKhoan, permission as QuyenTruyCap from User1");
        }

        public bool ThemTK(string tk, int quyen)
        {
            string sqlString = "Insert into User1 values('" + tk + "', '" + 1 +  "','" + quyen + "');";

            return db.MyExecuteNonQuery(sqlString);
        }

        public bool SuaTK(string tk, int quyen)
        {

            string sqlString = "Update User1 SET  permission='" + quyen + "' where (username='" + tk + "');";
            return db.MyExecuteNonQuery(sqlString);
        }
        public bool XoaTK(string tk)
        {
            string sqlString = "Delete from User1 where username=" + tk;
            return db.MyExecuteNonQuery(sqlString);
        }
    }
}
