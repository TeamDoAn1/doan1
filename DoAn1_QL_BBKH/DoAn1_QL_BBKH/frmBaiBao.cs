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
using System.Data.SqlClient;

namespace DoAn1_QL_BBKH
{   
    public partial class frmBaiBao : Form
    {
        int tk = 0;
        DataTable dtTK = new DataTable();
        DataTable dt = new DataTable();
        table_BaiBao data = new table_BaiBao();
        public frmBaiBao()
        {
            InitializeComponent();
            toolTip1.SetToolTip(btnTimKiem, "Tìm kiếm");
            toolTip1.SetToolTip(xuatExcel, "Xuất ra file Excel");
            toolTip1.SetToolTip(btXoa, "Xóa");
            toolTip1.SetToolTip(btClear, "Hủy");
            toolTip1.SetToolTip(btSua, "Sửa");
            toolTip1.SetToolTip(btnThem, "Thêm");
            toolTip1.SetToolTip(btnTroVe, "Trở về");
            DisplayDataBaiBao();

        }
        public void DisplayDataBaiBao()
        {
            try
            { 
                DataSet ds = data.LayBaiBao();
               
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
            try
            {
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
                else
                {
                    dtTK.Clear();
                    DisplayDataBaiBao();
                }
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    if (String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[0].Value.ToString(), true) == 0
                     || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[1].Value.ToString(), true) == 0
                     || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[2].Value.ToString(), true) == 0
                     || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[3].Value.ToString(), true) == 0
                     || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[4].Value.ToString(), true) == 0
                     || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[5].Value.ToString(), true) == 0
                     || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[6].Value.ToString(), true) == 0
                     || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[7].Value.ToString(), true) == 0
                     || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[8].Value.ToString(), true) == 0)
                    
                    {

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
            } catch (SqlException)
            {
                MessageBox.Show("Tìm kiếm được. Lỗi rồi! /n Ấn nút Hủy và thử tìm kiếm lại." );
            }

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

        private void xuatExcel_Click(object sender, EventArgs e)
        {
            if (tk > 0)
            {
                Export(dtTK, "BaiBaoKhoaHoc", "Danh sách Bài báo:");
            }
            else
                Export(dt, "BaiBaoKhoaHoc", "Danh sách Bài báo:");
        }
        public void Export(DataTable dt, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "18";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã bài báo";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Tên bài báo";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Tên tác giả";

            cl3.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "I3");

            rowHead.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Tên NXB";
            cl4.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Nơi đăng";
            cl5.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Ngày đăng";
            cl6.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Số trang";
            cl7.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Sơ lược";
            cl8.ColumnWidth = 250.0;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "Trích dẫn";
            cl9.ColumnWidth = 30.0;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int r = 0; r < dt.Rows.Count; r++)

            {

                DataRow dr = dt.Rows[r];

                for (int c = 0; c < dt.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;

            int columnEnd = dt.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c5 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c6 = oSheet.get_Range(c1, c5);
            oSheet.get_Range(c5, c6).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

    }
}
