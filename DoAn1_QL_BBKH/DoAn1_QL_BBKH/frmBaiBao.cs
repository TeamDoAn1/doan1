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
    public partial class frmBaiBao : Form
    {
        int tk = 0;
        DataTable dtTK = new DataTable();
        table_BaiBao data = new table_BaiBao();
        public frmBaiBao()
        {
            InitializeComponent();
            DisplayDataBaiBao();
        }
        public void DisplayDataBaiBao()
        {
            try
            { 
                DataSet ds = data.LayBaiBao();
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                AutoClosingMessageBox.Show("Đã xảy ra lỗi, không thể lấy danh sách!", "Warning...", 1000);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {

            if (tbMaBai.Text != "" && tbTenBai.Text != "" && tbNXB.Text!="" && tbTacGia.Text!= "")
            {
                bool f = data.ThemBai(tbMaBai.Text, tbTenBai.Text, tbTacGia.Text, tbNXB.Text, tbNoiDang.Text, tbThoiGian.Text, tbSoTrang.Text, tbSoLuoc.Text, tbTrichDan.Text);
                if (f == true) { AutoClosingMessageBox.Show("Thêm Thành Công!", "Warning...", 1000); btClear.PerformClick(); }
                else AutoClosingMessageBox.Show("Đã có lỗi trong việc nhập thông tin!", "Warning...", 1000);
            }
            else
            {
                AutoClosingMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Warning...", 1000);
            }
            DisplayDataBaiBao();
        }

        private void BtSua_Click(object sender, EventArgs e)
        {
            if (tbMaBai.Text != "" && tbTenBai.Text != "" && tbNXB.Text != "" && tbTacGia.Text != "")
            {
                bool f = data.SuaBai(tbMaBai.Text, tbTenBai.Text, tbTacGia.Text, tbNXB.Text, tbNoiDang.Text, tbThoiGian.Text, tbSoTrang.Text, tbSoLuoc.Text, tbTrichDan.Text);
                if (f == true) { AutoClosingMessageBox.Show("Sửa Thành Công!", "Warning...", 1000); btClear.PerformClick(); }
                else AutoClosingMessageBox.Show("Đã có lỗi trong việc nhập thông tin!", "Warning...", 1000);
            }
            else
            {
                AutoClosingMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Warning...", 1000);
            }
            DisplayDataBaiBao();
        }

        private void BtXoa_Click(object sender, EventArgs e)
        {
            if (tbMaBai.Text != "")
            {
                bool f = data.XoaBai(tbMaBai.Text);
                if (f == true) { AutoClosingMessageBox.Show("Xóa Thành Công!", "Warning...", 1000); btClear.PerformClick(); }
                else AutoClosingMessageBox.Show("Đã có lỗi trong việc nhập thông tin!", "Warning...", 1000);
            }
            else
            {
                AutoClosingMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Warning...", 1000);
            }
            DisplayDataBaiBao();
        }

        private void BtClear_Click(object sender, EventArgs e)
        {
            tbTacGia.Text = "";tbMaBai.Text = "";tbNoiDang.Text = "";
            tbNXB.Text = "";tbSoLuoc.Text = "";tbSoTrang.Text = "";tbTrichDan.Text = "";tbThoiGian.Text = "";tbTenBai.Text = "";
            txtTimKiem.Focus();
            txtTimKiem.Clear();
            dtTK.Clear();
            DisplayDataBaiBao();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            //string select = cbBox.GetItemText(cbBox.SelectedItem);
            //switch (select)
            //{
            //    case "Mã Bài Báo":
            //        select = "ID";
            //        break;
            //    case "Tên Bài Báo":
            //        select = "TenBaiBao"; break;
            //    case "Tác Giả":
            //        select = "TacGia"; break;
            //    case "NXB":
            //        select = "NXB"; break;
            //    case "Tất Cả":
            //        select = ""; break;
            //    case "":
            //        select = "ID"; break;
            //}
            //string word = txtTimKiem.Text;
            //if (select == "TacGia" || select == "ID")
            //{
            //    int a;
            //    bool result = Int32.TryParse(txtTimKiem.Text, out a);
            //    if (result)
            //    {
            //        DataSet ds = data.Find(select, word);
            //        DataTable dt = new DataTable();
            //        dt = ds.Tables[0];
            //        dgv.DataSource = dt;
            //    }
            //    else AutoClosingMessageBox.Show("Đã có lỗi trong việc nhập thông tin!", "Warning...", 1000);
            //}
            //else
            //{
            //    DataSet ds = data.Find(select, word);
            //    DataTable dt = new DataTable();
            //    dt = ds.Tables[0];
            //    dgv.DataSource = dt;
            //}
            if (tk == 0)
            {
                dtTK.Columns.Add("ID", typeof(string));
                dtTK.Columns.Add("TenBaiBao", typeof(string));
                dtTK.Columns.Add("TenTacGia", typeof(string));
                dtTK.Columns.Add("TenNXB", typeof(string));
                dtTK.Columns.Add("NoiDang", typeof(string));
                dtTK.Columns.Add("NgayDang", typeof(string));
                dtTK.Columns.Add("SoTrang", typeof(string));
                dtTK.Columns.Add("SoLuoc", typeof(string));
                dtTK.Columns.Add("TrichDan", typeof(string));
            }

            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                if (String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[0].Value.ToString(), true) == 0
                 || dgv.Rows[i].Cells[1].Value.ToString().Contains(txtTimKiem.Text) != false
                 || dgv.Rows[i].Cells[2].Value.ToString().Contains(txtTimKiem.Text) != false
                 || dgv.Rows[i].Cells[3].Value.ToString().Contains(txtTimKiem.Text) != false
                 || dgv.Rows[i].Cells[4].Value.ToString().Contains(txtTimKiem.Text) != false
                 || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[5].Value.ToString(), true) == 0
                 || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[6].Value.ToString(), true) == 0
                 || dgv.Rows[i].Cells[7].Value.ToString().Contains(txtTimKiem.Text) != false
                 || dgv.Rows[i].Cells[8].Value.ToString().Contains(txtTimKiem.Text) != false)
                {

                    //MessageBox.Show(Convert.ToString(dtTK.Rows.Count));
                    DataRow row;
                    row = dtTK.NewRow();
                    row["ID"] = dgv.Rows[i].Cells[0].Value.ToString();
                    row["TenBaiBao"] = dgv.Rows[i].Cells[1].Value.ToString();
                    row["TenTacGia"] = dgv.Rows[i].Cells[2].Value.ToString();
                    row["TenNXB"] = dgv.Rows[i].Cells[3].Value.ToString();
                    row["NoiDang"] = dgv.Rows[i].Cells[4].Value.ToString();
                    row["NgayDang"] = dgv.Rows[i].Cells[5].Value.ToString();
                    row["SoTrang"] = dgv.Rows[i].Cells[6].Value.ToString();
                    row["SoLuoc"] = dgv.Rows[i].Cells[7].Value.ToString();
                    row["TrichDan"] = dgv.Rows[i].Cells[8].Value.ToString();
                    dtTK.Rows.Add(row);
                };
            }
            tk++;
            dgv.DataSource = dtTK;

        }


        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex  >= 0)
            {
                tbMaBai.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbTenBai.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbTacGia.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbNXB.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                tbNoiDang.Text = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                tbThoiGian.Text = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                tbSoTrang.Text = dgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbSoLuoc.Text = dgv.Rows[e.RowIndex].Cells[7].Value.ToString();
                tbTrichDan.Text = dgv.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }
        private void BtnTroVe_Click(object sender, EventArgs e)
        {

            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Bạn muốn về giao diện chính?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }



        //------------------------------------------------
        private void TbMaBai_MouseClick(object sender, MouseEventArgs e)
        {
            tbMaBai.SelectAll();
        }

        private void TbTenBai_MouseClick(object sender, MouseEventArgs e)
        {
            tbTenBai.SelectAll();
        }

        private void TbTacGia_MouseClick(object sender, MouseEventArgs e)
        {
            tbTacGia.SelectAll();
        }

        private void TbNXB_MouseClick(object sender, MouseEventArgs e)
        {
            tbNXB.SelectAll();
        }

        private void TbThoiGian_MouseClick(object sender, MouseEventArgs e)
        {
            tbThoiGian.SelectAll();
        }

        private void TbNoiDang_MouseClick(object sender, MouseEventArgs e)
        {
            tbNoiDang.SelectAll();
        }

        private void TbSoTrang_MouseClick(object sender, MouseEventArgs e)
        {
            tbSoTrang.SelectAll();
        }

        private void TbSoLuoc_MouseClick(object sender, MouseEventArgs e)
        {
            tbSoLuoc.SelectAll();
        }

        private void TxtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }


    }
}
