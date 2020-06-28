﻿using Flight.BLL;
using Flight.DTO;
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

namespace Flight.GUI
{
    public partial class FlightReception : Form
    {
        ChuyenBayBLL bllCB;
        DanhSachGheBLL bllDSG;
        SanBayBLL bllSB;
        SanBayTrungGianBLL bllSBTG;
        DanhSachVeBLL bllDSV;
        ChuyenBay CB = new ChuyenBay();
        DanhSachGhe[] DSG;
        SanBayTrungGian[] SBTG;
        int Index;

        public FlightReception()
        {
            InitializeComponent();
            bllCB = new ChuyenBayBLL();
            bllDSG = new DanhSachGheBLL();
            bllSB = new SanBayBLL();
            bllDSV = new DanhSachVeBLL();
            bllSBTG = new SanBayTrungGianBLL();

            CBox_SanBayDen.DataSource = bllSB.getSanBay();
            CBox_SanBayDen.DisplayMember = "TenSanBay";
            CBox_SanBayDen.ValueMember = "MaSanBay";
            CBox_SanBayDen.Text = null;
            CBox_SanBayDi.DataSource = bllSB.getSanBay();
            CBox_SanBayDi.DisplayMember = "TenSanBay";
            CBox_SanBayDi.ValueMember = "MaSanBay";
            CBox_SanBayDi.Text = null;
            colHangVe.DataSource = bllDSV.getDanhSachVe();
            colHangVe.DisplayMember = "HangVe";
            colSanBayTrungGian.DataSource = bllSB.getSanBay();
            colSanBayTrungGian.DisplayMember = "TenSanBay";
            colSanBayTrungGian.ValueMember = "MaSanBay";
        }

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
        private void btn_Excel_Click(object sender, EventArgs e)
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
                    if (!string.IsNullOrEmpty(worksheet.Cells[i, 1].Value))
                    {
                        ChuyenBay CB = new ChuyenBay();
                        CB.MaChuyenBay = worksheet.Cells[i, 1].Value.ToString();
                        CB.DonGia = Int32.Parse(worksheet.Cells[i, 2].Value.ToString());
                        CB.MaSanBayDi = worksheet.Cells[i, 3].Value.ToString();
                        CB.MaSanBayDen = worksheet.Cells[i, 4].Value.ToString();
                        CB.NgayGio = DateTime.Parse(worksheet.Cells[i, 5].Value.ToString());
                        CB.ThoiGianBay = TimeSpan.Parse(worksheet.Cells[i, 6].Value.ToString());
                        if (!bllCB.CheckTrungChuyenBay(CB.MaChuyenBay))
                            if (CheckinputExcel_ChuyenBay(CB))
                                bllCB.InsertChuyenBay(CB);
                    }
                    if (!string.IsNullOrEmpty(worksheet.Cells[i, 7].Value))
                    {
                        DanhSachGhe DSG = new DanhSachGhe();
                        DSG.MaChuyenBay = worksheet.Cells[i, 7].Value.ToString();
                        DSG.HangVe = worksheet.Cells[i, 8].Value.ToString();
                        DSG.TongSoGhe = Int32.Parse(worksheet.Cells[i, 9].Value.ToString());
                        DSG.SoGheTrong = Int32.Parse(worksheet.Cells[i, 10].Value.ToString());
                        if (!bllDSG.CheckTrungDanhSachGhe(DSG.MaChuyenBay, DSG.HangVe))
                            if (CheckinputExcel_DanhSachGhe(DSG))
                                bllDSG.InsertDanhSachGhe(DSG);
                    }
                    if (!string.IsNullOrEmpty(worksheet.Cells[i, 11].Value))
                    {
                        SanBayTrungGian SBTG = new SanBayTrungGian();
                        SBTG.MaChuyenBay = worksheet.Cells[i, 11].Value.ToString();
                        SBTG.MaSanBay = worksheet.Cells[i, 12].Value.ToString();
                        SBTG.ThoiGianDung = TimeSpan.Parse(worksheet.Cells[i, 13].Value.ToString());
                        SBTG.GhiChu = worksheet.Cells[i, 14].Value.ToString();
                        if (!bllSBTG.CheckTrungSanBayTrungGian(SBTG.MaChuyenBay, SBTG.MaSanBay))
                            if (CheckinputExcel_SanBayTrungGian(SBTG))
                                bllSBTG.InsertSanBayTrungGian(SBTG);
                    }
                }
            }
            lbNotify.ForeColor = Color.Green;
            lbNotify.Text = "Đã Thêm Danh Sách Các Chuyến Bay Từ File Excel Thành Công";
        }
        bool CheckinputExcel_ChuyenBay(ChuyenBay CB)
        {

            if (string.IsNullOrEmpty(CB.MaChuyenBay))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Chuyến Bay";
                return false;
            }
            if (string.IsNullOrEmpty(CB.DonGia.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Đơn Giá";
                return false;
            }
            if (string.IsNullOrEmpty(CB.MaSanBayDi))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Mã Sân Bay Đi";
                return false;
            }
            if (string.IsNullOrEmpty(CB.MaSanBayDen))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Mã Sân Bay Đến";
                return false;
            }
            if (string.IsNullOrEmpty(CB.NgayGio.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Ngày Giờ";
                return false;
            }
            if (string.IsNullOrEmpty(CB.ThoiGianBay.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Ngày Giờ";
                return false;
            }
            lbNotify.ForeColor = Color.FromArgb(8, 186, 29);
            return true;
        }

        bool CheckinputExcel_DanhSachGhe(DanhSachGhe DSG)
        {

            if (string.IsNullOrEmpty(DSG.MaChuyenBay))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Mã Chuyến Bay của Danh Sách Ghế";
                return false;
            }
            if (string.IsNullOrEmpty(DSG.HangVe))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Hạng Vé của Danh Sách Ghế";
                return false;
            }
            if (string.IsNullOrEmpty(DSG.TongSoGhe.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Tổng Số Ghế của Danh Sách Ghế";
            }
            if (string.IsNullOrEmpty(DSG.SoGheTrong.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Số Ghế Trống của Danh Sách Ghế";
                return false;
            }
            lbNotify.ForeColor = Color.FromArgb(8, 186, 29);
            return true;
        }
        bool CheckinputExcel_SanBayTrungGian(SanBayTrungGian SBTG)
        {

            if (string.IsNullOrEmpty(SBTG.MaChuyenBay))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Mã Chuyến Bay của Sân Bay Trung Gian";
                return false;
            }
            if (string.IsNullOrEmpty(SBTG.MaSanBay))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Mã Sân Bay của Sân Bay Trung Gian";
                return false;
            }
            if (string.IsNullOrEmpty(SBTG.ThoiGianDung.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Thời Gian Dừng của Sân Bay Trung Gian";
            }
            if (string.IsNullOrEmpty(SBTG.GhiChu))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "File Excel Nhập sai định dạng Ghi Chú của Sân Bay Trung Gian";
                return false;
            }
            lbNotify.ForeColor = Color.FromArgb(8, 186, 29);
            return true;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (bllCB.CheckTrungChuyenBay(Tbx_MaChuyenBay.Text))
                {
                    lbNotify.ForeColor = Color.Red;
                    lbNotify.Text = "Mã Chuyến Bay bị trùng";
                    return;
                }
                CB.MaChuyenBay = Tbx_MaChuyenBay.Text;
                CB.DonGia = Int32.Parse(Tbx_GiaVe.Text);
                CB.MaSanBayDi = CBox_SanBayDi.SelectedValue.ToString();
                CB.MaSanBayDen = CBox_SanBayDen.SelectedValue.ToString();
                CB.NgayGio = DateTime.ParseExact(Tbx_NgayGio.Text, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                CB.ThoiGianBay = TimeSpan.Parse(Tbx_ThoiGianBay.Text);
                bllCB.InsertChuyenBay(CB);
                int nHangGhe = DataGrid_SoLuongGheHangVe.RowCount - 1;
                DSG = new DanhSachGhe[nHangGhe];
                for (int i = 0; i < nHangGhe; i++)
                {
                    DSG[i] = new DanhSachGhe();
                    DSG[i].HangVe = DataGrid_SoLuongGheHangVe.Rows[i].Cells[0].Value.ToString();
                    DSG[i].MaChuyenBay = CB.MaChuyenBay;
                    DSG[i].TongSoGhe = Int32.Parse(DataGrid_SoLuongGheHangVe.Rows[i].Cells[1].Value.ToString());
                    DSG[i].SoGheTrong = DSG[i].TongSoGhe;
                }

                for (int i = 0; i < nHangGhe; i++)
                {
                    bllDSG.InsertDanhSachGhe(DSG[i]);
                }
                int nSanBayTrungGian = DataGrid_SanBayTrungGian.RowCount - 1;
                SBTG = new SanBayTrungGian[nSanBayTrungGian];
                for (int i = 0; i < nSanBayTrungGian; i++)
                {
                    SBTG[i] = new SanBayTrungGian();
                    SBTG[i].MaChuyenBay = CB.MaChuyenBay;
                    SBTG[i].MaSanBay = DataGrid_SanBayTrungGian.Rows[i].Cells[1].Value.ToString();
                    SBTG[i].ThoiGianDung = TimeSpan.Parse(DataGrid_SanBayTrungGian.Rows[i].Cells[2].Value.ToString());
                    SBTG[i].GhiChu = DataGrid_SanBayTrungGian.Rows[i].Cells[3].Value.ToString();
                }
                for (int i = 0; i < nSanBayTrungGian; i++)
                {
                    bllSBTG.InsertSanBayTrungGian(SBTG[i]);
                }
                lbNotify.ForeColor = Color.Green;
                lbNotify.Text = "Hệ thống đã tiếp nhận chuyến bay";
            }
        }
        bool CheckInput()
        {
            lbNotify.Visible = true;

            if (string.IsNullOrEmpty(Tbx_MaChuyenBay.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa chọn chuyến bay";
                return false;
            }
            if (!CheckDonGia())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập đơn giá";
                return false;
            }
            if (!CheckSanBayDi())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập sân bay đi";
                return false;
            }
            if (!CheckSanBayDen())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập sân bay đến";
                return false;
            }
            if (!CheckNgayGio())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập ngày giờ";
                return false;
            }
            if (!CheckThoiGianBay())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập thời gian bay";
                return false;
            }
            if (!CheckSoLuongGhe())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập thông tin các hạng ghế";
                return false;
            }
            lbNotify.ForeColor = Color.FromArgb(8, 186, 29);
            return true;
        }
        bool CheckMaChuyenBay()
        {
            if (string.IsNullOrWhiteSpace(Tbx_MaChuyenBay.Text))
                return false;
            return true;
        }
        bool CheckDonGia()
        {
            if (string.IsNullOrEmpty(Tbx_GiaVe.Text))
                return false;
            return true;
        }
        bool CheckSanBayDi()
        {
            if (string.IsNullOrEmpty(CBox_SanBayDi.Text))
                return false;
            return true;
        }
        bool CheckSanBayDen()
        {
            if (string.IsNullOrEmpty(CBox_SanBayDen.Text))
                return false;
            return true;
        }
        bool CheckNgayGio()
        {
            if (string.IsNullOrEmpty(Tbx_NgayGio.Text))
                return false;
            return true;
        }
        bool CheckThoiGianBay()
        {
            if (string.IsNullOrEmpty(Tbx_ThoiGianBay.Text))
                return false;
            return true;
        }
        bool CheckSoLuongGhe()
        {
            if (DataGrid_SoLuongGheHangVe.RowCount - 1 == 0) return false;
            for (int i = 0; i < DataGrid_SoLuongGheHangVe.RowCount - 1; i++)
            {
                if (DataGrid_SoLuongGheHangVe.Rows[i].Cells[0].Value == null || DataGrid_SoLuongGheHangVe.Rows[i].Cells[1].Value == null)
                    return false;
            }
            return true;
        }
        bool CheckSanBayTrungGian()
        {
            for (int i = 0; i < DataGrid_SanBayTrungGian.RowCount - 1; i++)
            {
                if (DataGrid_SanBayTrungGian.Rows[i].Cells[0].Value == null || DataGrid_SanBayTrungGian.Rows[i].Cells[1].Value == null || DataGrid_SanBayTrungGian.Rows[i].Cells[2].Value == null || DataGrid_SanBayTrungGian.Rows[i].Cells[3].Value == null)
                    return false;
            }
            return true;
        }
        private void Tbx_GiaVe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Tbx_NgayGio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }

        private void Tbx_ThoiGianBay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }

        private void lbTicket_Click(object sender, EventArgs e)
        {
            if (lbTiepNhanChuyenBay.ForeColor == Color.Black) return;
            lbDanhSachChuyenBay.ForeColor = Color.Gray;
            lbTiepNhanChuyenBay.ForeColor = Color.Black;
            showTiepNhanLich();
        }
        private void lbTicketList_Click(object sender, EventArgs e)
        {
            if (lbDanhSachChuyenBay.ForeColor == Color.Black) return;
            lbDanhSachChuyenBay.ForeColor = Color.Black;
            lbTiepNhanChuyenBay.ForeColor = Color.Gray;
            DataTable dt = new DataTable();
            dt = bllCB.getChuyenBay();
            DataGrid_DanhSachChuyenBay.DataSource = dt;
            DataGridViewImageColumn img_ChinhSua = new DataGridViewImageColumn();
            Image image_ChinhSua = btn_ChinhSua.Image;
            img_ChinhSua.Image = image_ChinhSua;
            DataGrid_DanhSachChuyenBay.Columns.Add(img_ChinhSua);
            img_ChinhSua.HeaderText = null;
            img_ChinhSua.Name = null;
            DataGridViewImageColumn img_Xoa = new DataGridViewImageColumn();
            Image image_Xoa = btn_null.Image;
            img_Xoa.Image = image_Xoa;
            DataGrid_DanhSachChuyenBay.Columns.Add(img_Xoa);
            img_Xoa.HeaderText = null;
            img_Xoa.Name = null;
            DataGrid_DanhSachChuyenBay.Columns[0].HeaderText = "Mã Chuyến bay";
            DataGrid_DanhSachChuyenBay.Columns[1].HeaderText = "Đơn giá";
            DataGrid_DanhSachChuyenBay.Columns[2].HeaderText = "Mã Sân Bay Đi";
            DataGrid_DanhSachChuyenBay.Columns[3].HeaderText = "Mã Sân Bay Đến";
            DataGrid_DanhSachChuyenBay.Columns[4].HeaderText = "Ngày-Giờ";
            DataGrid_DanhSachChuyenBay.Columns[5].HeaderText = "Thời Gian Bay";
            for (int i = 0; i <= 5; i++)
            {
                DataGrid_DanhSachChuyenBay.Columns[i].ReadOnly = true;
            }
            showDanhSachChuyenBay();
        }
        private void showTiepNhanLich()
        {
            pnTiepNhanChuyenBay.Visible = true;
            pnDanhSachChuyenBay.Visible = false;
            bPage.SetPage(tabPage_NhanLichChuyenBay);
        }
        private void showDanhSachChuyenBay()
        {
            pnTiepNhanChuyenBay.Visible = false;
            pnDanhSachChuyenBay.Visible = true;
            bPage.SetPage(tabPage_DanhSachChuyenBay);
        }
        private void DataGrid_DanhSachChuyenBay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Index == DataGrid_DanhSachChuyenBay.RowCount - 1) return;
            if (e.RowIndex > 0 && DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].ReadOnly)
            {
                DataGrid_SanBayTrungGianP2.Columns.Clear();
                DataGrid_DanhSachGheP2.Columns.Clear();
                DanhSachGheBLL bllDSG = new DanhSachGheBLL();
                SanBayTrungGianBLL bllSBTG = new SanBayTrungGianBLL();
                DataTable tbDSG = bllDSG.getDanhSachGhe(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].Value.ToString());
                DataTable tbSBTG = bllSBTG.getSanBayTrungGian(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].Value.ToString());
                DataGridViewTextBoxColumn col_STT = new DataGridViewTextBoxColumn();
                col_STT.HeaderText = "STT";
                col_STT.Name = "colSTT";
                DataGrid_SanBayTrungGianP2.Columns.Add(col_STT);
                DataGrid_DanhSachGheP2.DataSource = tbDSG;
                DataGrid_SanBayTrungGianP2.DataSource = tbSBTG;
                for (int i = 0; i < DataGrid_SanBayTrungGianP2.RowCount - 1; i++)
                    DataGrid_SanBayTrungGianP2.Rows[i].Cells[0].Value = (i + 1).ToString();
                DataGrid_DanhSachGheP2.ReadOnly = true;
                DataGrid_SanBayTrungGianP2.ReadOnly = true;
                DataGrid_DanhSachGheP2.Columns[0].HeaderText = "Hạng Vé";
                DataGrid_DanhSachGheP2.Columns[1].HeaderText = "Số Lượng Ghế";
                DataGrid_SanBayTrungGianP2.Columns[1].HeaderText = "Sân Bay Trung Gian";
                DataGrid_SanBayTrungGianP2.Columns[2].HeaderText = "Thời Gian Dừng";
                DataGrid_SanBayTrungGianP2.Columns[3].HeaderText = "Ghi Chú";
            }
            // Click null Icon
            if (e.ColumnIndex == 1)
            {
                if (DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].ReadOnly == false)
                /*   {
                       DialogResult dlg = MessageBox.Show("Bạn có thật sự muốn xóa thông tin chuyến bay này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                       if (dlg == DialogResult.Yes)
                       {
                           if (bllCB.DeleteChuyenBay(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].Value.ToString()))
                           {
                               DataGrid_DanhSachChuyenBay.Rows.Remove(DataGrid_DanhSachChuyenBay.Rows[Index]);
                               lblNotify1.ForeColor = Color.Lime;
                               lblNotify1.Text = "Xóa chuyến bay thành công";
                           }
                           else
                           {
                               lblNotify1.ForeColor = Color.Red;
                               lblNotify1.Text = " Đã có lỗi xảy ra, vui lòng thử lại sau";
                           }
                       }
                   }                
                   else
                   */
                {
                    DataGrid_SanBayTrungGianP2.Columns.Clear();
                    DataGrid_DanhSachGheP2.Columns.Clear();
                    for (int i = 2; i <= 7; i++)
                        DataGrid_DanhSachChuyenBay.Rows[Index].Cells[i].ReadOnly = true;
                    DataGrid_DanhSachChuyenBay.Rows[Index].Cells[0].Value = btn_ChinhSua.Image;
                    DataGrid_DanhSachChuyenBay.Rows[Index].Cells[1].Value = btn_null.Image;
                }
            }
            //Click Edit Icon
            else if (e.ColumnIndex == 0)
            {
                if (DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].ReadOnly)
                {
                    DataGrid_DanhSachChuyenBay.Rows[Index].Cells[0].Value = btn_Themm.Image;
                    DataGrid_DanhSachChuyenBay.Rows[Index].Cells[1].Value = btn_Huy.Image;

                    for (int i = 2; i <= 7; i++)
                        DataGrid_DanhSachChuyenBay.Rows[Index].Cells[i].ReadOnly = false;
                    DataGrid_DanhSachGheP2.ReadOnly = false;
                    DataGrid_SanBayTrungGianP2.ReadOnly = false;
                }
                else
                {
                    if (CheckInputDataGrid())
                    {
                        for (int i = 2; i <= 7; i++)
                            DataGrid_DanhSachChuyenBay.Rows[Index].Cells[i].ReadOnly = true;
                        DataGrid_DanhSachGheP2.ReadOnly = true;
                        DataGrid_SanBayTrungGianP2.ReadOnly = true;
                        if (bllCB.UpdateChuyenBay(SetInfoFlightFromDataGridView()) && bllDSG.UpdateDanhSachGhe(CapNhatDanhSachGhe()) && bllSBTG.UpdateSanBayTrungGian(CapNhatSanBayTrungGian()))
                        {
                            lblNotify1.ForeColor = Color.Green;
                            lblNotify1.Text = "Lưu thành công";
                        }
                        else
                        {
                            lblNotify1.ForeColor = Color.Red;
                            lblNotify1.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                        }
                        DataGrid_DanhSachChuyenBay.Rows[Index].Cells[0].Value = btn_ChinhSua.Image;
                        DataGrid_DanhSachChuyenBay.Rows[Index].Cells[1].Value = btn_null.Image;
                    }
                }
            }

        }
        ChuyenBay SetInfoFlightFromDataGridView()
        {
            ChuyenBay CB = new ChuyenBay();
            CB.MaChuyenBay = DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].Value.ToString();
            CB.DonGia = Int32.Parse(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[3].Value.ToString());
            CB.MaSanBayDi = DataGrid_DanhSachChuyenBay.Rows[Index].Cells[4].Value.ToString();
            CB.MaSanBayDen = DataGrid_DanhSachChuyenBay.Rows[Index].Cells[5].Value.ToString();
            CB.NgayGio = DateTime.Parse(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[6].Value.ToString());
            CB.ThoiGianBay = TimeSpan.Parse(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[7].Value.ToString());
            return CB;
        }
        DataTable CapNhatDanhSachGhe()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("MaChuyenBay");
            dt.Columns.Add("HangVe");
            dt.Columns.Add("TongSoGhe");
            dt.Columns.Add("SoGheTrong");
            DanhSachGhe DSG = new DanhSachGhe();
            int n = DataGrid_DanhSachGheP2.RowCount - 1;
            for (int i = 0; i < n; i++)
            {
                DataRow dtr = dt.NewRow();
                dtr["MaChuyenBay"] = DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].Value.ToString();
                dtr["HangVe"] = DataGrid_DanhSachGheP2.Rows[i].Cells[0].Value.ToString();
                dtr["TongSoGhe"] = DataGrid_DanhSachGheP2.Rows[i].Cells[1].Value.ToString();
                dtr["SoGheTrong"] = DSG.TongSoGhe;
                dt.Rows.Add(dtr);
            }
            return dt;
        }
        DataTable CapNhatSanBayTrungGian()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("MaChuyenBay");
            dt.Columns.Add("MaSanBay");
            dt.Columns.Add("ThoiGianDung");
            dt.Columns.Add("GhiChu");
            SanBayTrungGian SBTG = new SanBayTrungGian();
            int n = DataGrid_SanBayTrungGianP2.RowCount - 1;
            for (int i = 0; i < n; i++)
            {
                DataRow dtr = dt.NewRow();
                dtr["MaChuyenBay"] = DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].Value.ToString();
                dtr["MaSanBay"] = DataGrid_SanBayTrungGianP2.Rows[i].Cells[1].Value.ToString();
                dtr["ThoiGianDung"] = DataGrid_SanBayTrungGianP2.Rows[i].Cells[2].Value.ToString();
                dtr["GhiChu"] = DataGrid_SanBayTrungGianP2.Rows[i].Cells[3].Value.ToString();
                dt.Rows.Add(dtr);
            }
            return dt;
        }
        bool CheckInputDataGrid()
        {
            lbNotify.Visible = true;
            if (string.IsNullOrEmpty(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].Value.ToString()))
            {
                lblNotify1.ForeColor = Color.Red;
                lblNotify1.Text = "Bạn chưa nhập mã chuyến bay";
                return false;
            }
            if (string.IsNullOrEmpty(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[3].Value.ToString()))
            {
                lblNotify1.ForeColor = Color.Red;
                lblNotify1.Text = "Bạn chưa nhập đơn giá";
                return false;
            }
            if (string.IsNullOrEmpty(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[4].Value.ToString()))
            {
                lblNotify1.ForeColor = Color.Red;
                lblNotify1.Text = "Bạn chưa nhập mã sân bay đi";
                return false;
            }
            if (string.IsNullOrEmpty(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[5].Value.ToString()))
            {
                lblNotify1.ForeColor = Color.Red;
                lblNotify1.Text = "Bạn chưa nhập mã sân bay đến";
                return false;
            }
            if (string.IsNullOrEmpty(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[6].Value.ToString()))
            {
                lblNotify1.ForeColor = Color.Red;
                lblNotify1.Text = "Bạn chưa nhập Ngày-Giờ bay";
                return false;
            }
            if (string.IsNullOrEmpty(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[7].Value.ToString()))
            {
                lblNotify1.ForeColor = Color.Red;
                lblNotify1.Text = "Bạn chưa nhập Thời gian ";
                return false;
            }
            int n1 = DataGrid_DanhSachGheP2.RowCount - 1;
            int n2 = DataGrid_SanBayTrungGianP2.RowCount - 1;
            for (int i = 0; i < n1; i++)
            {
                if (string.IsNullOrEmpty(DataGrid_DanhSachGheP2.Rows[i].Cells[0].Value.ToString()))
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Bạn chưa nhập Hạng Vé ";
                    return false;
                }
                if (string.IsNullOrEmpty(DataGrid_DanhSachGheP2.Rows[i].Cells[1].Value.ToString()))
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Bạn chưa nhập Số Lượng Ghế ";
                    return false;
                }
            }
            for (int i = 0; i < n2; i++)
            {
                if (string.IsNullOrEmpty(DataGrid_SanBayTrungGianP2.Rows[i].Cells[1].Value.ToString()))
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Bạn chưa nhập Sân Bay Trung Gian ";
                    return false;
                }
                if (string.IsNullOrEmpty(DataGrid_SanBayTrungGianP2.Rows[i].Cells[2].Value.ToString()))
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Bạn chưa nhập Thời Gian Dừng ";
                    return false;
                }
                if (string.IsNullOrEmpty(DataGrid_SanBayTrungGianP2.Rows[i].Cells[3].Value.ToString()))
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Bạn chưa nhập Ghi Chú ";
                    return false;
                }
            }
            return true;
        }
        private void DataGrid_DanhSachChuyenBay_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (Index == DataGrid_DanhSachChuyenBay.CurrentCell.RowIndex) return;
                Index = DataGrid_DanhSachChuyenBay.CurrentCell.RowIndex;
            }
            catch
            {
                return;
            }
            if (Index == DataGrid_DanhSachChuyenBay.RowCount - 1)
            {
                return;
            }
        }
    }
}
