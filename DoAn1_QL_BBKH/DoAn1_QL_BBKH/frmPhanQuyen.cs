using DoAn1_QL_BBKH.Data;
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
    public partial class frmPhanQuyen : Form
    {
        table_user1 data = new table_user1();
        bool Them = false;
        int tk = 0;
        DataTable dtTK = new DataTable();
        public frmPhanQuyen()
        {
            InitializeComponent();
            DisplayDataPhanQuyen();
        }
        public void DisplayDataPhanQuyen()
        {
            this.txtMaNV.ResetText();
            this.txtQuyen.ResetText();

            // Không cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.panel1.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;

            //
            try
            {
                DataSet ds = data.LayTk();
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có lỗi, Không thể lấy danh sách!");
            }

        }
   
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaNV.ResetText();
            this.txtQuyen.ResetText();

            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;

            this.txtMaNV.Focus();
            this.panel1.Enabled = true;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (Them == true)
            {
                // Thực hiện lệnh                
                data.ThemTK(txtMaNV.Text, Convert.ToInt32(txtQuyen.Text));
                // Load lại dữ liệu trên DataGridView
                DisplayDataPhanQuyen();
                // Thông báo
                MessageBox.Show("Đã thêm xong!");
                //}
                //catch (SqlException)
                //{
                //    MessageBox.Show("Không thêm được. Lỗi rồi!");
                //}
            }
            else
            {
                // Thực hiện lệnh
                data.SuaTK(txtMaNV.Text, Convert.ToInt32(txtQuyen.Text));

                // Load lại dữ liệu trên DataGridView
                DisplayDataPhanQuyen();
                // Thông báo
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            this.panel1.Enabled = true;
            //dgv_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.panel1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;

            //this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaNV.Enabled = false;
            this.txtQuyen.Focus();
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtQuyen.ResetText();

            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.panel1.Enabled = false;
            //dgv_CellClick(null, null);
        }

        private void btnTroVe_Click_1(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Bạn muốn về giao diện chính?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNV.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtQuyen.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (tk == 0)
            {
                dtTK.Columns.Add("Tài Khoản", typeof(string));
                dtTK.Columns.Add("Quyền Truy Cập", typeof(string));
            }
            else
            {
                dtTK.Clear();
                DisplayDataPhanQuyen();
            }
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                if (String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[0].Value.ToString(), true) == 0
                 || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[1].Value.ToString(), true) == 0)
                {

                    //MessageBox.Show(Convert.ToString(dtTK.Rows.Count));
                    DataRow row;
                    row = dtTK.NewRow();
                    row["Tài Khoản"] = dgv.Rows[i].Cells[0].Value.ToString();
                    row["Quyền Truy Cập"] = dgv.Rows[i].Cells[1].Value.ToString();
                    dtTK.Rows.Add(row);
                };
            }
            tk++;
            dgv.DataSource = dtTK;
        }
    }
}
