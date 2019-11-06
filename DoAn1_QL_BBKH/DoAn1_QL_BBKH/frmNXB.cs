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
    public partial class frmNXB : Form
    {
        table_NXB data = new table_NXB();
        public frmNXB()
        {
            InitializeComponent();
            DisplayDataNXB();
        }
        public void DisplayDataNXB()
        {
            try
            {
                DataSet ds = data.LayNXB();
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có lỗi, Không thể lấy danh sách!");
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (tbMaNXB.Text != "" && tbTenNXB.Text != "")
            {
                bool f = data.ThemNXB(tbMaNXB.Text, tbTenNXB.Text, tbDiaChi.Text);
                if (f == true) { MessageBox.Show("Thêm Thành Công!"); }
                else MessageBox.Show("Đã có lỗi trong việc nhập thông tin!");
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            DisplayDataNXB();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (tbMaNXB.Text != "" && tbTenNXB.Text != "")
            {
                bool f = data.SuaNXB(tbMaNXB.Text, tbTenNXB.Text, tbDiaChi.Text);
                if (f == true) { MessageBox.Show("Sửa Thành Công!"); }
                else MessageBox.Show("Đã có lỗi trong việc nhập thông tin!");
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            DisplayDataNXB();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (tbMaNXB.Text != "")
            {
                bool f = data.XoaNXB(tbMaNXB.Text);
                if (f == true) { MessageBox.Show("Xóa Thành Công!"); }
                else MessageBox.Show("Đã có lỗi trong việc nhập thông tin!");
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            DisplayDataNXB();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            tbDiaChi.Text = "";tbTenNXB.Text = "";tbMaNXB.Text = "";
            txtTimKiem.Focus();
            txtTimKiem.Clear();
            //dtTK.Clear();
            DisplayDataNXB();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            DataSet ds = data.FindNXB(txtTimKiem.Text);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            dgv.DataSource = dt;
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbMaNXB.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbTenNXB.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbDiaChi.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            }

        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Bạn muốn về giao diện chính?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();

        }
    }
}
