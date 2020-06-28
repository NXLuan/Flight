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
using Excel = Microsoft.Office.Interop.Excel;

namespace Flight.GUI
{
    public partial class ReportForm : Form
    {
        BaoCaoBLL bllBaoCao;
        public ReportForm()
        {
            bllBaoCao = new BaoCaoBLL();
            InitializeComponent();
            ShowMonthReport();
            SetItemComboBox();
    
        }
        #region ThaoTacChung
        public void ShowMonthReport()
        {
            pnMonth.Visible = true;
            pnYear.Visible = false;
            Page.SetPage("tabMonth");
            SetVisibleLabelChiTietpnMonth(false);
        }
        public void ShowYearReport()
        {
            pnMonth.Visible = false;
            pnYear.Visible = true;
            Page.SetPage("tabYear");
            SetVisibleLabelChiTietpnYear(false);
        }
        private void lbMonth_Click(object sender, EventArgs e)
        {
            if (lbMonth.ForeColor == Color.Black) return;
            lbMonth.ForeColor = Color.Black;
            lbYear.ForeColor= Color.Gray;
            ShowMonthReport();
            ClearDataPageMonth();
        }
        private void lbYear_Click(object sender, EventArgs e)
        {
            if (lbYear.ForeColor == Color.Black) return;
            lbMonth.ForeColor = Color.Gray;
            lbYear.ForeColor = Color.Black;
            ClearDataBarChart();
            ShowYearReport();
        }
        #endregion
        #region PageMonth
        public void ClearDataPageMonth()
        {
            dgvThang.DataSource = null;
            SetVisibleLabelChiTietpnMonth(false);
        }
        public void SetItemComboBox()
        {
            for (int i = 1; i <= 12; i++)
                cbThang.Items.Add(i.ToString());
            for (int i = 2010; i <= 2020; i++)
            {
                cbNam.Items.Add(i.ToString());
                cbNampanelYear.Items.Add(i.ToString());
            }
        }
        public bool CheckDataComboBoxpnMonth()
        {
            lbTBpanelThang.ForeColor = Color.Red;
            if (string.IsNullOrWhiteSpace(cbThang.Text))
            {
                lbTBpanelThang.Text = "Bạn chưa chọn Tháng";
                lbTBpanelThang.Visible = true;
                cbThang.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbNam.Text))
            {
                lbTBpanelThang.Text = "Bạn chưa chọn Năm";
                lbTBpanelThang.Visible = true;
                cbNam.Focus();
                return false;
            }
            int ThangInput = int.Parse(cbThang.Text);
            if (ThangInput < 1 || ThangInput > 12)
            {
                lbTBpanelThang.Text = "Vui lòng nhập Tháng trong khoảng từ 1 đến 12";
                lbTBpanelThang.Visible = true;
                cbThang.Focus();
                return false;
            }
            int NamInput = int.Parse(cbNam.Text);
            if (NamInput < 2010 || NamInput > 2020)
            {
                lbTBpanelThang.Text = "Vui lòng nhập Năm trong khoảng từ 2010 đến 2020";
                lbTBpanelThang.Visible = true;
                cbNam.Focus();
                return false;
            }
            return true;
        }
        public void SetVisibleLabelChiTietpnMonth(bool status)
        {
            lbThangNam.Visible = status;
            lbTongChuyenBay.Visible = status;
            lbTongSoVe.Visible = status;
            lbTongDoanhThuThang.Visible = status;
            lbCBCaoNhat.Visible = status;
            lbCBThapNhat.Visible = status;
        }
        public void HienThongTinChiTietpnMonth()
        {
            SetVisibleLabelChiTietpnMonth(true);
            lbThangNam.Text = cbThang.Text + "/" + cbNam.Text;
            int n = dgvThang.Rows.Count;
            lbTongChuyenBay.Text = (n-1).ToString();
            int TongSoVe = 0;
            int TongDoanhThu = 0;
            string MaCBMax = "", MaCBMin = "";
            int DoanhThuMax = 0, DoanhThuMin = 0;
            if (n > 1)
            {
                DoanhThuMin = int.MaxValue;
                for (int i = 0; i < n - 1; i++)
                {
                    TongSoVe += int.Parse(dgvThang.Rows[i].Cells["colSoVe"].Value.ToString());
                    int DoanhThu = int.Parse(dgvThang.Rows[i].Cells["colDoanhThu"].Value.ToString());
                    TongDoanhThu += DoanhThu;
                    if (DoanhThu >= DoanhThuMax)
                    {
                        DoanhThuMax = DoanhThu;
                        MaCBMax = dgvThang.Rows[i].Cells["colMaChuyenBay"].Value.ToString();
                    }
                    if (DoanhThu <= DoanhThuMin)
                    {
                        DoanhThuMin = DoanhThu;
                        MaCBMin = dgvThang.Rows[i].Cells["colMaChuyenBay"].Value.ToString();
                    }
                }
            }   
            lbTongSoVe.Text = TongSoVe.ToString();
            lbTongDoanhThuThang.Text = TongDoanhThu.ToString() + "VND";
            lbCBCaoNhat.Text = DoanhThuMax.ToString() + "VND(" + MaCBMax + ")";
            lbCBThapNhat.Text = DoanhThuMin.ToString() + "VND(" + MaCBMin + ")";
        }
        private void cbThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btReservate_Click(object sender, EventArgs e)
        {
            if (CheckDataComboBoxpnMonth())
            {
                btnExcel.Visible = true;
                string MaBaoCao = "BC" + cbThang.Text + cbNam.Text;
                if (!bllBaoCao.CheckTrungMaBaoCao(MaBaoCao))
                    bllBaoCao.LuuDoanhThuThang(cbThang.Text, cbNam.Text);
                DataTable dt = bllBaoCao.GetDoanhThuThangCoTiLe(cbThang.Text, cbNam.Text);
                dgvThang.DataSource = dt;
                HienThongTinChiTietpnMonth();
                lbTBpanelThang.Visible = false;
            }
        }
        public void CreateMonthlyReportExcel(string FilePath)
        {
            Excel.Application Report = new Excel.Application();
            Report.Visible = false;
            Report.DisplayAlerts = false;
            Excel.Workbook workbook = Report.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
            worksheet.Name = "DoanhThu" + cbThang.Text + cbNam.Text;
            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]].Merge();
            worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 5]].Merge();
            worksheet.Cells[1, 1] = "BÁO CÁO DOANH THU BÁN VÉ CÁC CHUYẾN BAY";
            worksheet.Cells[2, 1] = "Tháng " + cbThang.Text + "/" + cbNam.Text;
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã chuyến bay";
            worksheet.Cells[3, 3] = "Số Vé";
            worksheet.Cells[3, 4] = "Doanh Thu (VND)";
            worksheet.Cells[3, 5] = "Tỉ Lệ (%)";
            Excel.Range rangeData = null;
            //Export STT
            for (int j = 0; j < dgvThang.Rows.Count - 1; j++)
            {
                rangeData = (Excel.Range)worksheet.Cells[j+4, 1];
                rangeData.Value2 = j + 1;
            }
            //Export Data
            for (int i = 0; i < dgvThang.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvThang.Columns.Count; j++)
                {
                    rangeData = (Excel.Range)worksheet.Cells[i+4, j + 2];
                    rangeData.Value2 = dgvThang[j, i].Value;
                }
            }
            Excel.Range range = worksheet.Range["A3", "E3"];
            range.EntireColumn.AutoFit();
            int row = dgvThang.Rows.Count + 2;
            worksheet.get_Range("A1", "E" + row.ToString()).Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range = worksheet.Range["A3", "E" + row.ToString()];
            Excel.Borders border = range.Borders;
            border.LineStyle = Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;
            workbook.SaveAs(FilePath);
            workbook.Close();
            Report.Quit();
            System.Diagnostics.Process.Start(FilePath);

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";      
            saveFileDialog1.Title = "Save Excel File";
            saveFileDialog1.FileName = "Báo cáo doanh thu tháng " + cbThang.Text + "-" + cbNam.Text;
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = false;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CreateMonthlyReportExcel(saveFileDialog1.FileName);
            }
        }
        #endregion
        #region PageYear
        public bool CheckDataComboBoxpnYear()
        {
            lbTBpanelNam.ForeColor = Color.Red;
            if (string.IsNullOrWhiteSpace(cbNampanelYear.Text))
            {
                lbTBpanelNam.Text = "Bạn chưa chọn Năm";
                lbTBpanelNam.Visible = true;
                cbNampanelYear.Focus();
                return false;
            }
            int NamInput = int.Parse(cbNampanelYear.Text);
            if (NamInput < 2010 || NamInput > 2020)
            {
                lbTBpanelNam.Text = "Vui lòng nhập Năm trong khoảng từ 2010 đến 2020";
                lbTBpanelNam.Visible = true;
                cbNampanelYear.Focus();
                return false;
            }
            return true;
        }
        public void SetVisibleLabelChiTietpnYear(bool status)
        {
            lbNam.Visible = status;
            lbTongCBNam.Visible = status;
            lbTongDoanhThuNam.Visible = status;
            lbDTThangMax.Visible = status;
            lbDTThangMin.Visible = status;      
        }
        public void HienThongTinChiTietpnYear()
        {
            SetVisibleLabelChiTietpnYear(true);
            lbNam.Text = cbNampanelYear.Text;
            int n = dgvNam.Rows.Count;
            int TongChuyenBay = 0;
            int TongDoanhThu = 0;
            string ThangMax = "", ThangMin = "";
            int DoanhThuMax = 0, DoanhThuMin = 0;
            if (n > 1)
            {
                DoanhThuMin = int.MaxValue;
                for (int i = 0; i < n - 1; i++)
                {
                    TongChuyenBay += int.Parse(dgvNam.Rows[i].Cells["colSoChuyenBay"].Value.ToString());
                    int DoanhThu = int.Parse(dgvNam.Rows[i].Cells["colDoanhThuThang"].Value.ToString());
                    TongDoanhThu += DoanhThu;
                    if (DoanhThu >= DoanhThuMax)
                    {
                        DoanhThuMax = DoanhThu;
                        ThangMax = dgvNam.Rows[i].Cells["colThang"].Value.ToString();
                    }
                    if (DoanhThu <= DoanhThuMin)
                    {
                        DoanhThuMin = DoanhThu;
                        ThangMin = dgvNam.Rows[i].Cells["colThang"].Value.ToString();
                    }
                }
            }
            lbTongCBNam.Text = TongChuyenBay.ToString();
            lbTongDoanhThuNam.Text = TongDoanhThu.ToString() + "VND";
            lbDTThangMax.Text = DoanhThuMax.ToString() + "VND(T" + ThangMax + ")";
            lbDTThangMin.Text = DoanhThuMin.ToString() + "VND(T" + ThangMin + ")";
        }
        public void SetDataBarChart()
        {
            chart1.Titles.Add("Biểu đồ doanh thu năm " + cbNampanelYear.Text);
            for (int i = 0; i < dgvNam.Rows.Count - 1; i++)
            {
                string Thang = dgvNam.Rows[i].Cells["colThang"].Value.ToString();
                string DoanhThu = dgvNam.Rows[i].Cells["colDoanhThuThang"].Value.ToString();
                chart1.Series["Doanh Thu"].Points.AddXY(Thang, DoanhThu);
            }
        }
        public void ClearDataBarChart()
        {
            chart1.Titles.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }
        private void cbNampanelYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThongKeNam_Click(object sender, EventArgs e)
        {
            if (CheckDataComboBoxpnYear())
            {
                btnExcelNam.Visible = true;
                ClearDataBarChart();
                btnExcelNam.Visible = true;
                DataTable dt = bllBaoCao.GetBaoCaoNamCoTiLe(cbNampanelYear.Text);
                dgvNam.DataSource = dt;
                HienThongTinChiTietpnYear();
                lbTBpanelNam.Visible = false;
                SetDataBarChart();
            }
        }
        public void CreateAnnualReportExcel(string FilePath)
        {
            Excel.Application Report = new Excel.Application();
            Report.Visible = false;
            Report.DisplayAlerts = false;
            Excel.Workbook workbook = Report.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
            worksheet.Name = "DoanhThu" + cbNampanelYear.Text;
            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]].Merge();
            worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 5]].Merge();
            worksheet.Cells[1, 1] = "BÁO CÁO DOANH THU NĂM";
            worksheet.Cells[2, 1] = "Năm: " + cbNampanelYear.Text;
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Tháng";
            worksheet.Cells[3, 3] = "Số Chuyến Bay";
            worksheet.Cells[3, 4] = "Doanh Thu (VND)";
            worksheet.Cells[3, 5] = "Tỉ Lệ (%)";
            Excel.Range rangeData = null;
            //Export STT
            for (int j = 0; j < dgvNam.Rows.Count - 1; j++)
            {
                rangeData = (Excel.Range)worksheet.Cells[j + 4, 1];
                rangeData.Value2 = j + 1;
            }
            //Export Data
            for (int i = 0; i < dgvNam.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvNam.Columns.Count; j++)
                {
                    rangeData = (Excel.Range)worksheet.Cells[i + 4, j + 2];
                    rangeData.Value2 = dgvNam[j, i].Value;
                }
            }
            Excel.Range range = worksheet.Range["A3", "E3"];
            range.EntireColumn.AutoFit();
            int row = dgvNam.Rows.Count + 2;
            worksheet.get_Range("A1", "E" + row.ToString()).Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range = worksheet.Range["A3", "E" + row.ToString()];
            Excel.Borders border = range.Borders;
            border.LineStyle = Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;
            workbook.SaveAs(FilePath);
            workbook.Close();
            Report.Quit();
            System.Diagnostics.Process.Start(FilePath);

        }

        private void btnExcelNam_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save Excel File";
            saveFileDialog1.FileName = "Báo cáo doanh thu năm " + cbNampanelYear.Text;
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = false;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CreateAnnualReportExcel(saveFileDialog1.FileName);
            }
        }
        #endregion
    }
}
