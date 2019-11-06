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
    class table_NXB
    {
        DBconnect db = null;
        public table_NXB()
        {
            db = new DBconnect();
        }
        public DataSet LayNXB()
        {
            return db.ExecuteQueryDataSet("select * from Nha_Xuat_Ban");
        }
        public bool ThemNXB(string ID, string Ten, string diachi)
        {
            string sqlString = "Insert into Nha_Xuat_Ban values('" + ID + "', '" + Ten + "','" + diachi + "','');";

            return db.MyExecuteNonQuery(sqlString);
        }
        public bool SuaNXB(string ID, string ten, string diachi)
        {

            string sqlString = "Update Nha_Xuat_Ban SET tentacgia='" + ten + "', diachi='" + diachi + "',sdt=' ' where (id='" + ID + "');";
            return db.MyExecuteNonQuery(sqlString);
        }
        public bool XoaNXB(string ID)
        {
            string sqlString = "Delete from Nha_Xuat_Ban where ID=" + ID;
            return db.MyExecuteNonQuery(sqlString);
        }
        public DataSet FindNXB(string ID)
        {
            string sqlString = "select * from Nha_Xuat_Ban where ID='" + ID + "';";
            return db.ExecuteQueryDataSet(sqlString);
        }
    }
}
