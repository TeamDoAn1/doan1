using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DoAn1_QL_BBKH
{
    public partial class frmMain : Form
    {
        public static bool testlogin = false;
        public static string username = "";
        int quyen = 0;
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void lDN_Click(object sender, EventArgs e)
        {
            if (testlogin == true)
            {               
                AutoClosingMessageBox.Show("Đăng xuất thành công!", "Waring!", 1000); testlogin = false; lDN.Text = "Đăng Nhập";
                
                lDN.ForeColor = Color.Blue;
            }
            else
            {
                frmDangNhap fdn = new frmDangNhap();
                fdn.ShowDialog();
                if (fdn.ttdn == 1)
                    lDN.ForeColor = Color.Red;
                quyen = fdn.permission;
            }
                       
        }

        private void btnBaiBao_Click(object sender, EventArgs e)
        {
            if (testlogin == true && quyen == 10 || quyen == 1 || quyen == 4)
            {
                frmBaiBao fbb = new frmBaiBao();
                fbb.ShowDialog();
            }
            else AutoClosingMessageBox.Show("Bạn chưa đăng nhập hoặc quyền hạn không đủ!", "Warning...", 1000);
        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
            if (testlogin == true && quyen == 10 || quyen == 2 || quyen == 4)
            {
                frmTacGia ftg = new frmTacGia();
                ftg.ShowDialog();
            }
            else AutoClosingMessageBox.Show("Bạn chưa đăng nhập hoặc quyền hạn không đủ!", "Warning...", 1000);
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            if (testlogin == true && quyen == 10 || quyen == 3 || quyen == 4)
            {
                frmNXB fnxb = new frmNXB();
                fnxb.ShowDialog();
            }
            else AutoClosingMessageBox.Show("Bạn chưa đăng nhập hoặc quyền hạn không đủ!", "Warning...", 1000);
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (testlogin == true)
            {
                frmDoiMK fdmk = new frmDoiMK();
                fdmk.ShowDialog();
            }
            else AutoClosingMessageBox.Show("Bạn chưa đăng nhập!", "Warning...", 1000);

        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            if (testlogin == true && quyen == 10)
            {
                frmPhanQuyen fpq = new frmPhanQuyen();
                fpq.ShowDialog();
            }
            else AutoClosingMessageBox.Show("Bạn chưa đăng nhập hoặc quyền hạn không đủ!", "Warning...", 1000);
        }

        private void FrmMain_MouseEnter(object sender, EventArgs e)
        {
            if (testlogin == true)
            {
                label7.Text = username;
                label7.Visible = true;
                lDN.Text = "Đăng Xuất";
            }
            else { lDN.Text = "Đăng Nhập"; label7.Visible = false; }
        }

        private void BtnThongTin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm Quản lí các bài báo Khoa học này là đề tài môn Đồ án 1. \nThực hiện bởi sinh viên: \n    - Diệp Gia Hữu \n    - Hồ Sĩ Tuấn \n    - Trương Minh Khoa", "About");
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
}
