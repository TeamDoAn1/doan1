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
        int tk = 0;
        DataTable dtTK = new DataTable();
        DataTable dt = new DataTable();
        table_TacGia data = new table_TacGia();
        public frmTacGia()
        {
            InitializeComponent();
            toolTip1.SetToolTip(btnTimKiem, "Tìm kiếm");
            toolTip1.SetToolTip(xuatExcel, "Xuất ra file Excel");
            toolTip1.SetToolTip(btnXoa, "Xóa");
            toolTip1.SetToolTip(btClear, "Hủy");
            toolTip1.SetToolTip(btnSua, "Sửa");
            toolTip1.SetToolTip(btnThem, "Thêm");
            toolTip1.SetToolTip(btnTroVe, "Trở về");
            DisplayDataTacGia();
        }
        public void DisplayDataTacGia()
        {
            try
            {
                DataSet ds = data.LayTacGia();
               
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
            dtTK.Clear();
            //dtTK.Clear();
            DisplayDataTacGia();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {

            if (tk == 0)
            {
                dtTK.Columns.Add("ID", typeof(string));
                dtTK.Columns.Add("TenTacGia", typeof(string));
                dtTK.Columns.Add("DiaChi", typeof(string));
                dtTK.Columns.Add("SDT", typeof(string));
            }
            else
            {
                dtTK.Clear();
                DisplayDataTacGia();
            }
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                if (String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[0].Value.ToString(), true) == 0
                   || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[1].Value.ToString(), true) == 0
                   || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[2].Value.ToString(), true) == 0
                   || String.Compare(txtTimKiem.Text, dgv.Rows[i].Cells[3].Value.ToString(), true) == 0)
              
                {

                    DataRow row;
                    row = dtTK.NewRow();
                    row["ID"] = dgv.Rows[i].Cells[0].Value.ToString();
                    row["TenTacGia"] = dgv.Rows[i].Cells[1].Value.ToString();
                    row["DiaChi"] = dgv.Rows[i].Cells[2].Value.ToString();
                    row["SDT"] = dgv.Rows[i].Cells[3].Value.ToString();
                    dtTK.Rows.Add(row);
                };
            }
            tk++;
            dgv.DataSource = dtTK;

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

        private void xuatExcel_Click(object sender, EventArgs e)
        {
            if (tk > 0)
            {
                Export(dtTK, "TacGia_BaiBaoKhoaHoc", "Danh sách Tác giả:");
            }
            else
                Export(dt, "TacGia_BaiBaoKhoaHoc", "Danh sách Tác giả:");
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

            cl1.Value2 = "Mã tác giả";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Tên tác giả";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Địa chỉ";
            
            cl3.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "D3");

            rowHead.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Số điện thoại";
            cl4.ColumnWidth = 25.0;

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
