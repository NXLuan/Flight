using Flight.BLL;
using Flight.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Flight.GUI
{
    public partial class FlightReception : Form
    {
        ChuyenBayBLL bllCB = new ChuyenBayBLL();
        DanhSachGheBLL bllDSG = new DanhSachGheBLL();
        DanhSachVeBLL bllDSV = new DanhSachVeBLL();
        SanBayBLL bllSB = new SanBayBLL();
        SanBayTrungGianBLL bllSBTG = new SanBayTrungGianBLL();
        ThamSoBLL bllTS = new ThamSoBLL();
        ChuyenBay CB = new ChuyenBay();
        DanhSachGhe[] DSG;
        SanBayTrungGian[] SBTG;
        int Index;


        public FlightReception()
        {
            InitializeComponent();
            build_Page_TiepNhanChuyenBay();
            build_Page_DanhSachChuyenBay();
        }
        #region ThaoTacChung
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
        private void lbTiepNhanChuyenBay_Click(object sender, EventArgs e)
        {
            if (lbTiepNhanChuyenBay.ForeColor == Color.Black) return;
            lbDanhSachChuyenBay.ForeColor = Color.Gray;
            lbTiepNhanChuyenBay.ForeColor = Color.Black;
            showTiepNhanLich();
        }
        private void lbDanhSachChuyenBay_Click(object sender, EventArgs e)
        {
            if (lbDanhSachChuyenBay.ForeColor == Color.Black) return;
            lbDanhSachChuyenBay.ForeColor = Color.Black;
            lbTiepNhanChuyenBay.ForeColor = Color.Gray;
            DataTable dt = new DataTable();
            dt = bllCB.getChuyenBay();
            DataGrid_DanhSachChuyenBay.DataSource = dt;
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
        bool checkDateTimeFormat(string s)
        {
            DateTime dt;
            string[] formats = { "yyyy-MM-dd HH:mm" };
            if (!DateTime.TryParseExact(s, formats,
                            System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                return true;
            return false;
        }
        bool checkTimeSpanFormat(string s)
        {
            TimeSpan dt;
            string[] formats = { "HH:mm" };
            if (!TimeSpan.TryParseExact(s, formats,
                            System.Globalization.CultureInfo.InvariantCulture, System.Globalization.TimeSpanStyles.None, out dt))
                return true;
            return false;
        }
        #endregion
        #region Page_TiepNhanChuyenBay
        void build_Page_TiepNhanChuyenBay()
        {
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
        bool CheckInputChuyenBay(ChuyenBay CB)
        {
            if (string.IsNullOrEmpty(CB.MaChuyenBay))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Mã Chuyến Bay chưa được nhập";
                return false;
            }
            if (string.IsNullOrEmpty(CB.DonGia.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Đơn Giá chưa được nhập";
                return false;
            }
            if (string.IsNullOrEmpty(CB.MaSanBayDi))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Mã Sân Bay Đi chưa được nhập";
                return false;
            }
            if (string.IsNullOrEmpty(CB.MaSanBayDen))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Mã Sân Bay Đến chưa được nhập";
                return false;
            }
            if (CB.MaSanBayDi == CB.MaSanBayDen)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Mã Sân Bay Đi không được trùng Mã Sân Bay Đến";
                return false;
            }
            if (string.IsNullOrEmpty(CB.NgayGio.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Ngày Giờ chưa được nhập";
                return false;
            }
            /*   if(checkDateTimeFormat(CB.NgayGio.ToString()))
               {
                   lbNotify.ForeColor = Color.Red;
                   lbNotify.Text = "Bạn nhập sai định dạng ngày giờ";
                   return false;
               } */
            if (string.IsNullOrEmpty(CB.ThoiGianBay.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Thời Gian Bay chưa được nhập";
                return false;
            }
            if ((TimeSpan.Parse(CB.ThoiGianBay.ToString()).Hours * 60 + TimeSpan.Parse(CB.ThoiGianBay.ToString()).Minutes) < bllTS.getThoiGianBayToiThieu())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Thời gian bay nhỏ hơn thời gian bay tối thiểu";
                return false;
            }
            lbNotify.ForeColor = Color.FromArgb(8, 186, 29);
            return true;
        }
        bool CheckInputDanhSachGhe(DanhSachGhe DSG)

        {
            if (string.IsNullOrEmpty(DSG.MaChuyenBay))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Mã Chuyến Bay của Danh Sách Ghế chưa được nhập";
                return false;
            }
            if (string.IsNullOrEmpty(DSG.HangVe))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Hạng Vé chưa được nhập";
                return false;
            }
            if (string.IsNullOrEmpty(DSG.TongSoGhe.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Tổng Số Ghế chưa được nhập";
                return false;
            }
            lbNotify.ForeColor = Color.FromArgb(8, 186, 29);
            return true;
        }
        bool CheckIntputSanBayTrungGian(SanBayTrungGian SBTG)
        {

            if (string.IsNullOrEmpty(SBTG.MaChuyenBay))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Mã Chuyến Bay của Sân Bay Trung Gian chưa được nhập";
                return false;
            }
            if (string.IsNullOrEmpty(SBTG.MaSanBay))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Mã Sân Bay của Sân Bay Trung Gian chưa được nhập";
                return false;
            }
            if (string.IsNullOrEmpty(SBTG.ThoiGianDung.ToString()))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Thời Gian Dừng của Sân Bay Trung Gian chưa được nhập";
                return false;
            }
            if ((TimeSpan.Parse(SBTG.ThoiGianDung.ToString()).Hours * 60 + TimeSpan.Parse(SBTG.ThoiGianDung.ToString()).Minutes) > bllTS.getThoiGianDungToiDa())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Thời Gian Dừng của Sân Bay Trung Gian vượt quá thời gian dừng tối đa";
                return false;
            }
            if ((TimeSpan.Parse(SBTG.ThoiGianDung.ToString()).Hours * 60 + TimeSpan.Parse(SBTG.ThoiGianDung.ToString()).Minutes) < bllTS.getThoiGianDungToiThieu())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Thời Gian Dừng của Sân Bay Trung Gian nhỏ hơn thời gian dừng tối thiểu";
                return false;
            }
            if (string.IsNullOrEmpty(SBTG.GhiChu))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Ghi Chú của Sân Bay Trung Gian chưa được nhập";
                return false;
            }
            lbNotify.ForeColor = Color.FromArgb(8, 186, 29);
            return true;
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
                    ChuyenBay CB = new ChuyenBay();
                    DanhSachGhe DSG = new DanhSachGhe();
                    SanBayTrungGian SBTG = new SanBayTrungGian();
                    if (!string.IsNullOrEmpty(worksheet.Cells[i, 1].Value))
                    {
                        CB.MaChuyenBay = worksheet.Cells[i, 1].Value.ToString();
                        CB.DonGia = decimal.Parse(worksheet.Cells[i, 2].Value.ToString());
                        CB.MaSanBayDi = worksheet.Cells[i, 3].Value.ToString();
                        CB.MaSanBayDen = worksheet.Cells[i, 4].Value.ToString();
                        CB.NgayGio = DateTime.Parse(worksheet.Cells[i, 5].Value.ToString());
                        CB.ThoiGianBay = TimeSpan.Parse(worksheet.Cells[i, 6].Value.ToString());
                        if (!bllCB.CheckTrungChuyenBay(CB.MaChuyenBay))
                            if (CheckInputChuyenBay(CB))
                                bllCB.InsertChuyenBay(CB);
                            else return;
                    }
                    if (!string.IsNullOrEmpty(worksheet.Cells[i, 7].Value))
                    {
                        DSG.MaChuyenBay = worksheet.Cells[i, 7].Value.ToString();
                        DSG.HangVe = worksheet.Cells[i, 8].Value.ToString();
                        DSG.TongSoGhe = Int32.Parse(worksheet.Cells[i, 9].Value.ToString());
                        DSG.SoGheTrong = DSG.TongSoGhe;
                        if (!bllDSG.CheckTrungDanhSachGhe(DSG.MaChuyenBay, DSG.HangVe))
                            if (CheckInputDanhSachGhe(DSG))
                                bllDSG.InsertDanhSachGhe(DSG);
                            else return;
                    }
                    if (!string.IsNullOrEmpty(worksheet.Cells[i, 10].Value))
                    {
                        SBTG.MaChuyenBay = worksheet.Cells[i, 10].Value.ToString();
                        SBTG.MaSanBay = worksheet.Cells[i, 11].Value.ToString();
                        SBTG.ThoiGianDung = TimeSpan.Parse(worksheet.Cells[i, 12].Value.ToString());
                        SBTG.GhiChu = worksheet.Cells[i, 13].Value.ToString();
                        if (!bllSBTG.CheckTrungSanBayTrungGian(SBTG.MaChuyenBay, SBTG.MaSanBay))
                            if (CheckIntputSanBayTrungGian(SBTG))
                                bllSBTG.InsertSanBayTrungGian(SBTG);
                            else return;
                    }
                }
            }
            lbNotify.Visible = true;
            lbNotify.ForeColor = Color.Green;
            lbNotify.Text = "Đã Thêm Danh Sách Các Chuyến Bay Từ File Excel Thành Công";
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
                CB.DonGia = decimal.Parse(Tbx_GiaVe.Text);
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
            if (string.IsNullOrEmpty(Tbx_GiaVe.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập đơn giá";
                return false;
            }
            if (string.IsNullOrEmpty(CBox_SanBayDi.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập sân bay đi";
                return false;
            }
            if (string.IsNullOrEmpty(CBox_SanBayDen.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập sân bay đến";
                return false;
            }
            if (CBox_SanBayDi.Text == CBox_SanBayDen.Text)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Sân Bay Đi không dược trùng Sân Bay Đến";
                return false;
            }
            if (string.IsNullOrEmpty(Tbx_NgayGio.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập ngày giờ";
                return false;
            }
            if (checkDateTimeFormat(Tbx_NgayGio.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn nhập sai định dạng ngày giờ";
                return false;
            }
            if (string.IsNullOrEmpty(Tbx_ThoiGianBay.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập thời gian bay";
                return false;
            }
            /*  if(checkTimeSpanFormat(Tbx_ThoiGianBay.Text))
              {
                  lbNotify.ForeColor = Color.Red;
                  lbNotify.Text = "Bạn nhập sai định dạng thời gian bay";
                  return false;
              } 
              */
            if ((TimeSpan.Parse(Tbx_ThoiGianBay.Text).Hours * 60 + TimeSpan.Parse(Tbx_ThoiGianBay.Text).Minutes) < bllTS.getThoiGianBayToiThieu())
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Thời gian bay nhỏ hơn thời gian bay tối thiểu";
                return false;
            }
            if (CheckSoLuongGhe() == 1)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập thông tin các hạng ghế";
                return false;
            }
            if (CheckSoLuongGhe() == 2)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Các hạng ghế bạn nhập bị trùng";
                return false;
            }
            if(CheckSanBayTrungGian()==-1)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Số lượng sân bay trung gian vượt quá số lượng cho phép";
                return false;
            }
            if (CheckSanBayTrungGian() == 1)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập thông tin các sân bay trung gian";
                return false;
            }
            if (CheckSanBayTrungGian() == 2)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Thời gian dừng nhỏ hơn thời gian dừng tối thiểu";
                return false;
            }
            if (CheckSanBayTrungGian() == -2)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Thời gian dừng lớn hơn thời gian dừng tối thiểu";
                return false;
            }
            if (CheckSanBayTrungGian() == 3)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Sân bay trung gian bị trùng, vui lòng nhập lại";
                return false;
            }
            if (CheckSanBayTrungGian() == 4)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Sân bay trung gian bị trùng với sân bay đi, vui lòng nhập lại";
                return false;
            }
            if (CheckSanBayTrungGian() == 5)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Sân bay trung gian bị trùng với sân bay đến, vui lòng nhập lại";
                return false;
            }
            lbNotify.ForeColor = Color.FromArgb(8, 186, 29);
            return true;
        }
        int CheckSoLuongGhe()
        {
            if (DataGrid_SoLuongGheHangVe.RowCount - 1 == 0) return 1;
            for (int i = 0; i < DataGrid_SoLuongGheHangVe.RowCount - 1; i++)
            {
                if (DataGrid_SoLuongGheHangVe.Rows[i].Cells[0].Value == null || DataGrid_SoLuongGheHangVe.Rows[i].Cells[1].Value == null)
                    return 1;
                for (int j = 0; j < i; j++)
                    if (DataGrid_SoLuongGheHangVe.Rows[i].Cells[0].Value.ToString() == DataGrid_SoLuongGheHangVe.Rows[j].Cells[0].Value.ToString())
                        return 2;
            }
            return 0;
        }
        int CheckSanBayTrungGian()
        {
            if (DataGrid_SanBayTrungGian.RowCount - 1 > bllTS.getSoSanBayTrungGianToiDa())
                return -1;
            for (int i = 0; i < DataGrid_SanBayTrungGian.RowCount - 1; i++)
            {
                if (DataGrid_SanBayTrungGian.Rows[i].Cells[0].Value == null || DataGrid_SanBayTrungGian.Rows[i].Cells[1].Value == null || DataGrid_SanBayTrungGian.Rows[i].Cells[2].Value == null || DataGrid_SanBayTrungGian.Rows[i].Cells[3].Value == null)
                    return 1;
                if ((TimeSpan.Parse(DataGrid_SanBayTrungGian.Rows[i].Cells[2].Value.ToString()).Hours * 60 + TimeSpan.Parse(DataGrid_SanBayTrungGian.Rows[i].Cells[2].Value.ToString()).Minutes) < bllTS.getThoiGianDungToiThieu())
                    return 2;
                if ((TimeSpan.Parse(DataGrid_SanBayTrungGian.Rows[i].Cells[2].Value.ToString()).Hours * 60 + TimeSpan.Parse(DataGrid_SanBayTrungGian.Rows[i].Cells[2].Value.ToString()).Minutes) > bllTS.getThoiGianDungToiDa())
                    return -2;
                for (int j = 0; j < i; j++)
                    if (DataGrid_SanBayTrungGian.Rows[i].Cells[1].Value.ToString() == DataGrid_SanBayTrungGian.Rows[j].Cells[1].Value.ToString())
                        return 3;
                if (DataGrid_SanBayTrungGian.Rows[i].Cells[1].Value.ToString() == CBox_SanBayDi.SelectedValue.ToString())
                    return 4;
                if (DataGrid_SanBayTrungGian.Rows[i].Cells[1].Value.ToString() == CBox_SanBayDen.SelectedValue.ToString())
                    return 5;
            }
            return 0;
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
        #endregion
        #region Page_DanhSachChuyenBay
        void build_Page_DanhSachChuyenBay()
        {
            DataTable dt = new DataTable();
            dt = bllCB.getChuyenBay();
            DataGrid_DanhSachChuyenBay.DataSource = dt;
            DataGridViewImageColumn img_ChinhSua = new DataGridViewImageColumn();
            Image image_ChinhSua = global::Flight.Properties.Resources.edit;
            img_ChinhSua.Image = image_ChinhSua;
            DataGrid_DanhSachChuyenBay.Columns.Add(img_ChinhSua);
            img_ChinhSua.HeaderText = null;
            img_ChinhSua.Name = null;
            DataGridViewImageColumn img_Xoa = new DataGridViewImageColumn();
            Image image_Xoa = global::Flight.Properties.Resources.transparency;
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
            DataGrid_DanhSachChuyenBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGrid_DanhSachChuyenBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void DataGrid_DanhSachChuyenBay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Index == DataGrid_DanhSachChuyenBay.RowCount) return;
            if (e.RowIndex >= 0 && DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].ReadOnly)
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
                    DataGrid_DanhSachChuyenBay.Rows[Index].Cells[0].Value = global::Flight.Properties.Resources.edit;
                    DataGrid_DanhSachChuyenBay.Rows[Index].Cells[1].Value = global::Flight.Properties.Resources.transparency;
                }
            }
            //Click Edit Icon
            else if (e.ColumnIndex == 0)
            {
                if (DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].ReadOnly)
                {
                    DataGrid_DanhSachChuyenBay.Rows[Index].Cells[0].Value = global::Flight.Properties.Resources.save;
                    DataGrid_DanhSachChuyenBay.Rows[Index].Cells[1].Value = global::Flight.Properties.Resources.close;

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
                        DataGrid_DanhSachChuyenBay.Rows[Index].Cells[0].Value = global::Flight.Properties.Resources.edit;
                        DataGrid_DanhSachChuyenBay.Rows[Index].Cells[1].Value = global::Flight.Properties.Resources.transparency;
                    }
                }
            }

        }
        ChuyenBay SetInfoFlightFromDataGridView()
        {
            ChuyenBay CB = new ChuyenBay();
            CB.MaChuyenBay = DataGrid_DanhSachChuyenBay.Rows[Index].Cells[2].Value.ToString();
            CB.DonGia = decimal.Parse(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[3].Value.ToString());
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
            lblNotify1.Visible = true;
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
            /*   if (checkDateTimeFormat(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[6].Value.ToString()))
               {
                   lblNotify1.ForeColor = Color.Red;
                   lblNotify1.Text = "Nhập sai định dạng Ngày-Giờ bay";
                   return false;
               }
               */
            if (string.IsNullOrEmpty(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[7].Value.ToString()))
            {
                lblNotify1.ForeColor = Color.Red;
                lblNotify1.Text = "Bạn chưa nhập Thời gian ";
                return false;
            }
            if ((TimeSpan.Parse(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[7].Value.ToString()).Hours * 60 + TimeSpan.Parse(DataGrid_DanhSachChuyenBay.Rows[Index].Cells[7].Value.ToString()).Minutes) < bllTS.getThoiGianBayToiThieu())
            {
                lblNotify1.ForeColor = Color.Red;
                lblNotify1.Text = "Thời gian bay nhỏ hơn thời gian bay tối thiếu";
                return false;
            }
            int n1 = DataGrid_DanhSachGheP2.RowCount - 1;
            int n2 = DataGrid_SanBayTrungGianP2.RowCount - 1;
            if(n2>bllTS.getSoSanBayTrungGianToiDa())
            {
                lblNotify1.ForeColor = Color.Red;
                lblNotify1.Text = "Số lượng sân bay trung gian vượt quá số lượng sân bay trung gian tối đa ";
                return false;
            }
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
                for (int j = 0; j < i; j++)
                {
                    if (DataGrid_DanhSachGheP2.Rows[i].Cells[0].Value.ToString() == DataGrid_DanhSachGheP2.Rows[j].Cells[0].Value.ToString())
                    {
                        lblNotify1.ForeColor = Color.Red;
                        lblNotify1.Text = "Hạng ghế bị trùng";
                        return false;
                    }
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
                if ((TimeSpan.Parse(DataGrid_SanBayTrungGianP2.Rows[i].Cells[2].Value.ToString()).Hours * 60 + TimeSpan.Parse(DataGrid_SanBayTrungGianP2.Rows[i].Cells[2].Value.ToString()).Minutes) < bllTS.getThoiGianDungToiThieu())
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Thời gian dừng nhỏ hơn thời gian dừng quy định ";
                    return false;
                }
                if ((TimeSpan.Parse(DataGrid_SanBayTrungGianP2.Rows[i].Cells[2].Value.ToString()).Hours * 60 + TimeSpan.Parse(DataGrid_SanBayTrungGianP2.Rows[i].Cells[2].Value.ToString()).Minutes) > bllTS.getThoiGianDungToiDa())
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Thời gian dừng lớn hơn thời gian dừng quy định ";
                    return false;
                }
                if (string.IsNullOrEmpty(DataGrid_SanBayTrungGianP2.Rows[i].Cells[3].Value.ToString()))
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Bạn chưa nhập Ghi Chú ";
                    return false;
                }
                for (int j = 0; j < i; j++)
                {
                    if (DataGrid_SanBayTrungGianP2.Rows[i].Cells[1].Value.ToString() == DataGrid_SanBayTrungGianP2.Rows[j].Cells[1].Value.ToString())
                    {
                        lblNotify1.ForeColor = Color.Red;
                        lblNotify1.Text = "Sân bay trung gian bị trùng";
                        return false;
                    }
                }
                if (DataGrid_DanhSachChuyenBay.Rows[Index].Cells[4].Value.ToString() == DataGrid_SanBayTrungGianP2.Rows[i].Cells[1].Value.ToString())
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Sân bay trung gian bị trùng Sân bay đi";
                    return false;
                }
                if (DataGrid_DanhSachChuyenBay.Rows[Index].Cells[5].Value.ToString() == DataGrid_SanBayTrungGianP2.Rows[i].Cells[1].Value.ToString())
                {
                    lblNotify1.ForeColor = Color.Red;
                    lblNotify1.Text = "Sân bay trung gian bị trùng Sân bay đến";
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
            if (Index == DataGrid_DanhSachChuyenBay.RowCount)
            {
                return;
            }
        }
        #endregion
    }
}
