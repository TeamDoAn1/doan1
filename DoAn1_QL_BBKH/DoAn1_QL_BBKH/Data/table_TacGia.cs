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
    class table_TacGia
    {
        DBconnect db = null;
        public table_TacGia()
        {
            db = new DBconnect();
        }
        public DataSet LayTacGia()
        {
            return db.ExecuteQueryDataSet("select * from Tac_Gia");
        }
        public bool ThemTacGia(string ID, string Ten, string diachi, string sdt)
        {
            string sqlString = "Insert into Tac_Gia values('" + ID + "', '" + Ten + "','" + diachi + "','" + sdt + "');";

            return db.MyExecuteNonQuery(sqlString);
        }

        public bool SuaTacGia(string ID, string ten, string diachi, string sdt)
        {

            string sqlString = "Update Tac_Gia SET tentacgia='" + ten + "', diachi='" + diachi + "',sdt='" + sdt + "' where (id='" + ID + "');";
            return db.MyExecuteNonQuery(sqlString);
        }
        public bool XoaTacGia(string ID)
        {
            string sqlString = "Delete from Tac_Gia where ID=" + ID;
            return db.MyExecuteNonQuery(sqlString);
        }
        public DataSet FindTG(string ID)
        {
            string sqlString = "select * from Tac_Gia where ID='" + ID + "';";
            return db.ExecuteQueryDataSet(sqlString);
        }
    }
}
