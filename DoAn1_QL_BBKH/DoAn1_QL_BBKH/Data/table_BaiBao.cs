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
    class table_BaiBao
    {
        DBconnect db = null;
        public table_BaiBao()
        {
            db = new DBconnect();
        }
        public DataSet LayBaiBao()
        {
            return db.ExecuteQueryDataSet("select Bai_Bao_KH.ID, TenBaiBao, Tac_Gia.TenTacGia, Nha_Xuat_Ban.TenNXB, NoiDang, NgayDang, SoTrang, SoLuoc, TrichDan from Bai_Bao_KH, Tac_Gia, Nha_Xuat_Ban where Bai_Bao_KH.TacGia = Tac_Gia.ID and Bai_Bao_KH.NXB = Nha_Xuat_Ban.ID  ");
        }
        public bool ThemBai(string ID, string tenbaibao, string tacgia, string NXB, string noidang, string ngaydang, string sotrang, string soluoc, string trichdan)
        {
            string sqlString = "Insert Into Bai_Bao_KH Values('" + ID + "','" + tenbaibao + "','" + tacgia + "','"
                + NXB + "','" + noidang + "','" + ngaydang + "','" + sotrang + "','" + soluoc + "','" + trichdan + "')";
            return db.MyExecuteNonQuery(sqlString);
        }
        public bool SuaBai(string ID, string tenbaibao, string tacgia, string NXB, string noidang, string ngaydang, string sotrang, string soluoc, string trichdan)
        {
            string sqlString = "Update Bai_Bao_KH SET tenbaibao='" + tenbaibao + "',tacgia='" + tacgia + "',NXB='"
                + NXB + "',noidang='" + noidang + "',ngaydang='" + ngaydang + "',sotrang='" + sotrang + "',soluoc='" + soluoc +
                "',trichdan='" + trichdan + "' WHERE (ID='" + ID + "');";
            return db.MyExecuteNonQuery(sqlString);
        }
        public bool XoaBai(string ID)
        {
            string sqlString = "Delete from Bai_Bao_KH where ID=" + ID;
            return db.MyExecuteNonQuery(sqlString);
        }
        public DataSet Find(string select, string word)
        {
            string sqlString = "select * from Bai_Bao_KH where "+select+"='" + word + "';";
            return db.ExecuteQueryDataSet(sqlString);
        }
        public string[] Auto(string select)
        {
            string[] a = new string[400];
            string sqlString = "select " + select + " from Bai_Bao_KH";
            return db.FindExecute(sqlString);
        }
    }
}
