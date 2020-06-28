using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Flight.BLL;
using Flight.DTO;

namespace Flight.GUI
{
    public partial class AccountForm : Form
    {
        NguoiDungBLL bllND;
        int Index;
        string TenDN;
        public AccountForm()
        {
            InitializeComponent();
            bllND = new NguoiDungBLL();
            List<string> list = bllND.GetListQuyen();
            cbQuyen.DataSource = list;
            ((DataGridViewComboBoxColumn)dgvTaiKhoan.Columns["dgvcolQuyen"]).DataSource = cbQuyen.DataSource;
            GetDataTaiKhoan();
            dgvTaiKhoan.Columns["dgvcolQuyen"].ReadOnly = true;

        }
        #region panelThemTaiKhoan
        string[] ConvertToStringArray(System.Array values)
        {
            string[] theArray = new string[values.Length];
            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(1, i) == null)
                    theArray[i - 1] = "";
                else
                    theArray[i - 1] = (string)values.GetValue(1, i).ToString();
            }
            return theArray;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            Excel.Application ExcelObj = new Excel.Application();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel files|*.xls; *.xlsx";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(dlg.FileName, 0, true, 5,
        "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
                Excel.Sheets sheets = theWorkbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
                Excel.Range UsedRange = worksheet.UsedRange;
                int lastUsedRow = UsedRange.Row + UsedRange.Rows.Count - 1;
                for (int i = 2; i <= lastUsedRow; i++)
                {
                    Excel.Range range = worksheet.get_Range("A" + i.ToString(), "C" + i.ToString());
                    System.Array value = (System.Array)range.Cells.Value;
                    string[] strArray = ConvertToStringArray(value);
                    string Quyen = strArray[2];
                    bool check = (Quyen != "Quản trị hệ thống" && Quyen != "Khác" && Quyen != "Nhân viên" && Quyen != "Quản lý");
                        if (!bllND.CheckTrungTenDN(strArray[0]) && !CheckTrungListViewTK(strArray[0]) && check)
                        listViewTK.Items.Add(new ListViewItem(strArray));
                }
            }
            lbTBThemTK.Visible = false;
        }
        public bool CheckTrungListViewTK(string TenDN)
        {
            for (int i = 0; i < listViewTK.Items.Count; i++)
                if (TenDN == listViewTK.Items[i].SubItems[0].Text)
                    return true;
            return false;
        }
        public bool CheckDataTaiKhoan()
        {
            lbTBThemTK.ForeColor = Color.Red;
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                lbTBThemTK.Visible = true;
                lbTBThemTK.Text = "Bạn chưa nhập Tên đăng nhập";
                txtTenDangNhap.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                lbTBThemTK.Visible = true;
                lbTBThemTK.Text = "Bạn chưa nhập Mật khẩu";
                txtMatKhau.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbQuyen.Text))
            {
                lbTBThemTK.Visible = true;
                lbTBThemTK.Text = "Bạn chưa chọn Quyền";
                pnThemTK.Focus();
                return false;
            }
            bool check1 = bllND.CheckTrungTenDN(txtTenDangNhap.Text);
            if (check1)
            {
                lbTBThemTK.Visible = true;
                lbTBThemTK.Text = "Tên đăng nhập này đã tồn tại";
                txtTenDangNhap.Focus();
                txtTenDangNhap.Text = "";
                return false;
            }
            bool check2 = CheckTrungListViewTK(txtTenDangNhap.Text);
            if (check2)
            {
                lbTBThemTK.Visible = true;
                lbTBThemTK.Text = "Tên đăng nhập này đã có sẵn ở ListView";
                txtTenDangNhap.Focus();
                txtTenDangNhap.Text = "";
                return false;
            }
            string Quyen = cbQuyen.Text;
            if (Quyen != "Quản trị hệ thống" && Quyen != "Khác" && Quyen != "Nhân viên" && Quyen != "Quản lý")
            {
                lbTBThemTK.Visible = true;
                lbTBThemTK.Text = "Vui lòng chọn một trong số các quyền có sẵn";
                cbQuyen.Focus();
                cbQuyen.Text = "";
                return false;
            }
            lbTBThemTK.ForeColor = Color.Green;
            return true;
        }
        public void SetEmptyTextBoxTK()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            pnThemTK.ResetText();
        }
        public string ConvertQuyenToMaNhom(string Quyen)
        {
            if (Quyen == "Quản trị hệ thống")
                return "AD";
            if (Quyen == "Khác")
                return "HK";
            if (Quyen == "Nhân viên")
                return "NV";
            if (Quyen == "Quản lý")
                return "QL";
            return null;
        }
        public void GetDataTaiKhoan()
        {
            DataTable dt = bllND.getTaiKhoan();
            dgvTaiKhoan.DataSource = dt;
            for (int i = 0; i < dgvTaiKhoan.RowCount; i++)
            {
                for (int j = 2; j < 5; j++)
                    dgvTaiKhoan.Rows[i].Cells[j].ReadOnly = true;
            }
            lbSLTK.Text = "Số lượng tài khoản hiện tại: " + bllND.GetSoLuongTaiKhoan().ToString();
        }
        private void listViewTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lsv = sender as ListView;
            if (lsv.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lsv.SelectedItems)
                {
                    txtTenDangNhap.Text = item.SubItems[0].Text;
                    txtMatKhau.Text = item.SubItems[1].Text;
                    pnThemTK.Text = item.SubItems[2].Text;
                }
            }
            btnXoa.Enabled = true;
        }

        private void btnThempanelTK_Click(object sender, EventArgs e)
        {
            if (CheckDataTaiKhoan())
            {
                string[] arr = new string[3];
                arr[0] = txtTenDangNhap.Text;
                arr[1] = txtMatKhau.Text;
                arr[2] = cbQuyen.Text;
                ListViewItem item = new ListViewItem(arr);
                listViewTK.Items.Add(item);
                SetEmptyTextBoxTK();
                lbTBThemTK.Visible = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = listViewTK.SelectedIndices;
            if (indices.Count > 0)
                listViewTK.Items.RemoveAt(indices[0]);
            SetEmptyTextBoxTK();
            btnXoa.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            pnThemTK.Visible = false;
            SetEmptyTextBoxTK();
            listViewTK.Items.Clear();
            lbTBThemTK.Visible = false;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            int n = listViewTK.Items.Count;
            if (n == 0)
            {
                lbTBThemTK.Visible = true;
                lbTBThemTK.ForeColor = Color.Red;
                lbTBThemTK.Text = "Vui lòng thêm ít nhất một tài khoản";
            }
            else
            {
                NguoiDung[] user = new NguoiDung[n];
                for (int i = 0; i < n; i++)
                {
                    user[i] = new NguoiDung
                    {
                        TenDangNhap = listViewTK.Items[i].SubItems[0].Text,
                        MatKhau = listViewTK.Items[i].SubItems[1].Text,
                        MaNhom = ConvertQuyenToMaNhom(listViewTK.Items[i].SubItems[2].Text)
                    };
                }
                if (bllND.InsertTaiKhoan(user, n))
                {
                    lbTBThemTK.Visible = true;
                    lbTBThemTK.ForeColor = Color.Green;
                    lbTBThemTK.Text = "Thêm thông tin tài khoản thành công";
                    SetEmptyTextBoxTK();
                    listViewTK.Items.Clear();
                    GetDataTaiKhoan();
                }
            }
        }

        private void txtTenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
        #region TaiKhoan
        private void btnThemTK_Click(object sender, EventArgs e)
        {
            pnThemTK.Visible = true;
            txtTenDangNhap.Focus();
            btnXoa.Enabled = false;
            lbTBThemTK.Visible = false;
        }
        public string ConvertMaNhomToQuyen(string MaNhom)
        {
            if (MaNhom == "AD")
                return "Quản trị hệ thống";
            if (MaNhom == "HK")
                return "Khác";
            if (MaNhom == "NV")
                return "Nhân viên";
            if (MaNhom == "QL")
                return "Quản lý";
            return null;
        }
        public void ShowData1TaiKhoan()
        {
            NguoiDung ND = bllND.GetInfo1TaiKhoan(TenDN);
            dgvTaiKhoan.Rows[Index].Cells["dgvcolMatKhau"].Value = ND.MatKhau;
            dgvTaiKhoan.Rows[Index].Cells["dgvcolQuyen"].Value = ConvertMaNhomToQuyen(ND.MaNhom);
        }
        public bool CheckInputDataGridTK()
        {
            lbThongBao.ForeColor = Color.Red;
            if (string.IsNullOrWhiteSpace(dgvTaiKhoan.Rows[Index].Cells["dgvcolMatKhau"].Value.ToString()))
            {
                lbThongBao.Visible = true;
                dgvTaiKhoan.CurrentCell = dgvTaiKhoan.Rows[Index].Cells["dgvcolMatKhau"];
                lbThongBao.Text = "Bạn chưa nhập mật khẩu";
                return false;
            }
            if (string.IsNullOrWhiteSpace(dgvTaiKhoan.Rows[Index].Cells["dgvcolQuyen"].Value.ToString()))
            {
                lbThongBao.Visible = true;
                dgvTaiKhoan.CurrentCell = dgvTaiKhoan.Rows[Index].Cells["dgvcolQuyen"];
                lbThongBao.Text = "Bạn chưa chọn quyền";
                return false;
            }
            string Quyen = dgvTaiKhoan.Rows[Index].Cells["dgvcolQuyen"].Value.ToString();
            if (Quyen != "Quản trị hệ thống" && Quyen != "Khác" && Quyen != "Nhân viên" && Quyen != "Quản lý")
            {
                lbThongBao.Visible = true;
                dgvTaiKhoan.CurrentCell = dgvTaiKhoan.Rows[Index].Cells["dgvcolQuyen"];
                lbThongBao.Text = "Vui lòng chọn một trong số các quyền có sẵn";
                return false;
            }
            lbThongBao.ForeColor = Color.Green;
            return true;
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TenDN = dgvTaiKhoan.Rows[Index].Cells["dgvcolTenDangNhap"].Value.ToString();
            if (Index == dgvTaiKhoan.RowCount - 1)
                return;
            // Click Delete Icon
            if (e.ColumnIndex == 1)
            {
                if (dgvTaiKhoan.Rows[Index].Cells["dgvcolMatKhau"].ReadOnly)
                {
                    DialogResult dlg = MessageBox.Show("Bạn có thật sự muốn xóa thông tin tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.Yes)
                    {
                        if (bllND.DeleteNguoiDung(dgvTaiKhoan.Rows[Index].Cells["dgvcolTenDangNhap"].Value.ToString()))
                        {
                            dgvTaiKhoan.Rows.Remove(dgvTaiKhoan.Rows[Index]);
                            lbThongBao.Visible = true;
                            lbThongBao.ForeColor = Color.Green;
                            lbThongBao.Text = "Xoá tài khoản thành công";
                            lbSLTK.Text = "Số lượng tài khoản hiện tại: " + bllND.GetSoLuongTaiKhoan().ToString();
                        }
                        else
                        {
                            lbThongBao.ForeColor = Color.Red;
                            lbThongBao.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                        }
                    }
                }
                else
                {
                    ShowData1TaiKhoan();
                    dgvTaiKhoan.Rows[Index].Cells[0].Value = global::Flight.Properties.Resources.edit;
                    dgvTaiKhoan.Rows[Index].Cells[1].Value = global::Flight.Properties.Resources.rubbish_bin;
                    dgvTaiKhoan.Rows[Index].Cells["dgvcolMatKhau"].ReadOnly = true;
                    dgvTaiKhoan.Rows[Index].Cells["dgvcolQuyen"].ReadOnly = true;
                }
            }
            //Click Edit Icon
            else if (e.ColumnIndex == 0)
            {
                if (dgvTaiKhoan.Rows[Index].Cells["dgvcolMatKhau"].ReadOnly)
                {
                    dgvTaiKhoan.Rows[Index].Cells[0].Value = global::Flight.Properties.Resources.save;
                    dgvTaiKhoan.Rows[Index].Cells[1].Value = global::Flight.Properties.Resources.close;
                    dgvTaiKhoan.Rows[Index].Cells["dgvcolMatKhau"].ReadOnly = false;
                    dgvTaiKhoan.Rows[Index].Cells["dgvcolQuyen"].ReadOnly = false;
                }
                else
                {
                    if (CheckInputDataGridTK())
                    {
                        dgvTaiKhoan.Rows[Index].Cells["dgvcolMatKhau"].ReadOnly = true;
                        dgvTaiKhoan.Rows[Index].Cells["dgvcolQuyen"].ReadOnly = true;
                    }
                    string TenDangNhap = dgvTaiKhoan.Rows[Index].Cells["dgvcolTenDangNhap"].Value.ToString();
                    string MatKhau = dgvTaiKhoan.Rows[Index].Cells["dgvcolMatKhau"].Value.ToString();
                    string MaNhom = ConvertQuyenToMaNhom(dgvTaiKhoan.Rows[Index].Cells["dgvcolQuyen"].Value.ToString());
                    if (bllND.UpdateTaiKhoan(TenDangNhap, MatKhau, MaNhom))
                    {
                        lbThongBao.Visible = true;
                        lbThongBao.ForeColor = Color.Green;
                        lbThongBao.Text = "Lưu thông tin tài khoản thành công";
                    }
                    else
                    {
                        lbThongBao.ForeColor = Color.Red;
                        lbThongBao.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                    }
                    dgvTaiKhoan.Rows[Index].Cells[0].Value = global::Flight.Properties.Resources.edit;
                    dgvTaiKhoan.Rows[Index].Cells[1].Value = global::Flight.Properties.Resources.rubbish_bin;
                }
            }
        }
        #endregion

        private void dgvTaiKhoan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                e.ThrowException = false;
            }
        }

        private void dgvTaiKhoan_CurrentCellChanged(object sender, EventArgs e)
        {
            lbThongBao.Text = "";
            try
            {
                if (Index == dgvTaiKhoan.CurrentCell.RowIndex)
                    return;
                Index = dgvTaiKhoan.CurrentCell.RowIndex;
            }
            catch
            {
                return;
            }
            if (Index == dgvTaiKhoan.RowCount - 1)
                return;
        }
    }
}
