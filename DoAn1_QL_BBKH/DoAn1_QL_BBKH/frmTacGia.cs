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
    public partial class frmTacGia : Form
    {
        table_TacGia data = new table_TacGia();
        public frmTacGia()
        {
            InitializeComponent();
            DisplayDataTacGia();
        }
        public void DisplayDataTacGia()
        {
            try
            {
                DataSet ds = data.LayTacGia();
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
            if (tbMaTG.Text != "" && tbTenTG.Text != "")
            {
                bool f = data.ThemTacGia(tbMaTG.Text, tbTenTG.Text, tbDiaChi.Text, tbSDT.Text);
                if (f == true) { MessageBox.Show("Thêm Thành Công!"); }
                else MessageBox.Show("Đã có lỗi trong việc nhập thông tin!");
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            DisplayDataTacGia();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (tbMaTG.Text != "" && tbTenTG.Text != "")
            {
                bool f = data.SuaTacGia(tbMaTG.Text, tbTenTG.Text, tbDiaChi.Text, tbSDT.Text);
                if (f == true) { MessageBox.Show("Sửa Thành Công!"); }
                else MessageBox.Show("Đã có lỗi trong việc nhập thông tin!");
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            DisplayDataTacGia();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (tbMaTG.Text != "")
            {
                bool f = data.XoaTacGia(tbMaTG.Text);
                if (f == true) { MessageBox.Show("Xóa Thành Công!"); }
                else MessageBox.Show("Đã có lỗi trong việc nhập thông tin!");
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            DisplayDataTacGia();
        }

        private void BtClear_Click(object sender, EventArgs e)
        {
            tbMaTG.Text = "";tbTenTG.Text = "";tbDiaChi.Text = "";tbSDT.Text = "";
            txtTimKiem.Focus();
            txtTimKiem.Clear();
            //dtTK.Clear();
            DisplayDataTacGia();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            DataSet ds = data.FindTG(txtTimKiem.Text);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            dgv.DataSource = dt;
            
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbMaTG.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbTenTG.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbDiaChi.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbSDT.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
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
