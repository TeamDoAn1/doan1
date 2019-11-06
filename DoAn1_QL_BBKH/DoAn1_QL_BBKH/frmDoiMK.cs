using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1_QL_BBKH.Data;
using System.Windows.Forms;

namespace DoAn1_QL_BBKH
{
    public partial class frmDoiMK : Form
    {
        table_user1 data = new table_user1();
        public frmDoiMK()
        {
            InitializeComponent();
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtmkmoi.Text == txtmkxn.Text)
            {
                DataSet ds = data.FindUser(frmMain.username, txtmkcu.Text);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    AutoClosingMessageBox.Show("Sai Mật Khẩu Cũ", "Đổi Mật Khẩu...", 1000);

                }
                else
                { 
                    AutoClosingMessageBox.Show("Đổi Mật Khẩu Thành Công!", "Đổi Mật Khẩu...", 1000);
                    bool f = data.DoiMK(Convert.ToString(frmMain.username), txtmkmoi.Text);
                    this.Close();
                }
            }
            else AutoClosingMessageBox.Show("Mật Khẩu Không Trùng Với Nhau!", "Đổi Mật Khẩu...", 1000);
        }
    }
}
