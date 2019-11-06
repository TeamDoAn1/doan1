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
    public partial class frmDangNhap : Form
    {
        public int ttdn = 0;
        table_user1 data = new table_user1();
        public int permission = 0;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                DataSet ds = data.FindUser(txtMaNV.Text, txtPass.Text);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    AutoClosingMessageBox.Show("Sai Tài Khoản hoặc Mật Khẩu!", "Login...", 1000);

                }
                else
                {
                    frmMain.username = txtMaNV.Text;
                    frmMain.testlogin = true;
                    AutoClosingMessageBox.Show("Đăng nhập Thành Công!", "Login...", 1000);
                    ttdn = 1;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        permission = Convert.ToInt32(dr.ItemArray[2]);
                    }
                    this.Close();                                     
                }
            }
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXacNhan.PerformClick();
            }
        }


        private void TxtMaNV_MouseClick(object sender, MouseEventArgs e)
        {
            txtMaNV.SelectAll();
        }

        private void TxtPass_MouseClick(object sender, MouseEventArgs e)
        {
            txtPass.SelectAll();
        }
    }
    //auto close message box
    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string text, string caption, int timeout)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)
                MessageBox.Show(text, caption);
        }
        public static void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text, caption, timeout);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }

}
