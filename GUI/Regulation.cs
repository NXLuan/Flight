using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flight.BLL;
using Flight.DTO;
using Excel = Microsoft.Office.Interop.Excel;
namespace Flight.GUI
{
    public partial class Regulation : Form
    {
        ThamSoBLL bllTS;
        SanBayBLL bllSB;
        DanhSachVeBLL bllDSV;
        int IndexSB;
        string MaSanBay;
        int IndexDSV;
        string HangVe;
        public Regulation()
        {
            InitializeComponent();
            bllTS = new ThamSoBLL();
            bllSB = new SanBayBLL();
            bllDSV = new DanhSachVeBLL();
            ShowPageThamSo();
            GetDataThamSo();
            SetEnablePageThamSo(false);
        }
        #region ThaoTacChung
        public void ShowPageThamSo()
        {
            pnThamSo.Visible = true;
            pnSanBay.Visible = false;
            pnHangVe.Visible = false;
            Page.SetPage("tabThamSo");
        }
        public void ShowPageSanBay()
        {
            pnThamSo.Visible = false;
            pnSanBay.Visible = true;
            pnHangVe.Visible = false;
            Page.SetPage("tabSanBay");
        }
        public void ShowPageHangVe()
        {
            pnThamSo.Visible = false;
            pnSanBay.Visible = false;
            pnHangVe.Visible = true;
            Page.SetPage("tabHangVe");
        }

        private void lbThamSo_Click(object sender, EventArgs e)
        {
            ShowPageThamSo();
        }

        private void lbSanBay_Click(object sender, EventArgs e)
        {
            ShowPageSanBay();
            GetDataSanBay();

        }
        private void lbHangVe_Click(object sender, EventArgs e)
        {
            ShowPageHangVe();
            GetDataDanhSachVe();
        }
        #endregion
        #region pageThamSo
        public void GetDataThamSo()
        {
            DataTable dt = bllTS.getThamSo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["TenThamSo"].ToString() == "ThoiGianBayToiThieu")
                    txtTGBay.Text = dt.Rows[i]["GiaTri"].ToString();
                else if (dt.Rows[i]["TenThamSo"].ToString() == "SoSanBayTrungGianToiDa")
                    txtSLSanBay.Text = dt.Rows[i]["GiaTri"].ToString();
                else if (dt.Rows[i]["TenThamSo"].ToString() == "ThoiGianDungToiThieu")
                    txtTGDMin.Text = dt.Rows[i]["GiaTri"].ToString();
                else if (dt.Rows[i]["TenThamSo"].ToString() == "ThoiGianDungToiDa")
                    txtTGDMax.Text = dt.Rows[i]["GiaTri"].ToString();
                else if (dt.Rows[i]["TenThamSo"].ToString() == "ThoiGianChoPhepDatVe")
                    txtSoNgay.Text = dt.Rows[i]["GiaTri"].ToString();
                else if (dt.Rows[i]["TenThamSo"].ToString() == "ChoPhepHuyVe")
                {
                    if (dt.Rows[i]["GiaTri"].ToString() == "1")
                        checkboxHuy.Checked = true;
                    else
                        checkboxHuy.Checked = false;
                }
            }
        }
        public void SetEnablePageThamSo(bool status)
        {
            txtTGBay.Enabled = status;
            txtSLSanBay.Enabled = status;
            txtTGDMin.Enabled = status;
            txtTGDMax.Enabled = status;
            txtSoNgay.Enabled = status;
            checkboxHuy.Enabled = status;
            btnSuaTS.Enabled = !status;
            btnLuuTS.Enabled = status;
        }
        public bool CheckDataThamSo()
        {
            if (string.IsNullOrEmpty(txtTGBay.Text))
            {
                txtTGBay.Focus();
                lbTBpanelTS.Visible = true;
                lbTBpanelTS.Text = "Bạn chưa nhập thời gian bay";
                lbTBpanelTS.ForeColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(txtSLSanBay.Text))
            {
                txtSLSanBay.Focus();
                lbTBpanelTS.Visible = true;
                lbTBpanelTS.Text = "Bạn chưa nhập số lượng sân bay";
                lbTBpanelTS.ForeColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(txtTGDMin.Text))
            {
                txtTGDMin.Focus();
                lbTBpanelTS.Visible = true;
                lbTBpanelTS.Text = "Bạn chưa nhập thời gian dừng tối thiểu";
                lbTBpanelTS.ForeColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(txtTGDMax.Text))
            {
                txtTGDMax.Focus();
                lbTBpanelTS.Visible = true;
                lbTBpanelTS.Text = "Bạn chưa nhập thời gian dừng tối đa";
                lbTBpanelTS.ForeColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(txtSoNgay.Text))
            {
                txtSoNgay.Focus();
                lbTBpanelTS.Visible = true;
                lbTBpanelTS.Text = "Bạn chưa nhập số ngày cho đặt vé chậm nhất";
                lbTBpanelTS.ForeColor = Color.Red;
                return false;
            }
            int Min = int.Parse(txtTGDMin.Text);
            int Max = int.Parse(txtTGDMax.Text);
            if (Min >= Max)
            {
                txtTGDMin.Focus();
                lbTBpanelTS.Visible = true;
                lbTBpanelTS.Text = "Thời gian dừng tối thiểu phải bé hơn thời gian dừng tối đa";
                lbTBpanelTS.ForeColor = Color.Red;
                return false;
            }
            return true;
        }
        public bool UpdateDataThamSo()
        {
            ThamSo[] thamso = new ThamSo[6];
            for (int i = 0; i < 6; i++)
                thamso[i] = new ThamSo();
            thamso[0].TenThamSo = "ThoiGianBayToiThieu";
            thamso[0].GiaTri = Int32.Parse(txtTGBay.Text);
            thamso[1].TenThamSo = "SoSanBayTrungGianToiDa";
            thamso[1].GiaTri = Int32.Parse(txtSLSanBay.Text);
            thamso[2].TenThamSo = "ThoiGianDungToiThieu";
            thamso[2].GiaTri = Int32.Parse(txtTGDMin.Text);
            thamso[3].TenThamSo = "ThoiGianDungToiDa";
            thamso[3].GiaTri = Int32.Parse(txtTGDMax.Text);
            thamso[4].TenThamSo = "ThoiGianChoPhepDatVe";
            thamso[4].GiaTri = Int32.Parse(txtSoNgay.Text);
            thamso[5].TenThamSo = "ChoPhepHuyVe";
            if (checkboxHuy.Checked)
            {
                thamso[5].GiaTri = 1;
            }
            else thamso[5].GiaTri = 0;
            return bllTS.setThamSo(thamso, 6);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SetEnablePageThamSo(true);
            lbTBpanelTS.Visible = false;
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (CheckDataThamSo())
            {
                if (UpdateDataThamSo())
                {
                    lbTBpanelTS.Text = "Cập nhật các quy định thành công!";
                    lbTBpanelTS.Visible = true;
                    lbTBpanelTS.ForeColor = Color.Green;
                }
                SetEnablePageThamSo(false);
            }
        }
        #endregion
        #region panelThemSanBay
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
        private void btnChonFileSB_Click(object sender, EventArgs e)
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
                    Excel.Range range = worksheet.get_Range("A" + i.ToString(), "B" + i.ToString());
                    System.Array value = (System.Array)range.Cells.Value;
                    string[] strArray = ConvertToStringArray(value);
                    if (!bllSB.CheckTrungMaSB(strArray[0]) && !CheckTrungListViewSB(strArray[0]))
                        listViewSB.Items.Add(new ListViewItem(strArray));
                }
            }
        }
        public bool CheckTrungListViewSB(string MaSB)
        {
            for (int i = 0; i < listViewSB.Items.Count; i++)
                if (MaSB == listViewSB.Items[i].SubItems[0].Text)
                    return true;
            return false;
        }
        public bool CheckDataSanBay()
        {
            lbTBThemSB.ForeColor = Color.Red;
            if (string.IsNullOrEmpty(txtMaSanBay.Text))
            {
                lbTBThemSB.Visible = true;
                lbTBThemSB.Text = "Bạn chưa nhập mã sân bay";
                txtMaSanBay.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenSanBay.Text))
            {
                lbTBThemSB.Visible = true;
                lbTBThemSB.Text = "Bạn chưa nhập tên sân bay";
                txtTenSanBay.Focus();
                return false;
            }
            bool check1 = bllSB.CheckTrungMaSB(txtMaSanBay.Text);
            if (check1)
            {
                lbTBThemSB.Visible = true;
                lbTBThemSB.Text = "Mã sân bay này đã tồn tại";
                txtMaSanBay.Focus();
                txtMaSanBay.Text = "";
                return false;
            }
            bool check2 = CheckTrungListViewSB(txtMaSanBay.Text);
            if (check2)
            {
                lbTBThemSB.Visible = true;
                lbTBThemSB.Text = "Mã sân bay này đã có sẵn ở ListView";
                txtMaSanBay.Focus();
                txtMaSanBay.Text = "";
                return false;
            }
            lbTBThemSB.ForeColor = Color.Green;
            return true;
        }
        public void SetEmptyTextBoxSB()
        {
            txtMaSanBay.Text = "";
            txtTenSanBay.Text = "";
            txtMaSanBay.Focus();
        }

        private void listViewSB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lsv = sender as ListView;
            if (lsv.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lsv.SelectedItems)
                {
                    txtMaSanBay.Text = item.SubItems[0].Text;
                    txtTenSanBay.Text = item.SubItems[1].Text;
                }
            }
            btnXoaSBpanel.Enabled = true;
        }
        private void btnThemSBpanel_Click_1(object sender, EventArgs e)
        {
            if (CheckDataSanBay())
            {
                string[] arr = new string[2];
                arr[0] = txtMaSanBay.Text;
                arr[1] = txtTenSanBay.Text;
                ListViewItem item = new ListViewItem(arr);
                listViewSB.Items.Add(item);
                SetEmptyTextBoxSB();
                lbTBpanelSB.Visible = false;
            }
        }

        private void btnXoaSBpanel_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = listViewSB.SelectedIndices;
            if (indices.Count > 0)
                listViewSB.Items.RemoveAt(indices[0]);
            SetEmptyTextBoxSB();
            btnXoaSBpanel.Enabled = false;
        }

        private void btnLuupanel_Click(object sender, EventArgs e)
        {
            int n = listViewSB.Items.Count;
            SanBay[] sanbay = new SanBay[n];
            for (int i = 0; i < n; i++)
            {
                sanbay[i] = new SanBay
                {
                    MaSanBay = listViewSB.Items[i].SubItems[0].Text,
                    TenSanBay = listViewSB.Items[i].SubItems[1].Text
                };
            }
            if (bllSB.InsertSanBay(sanbay, n))
            {
                lbTBThemSB.Visible = true;
                lbTBThemSB.ForeColor = Color.Green;
                lbTBThemSB.Text = "Thêm thông tin sân bay thành công";
                SetEmptyTextBoxSB();
                listViewSB.Items.Clear();
                GetDataSanBay();
            }
        }
        #endregion
        #region pageSanBay
        public void GetDataSanBay()
        {
            DataTable dt = bllSB.getSanBay();
            dgvSanBay.DataSource = dt;
            for (int i = 0; i < dgvSanBay.RowCount; i++)
                dgvSanBay.Rows[i].ReadOnly = true;
            lbSLSB.Text = "Số lượng sân bay hiện tại: " + bllSB.GetSoLuongSanBay().ToString();
        }
        private SanBay SetInfoSanBayFromGridView()
        {
            SanBay sb = new SanBay
            {
                MaSanBay = dgvSanBay.Rows[IndexSB].Cells["dgvcolMaSanBay"].Value.ToString(),
                TenSanBay = dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"].Value.ToString()
            };
            return sb;
        }
        public void ShowData1SanBay()
        {
            SanBay sb = bllSB.GetInfo1SanBay(MaSanBay);
            dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"].Value = sb.TenSanBay;
        }
        public bool CheckInputDataGridSB()
        {
            lbTBpanelSB.ForeColor = Color.Red;
            if (string.IsNullOrWhiteSpace(dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"].Value.ToString()))
            {
                lbTBpanelSB.Visible = true;
                dgvSanBay.CurrentCell = dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"];
                lbTBpanelSB.Text = "Bạn chưa nhập Tên sân bay";
                return false;
            }
            lbTBpanelSB.ForeColor = Color.Green;
            return true;
        }

        private void dgvSanBay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MaSanBay = dgvSanBay.Rows[IndexSB].Cells["dgvcolMaSanBay"].Value.ToString();
            if (IndexSB == dgvSanBay.RowCount - 1)
                return;
            // Click Delete Icon
            if (e.ColumnIndex == 1)
            {
                if (dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"].ReadOnly)
                {
                    DialogResult dlg = MessageBox.Show("Bạn có thật sự muốn xóa thông tin sân bay này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.Yes)
                    {
                        if (bllSB.DeleteSanBay(dgvSanBay.Rows[IndexSB].Cells["dgvcolMaSanBay"].Value.ToString()))
                        {
                            dgvSanBay.Rows.Remove(dgvSanBay.Rows[IndexSB]);
                            lbTBpanelSB.Visible = true;
                            lbTBpanelSB.ForeColor = Color.Green;
                            lbTBpanelSB.Text = "Xoá sân bay thành công";
                            lbSLSB.Text = "Số lượng sân bay hiện tại: " + bllSB.GetSoLuongSanBay().ToString();
                        }
                        else
                        {
                            lbTBpanelSB.ForeColor = Color.Red;
                            lbTBpanelSB.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                        }
                    }
                }
                else
                {
                    ShowData1SanBay();
                    dgvSanBay.Rows[IndexSB].Cells[0].Value = global::Flight.Properties.Resources.edit;
                    dgvSanBay.Rows[IndexSB].Cells[1].Value = global::Flight.Properties.Resources.rubbish_bin;
                    dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"].ReadOnly = true;
                }
            }
            //Click Edit Icon
            else if (e.ColumnIndex == 0)
            {
                if (dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"].ReadOnly)
                {
                    dgvSanBay.Rows[IndexSB].Cells[0].Value = global::Flight.Properties.Resources.save;
                    dgvSanBay.Rows[IndexSB].Cells[1].Value = global::Flight.Properties.Resources.close;
                    dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"].ReadOnly = false;
                }
                else
                {
                    if (CheckInputDataGridSB())
                    {
                        dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"].ReadOnly = true;
                        string MaSB = dgvSanBay.Rows[IndexSB].Cells["dgvcolMaSanBay"].Value.ToString();
                        string TenSB = dgvSanBay.Rows[IndexSB].Cells["dgvcolTenSanBay"].Value.ToString();
                        if (bllSB.UpdateSanBay(MaSB, TenSB))
                        {
                            lbTBpanelSB.Visible = true;
                            lbTBpanelSB.Text = "Lưu thông tin sân bay thành công";
                        }
                        else
                        {
                            lbTBpanelSB.ForeColor = Color.Red;
                            lbTBpanelSB.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                        }
                        dgvSanBay.Rows[IndexSB].Cells[0].Value = global::Flight.Properties.Resources.edit;
                        dgvSanBay.Rows[IndexSB].Cells[1].Value = global::Flight.Properties.Resources.rubbish_bin;
                    }
                }
            }
        }

        private void dgvSanBay_CurrentCellChanged(object sender, EventArgs e)
        {
            lbTBpanelSB.Text = "";
            try
            {
                if (IndexSB == dgvSanBay.CurrentCell.RowIndex)
                    return;
                IndexSB = dgvSanBay.CurrentCell.RowIndex;
            }
            catch
            {
                return;
            }
            if (IndexSB == dgvSanBay.RowCount - 1)
                return;
        }
        #endregion
        #region panelThemHangVe
        private void btnChonFileDSV_Click(object sender, EventArgs e)
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
                    Excel.Range range = worksheet.get_Range("A" + i.ToString(), "B" + i.ToString());
                    System.Array value = (System.Array)range.Cells.Value;
                    string[] strArray = ConvertToStringArray(value);
                    if (!bllDSV.CheckTrungHangVe(strArray[0]) && !CheckTrungListViewHangVe(strArray[0]) && Double.TryParse(strArray[1], out double result))
                        listViewVe.Items.Add(new ListViewItem(strArray));
                }
            }
        }

        public bool CheckTrungListViewHangVe(string HangVe)
        {
            for (int i = 0; i < listViewVe.Items.Count; i++)
                if (HangVe == listViewVe.Items[i].SubItems[0].Text)
                    return true;
            return false;
        }
        public bool CheckDataDSVe()
        {
            lbThemDSV.ForeColor = Color.Red;
            if (string.IsNullOrEmpty(txtHangVe.Text))
            {
                lbThemDSV.Visible = true;
                lbThemDSV.Text = "Bạn chưa nhập hạng vé";
                txtHangVe.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTiLe.Text))
            {
                lbThemDSV.Visible = true;
                lbThemDSV.Text = "Bạn chưa nhập tỉ lệ";
                txtTiLe.Focus();
                return false;
            }
            bool check1 = bllDSV.CheckTrungHangVe(txtHangVe.Text);
            if (check1)
            {
                lbThemDSV.Visible = true;
                lbThemDSV.Text = "Hạng vé này đã tồn tại";
                txtHangVe.Focus();
                txtHangVe.Text = "";
                return false;
            }
            bool check2 = CheckTrungListViewHangVe(txtHangVe.Text);
            if (check2)
            {
                lbThemDSV.Visible = true;
                lbThemDSV.Text = "Hạng vé này đã có sẵn ở ListView";
                txtHangVe.Focus();
                txtHangVe.Text = "";
                return false;
            }
            lbThemDSV.ForeColor = Color.Green;
            return true;
        }
        public void SetEmptyTextBoxDSV()
        {
            txtHangVe.Text = "";
            txtTiLe.Text = "";
            txtHangVe.Focus();
        }

        private void listViewVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lsv = sender as ListView;
            if (lsv.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lsv.SelectedItems)
                {
                    txtHangVe.Text = item.SubItems[0].Text;
                    txtTiLe.Text = item.SubItems[1].Text;
                }
            }
            btnXoapanelVe.Enabled = true;
        }
        private void btnThempanelVe_Click(object sender, EventArgs e)
        {
            if (CheckDataDSVe())
            {
                string[] arr = new string[2];
                arr[0] = txtHangVe.Text;
                arr[1] = txtTiLe.Text;
                ListViewItem item = new ListViewItem(arr);
                listViewVe.Items.Add(item);
                SetEmptyTextBoxDSV();
                lbThemDSV.Visible = false;
            }
        }

        private void btnXoapanelVe_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = listViewVe.SelectedIndices;
            if (indices.Count > 0)
                listViewVe.Items.RemoveAt(indices[0]);
            SetEmptyTextBoxDSV();
            btnXoapanelVe.Enabled = false;
        }

        private void btnLuupanelVe_Click(object sender, EventArgs e)
        {
            int n = listViewVe.Items.Count;
            DanhSachVe[] dsv = new DanhSachVe[n];
            for (int i = 0; i < n; i++)
            {
                dsv[i] = new DanhSachVe
                {
                    HangVe = listViewVe.Items[i].SubItems[0].Text,
                    TiLe = float.Parse(listViewVe.Items[i].SubItems[1].Text)
                };
            }
            if (bllDSV.InsertHangVe(dsv, n))
            {
                lbThemDSV.Visible = true;
                lbThemDSV.ForeColor = Color.Green;
                lbThemDSV.Text = "Thêm thông tin hạng vé thành công";
                SetEmptyTextBoxDSV();
                listViewVe.Items.Clear();
                GetDataDanhSachVe();
            }
        }
        private void txtTiLe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&  !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion
        #region pageHangVe
        public void GetDataDanhSachVe()
        {
            DataTable dt = bllDSV.getDanhSachVe();
            dgvDanhSachVe.DataSource = dt;
            for (int i = 0; i < dgvDanhSachVe.RowCount; i++)
                dgvDanhSachVe.Rows[i].ReadOnly = true;
            lbSLVe.Text = "Số lượng hạng vé hiện tại: " + bllDSV.GetSoLuongHangVe().ToString();
        }

        private DanhSachVe SetInfoDSVFromGridView()
        {
            DanhSachVe dsv = new DanhSachVe
            {
                HangVe = dgvDanhSachVe.Rows[IndexSB].Cells["dgvcolHangVe"].Value.ToString(),
                TiLe = float.Parse(dgvDanhSachVe.Rows[IndexSB].Cells["dgvcolTiLe"].Value.ToString())
            };
            return dsv;
        }
        public void ShowData1HangVe()
        {
            DanhSachVe dsv = bllDSV.GetInfo1HangVe(HangVe);
            dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolTiLe"].Value = dsv.TiLe.ToString();
        }
        public bool CheckInputDataGridDSV()
        {
            lbThemDSV.ForeColor = Color.Red;
            if (string.IsNullOrWhiteSpace(dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolTiLe"].Value.ToString()))
            {
                lbThemDSV.Visible = true;
                dgvDanhSachVe.CurrentCell = dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolTiLe"];
                lbThemDSV.Text = "Bạn chưa nhập Tỉ lệ";
                return false;
            }
            lbThemDSV.ForeColor = Color.FromArgb(8, 186, 29);
            return true;
        }
        private void dgvDanhSachVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HangVe = dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolHangVe"].Value.ToString();
            if (IndexDSV == dgvDanhSachVe.RowCount - 1)
                return;
            // Click Delete Icon
            if (e.ColumnIndex == 1)
            {
                if (dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolTiLe"].ReadOnly)
                {
                    DialogResult dlg = MessageBox.Show("Bạn có thật sự muốn xóa thông tin hạng vé này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.Yes)
                    {
                        if (bllDSV.DeleteHangVe(dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolHangVe"].Value.ToString()))
                        {
                            dgvDanhSachVe.Rows.Remove(dgvDanhSachVe.Rows[IndexDSV]);
                            lbTBpanelDSV.Visible = true;
                            lbTBpanelDSV.ForeColor = Color.Green;
                            lbTBpanelDSV.Text = "Xoá hạng vé thành công";
                            lbSLVe.Text = "Số lượng hạng vé hiện tại: " + bllDSV.GetSoLuongHangVe().ToString();
                        }
                        else
                        {
                            lbTBpanelDSV.ForeColor = Color.Red;
                            lbTBpanelDSV.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                        }
                    }
                }
                else
                {
                    ShowData1HangVe();
                    dgvDanhSachVe.Rows[IndexDSV].Cells[0].Value = global::Flight.Properties.Resources.edit;
                    dgvDanhSachVe.Rows[IndexDSV].Cells[1].Value = global::Flight.Properties.Resources.rubbish_bin;
                    dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolTiLe"].ReadOnly = true;
                }
            }
            //Click Edit Icon
            else if (e.ColumnIndex == 0)
            {
                if (dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolTiLe"].ReadOnly)
                {
                    dgvDanhSachVe.Rows[IndexDSV].Cells[0].Value = global::Flight.Properties.Resources.save;
                    dgvDanhSachVe.Rows[IndexDSV].Cells[1].Value = global::Flight.Properties.Resources.close;
                    dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolTiLe"].ReadOnly = false;
                }
                else
                {
                    if (CheckInputDataGridDSV())
                    {
                        dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolTiLe"].ReadOnly = true;
                        string HangVe = dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolHangVe"].Value.ToString();
                        string TiLe = dgvDanhSachVe.Rows[IndexDSV].Cells["dgvcolTiLe"].Value.ToString();
                        if (bllDSV.UpdateDanhSachVe(HangVe, TiLe))
                        {
                            lbTBpanelDSV.Visible = true;
                            lbTBpanelDSV.Text = "Lưu thông tin sân bay thành công";
                        }
                        else
                        {
                            lbTBpanelDSV.ForeColor = Color.Red;
                            lbTBpanelDSV.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                        }
                        dgvDanhSachVe.Rows[IndexDSV].Cells[0].Value = global::Flight.Properties.Resources.edit;
                        dgvDanhSachVe.Rows[IndexDSV].Cells[1].Value = global::Flight.Properties.Resources.rubbish_bin;
                    }
                }
            }
        }

        private void dgvDanhSachVe_CurrentCellChanged(object sender, EventArgs e)
        {
            lbTBpanelDSV.Text = "";
            try
            {
                if (IndexDSV == dgvDanhSachVe.CurrentCell.RowIndex)
                    return;
                IndexDSV = dgvDanhSachVe.CurrentCell.RowIndex;
            }
            catch
            {
                return;
            }
            if (IndexDSV == dgvSanBay.RowCount - 1)
                return;
        }
        private void dgvDanhSachVe_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dgvDanhSachVe_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(dgvDanhSachVe_KeyPress);
        }
        private void dgvDanhSachVe_KeyPress(object sender, KeyPressEventArgs e)
        {
            int col = dgvDanhSachVe.CurrentCell.ColumnIndex;
            if (dgvDanhSachVe.Columns[col].Name == "dgvcolTiLe")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
        }
        #endregion
    }
}
