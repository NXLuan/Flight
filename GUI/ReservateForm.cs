using Flight.BLL;
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

namespace Flight.GUI
{
    public partial class ReservateForm : Form
    {
        DanhSachVeBLL bllDSV;
        PhieuDatChoBLL bllPDC;
        DanhSachGheBLL bllDSG;
        ChuyenBayBLL bllCB;
        ThamSoBLL bllTS;

        SearchForm search;

        public ReservateForm()
        {
            InitializeComponent();
            bllDSV = new DanhSachVeBLL();
            bllPDC = new PhieuDatChoBLL();
            bllTS = new ThamSoBLL();
            bllDSG = new DanhSachGheBLL();
            bllCB = new ChuyenBayBLL();

            lbNotify.Visible = false;
            lbNotify1.Visible = false;

            cbHangVe.DataSource = bllDSV.getDanhSachVe();
            cbHangVe.DisplayMember = "HangVe";
            cbHangVe.ValueMember = "TiLe";
        }

        private void btSelectFlight_Click(object sender, EventArgs e)
        {
            Page.SetPage("tabSearch");
            lbNotify1.Visible = false;
            pnForm.Controls.Clear();

            search = new SearchForm();
            search.TopLevel = false;
            pnForm.Controls.Add(search);
            search.Dock = DockStyle.Fill;
            search.Show();
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            Page.SetPage("tabReservate");
        }

        private void btReservate_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                PhieuDatCho PDC = new PhieuDatCho();

                PDC.MaChuyenBay = tbMaChuyenBay.Text;
                PDC.HangVe = cbHangVe.Text;
                PDC.GiaTien = int.Parse(lbGiaTien.Text);
                PDC.HoTen = tbHoTen.Text;
                PDC.CMND = tbCMND.Text;
                PDC.SDT = tbSDT.Text;
                PDC.MaPhieuDatCho = bllPDC.getMaPhieuDatCho();

                if (bllPDC.insertPhieuDatCho(PDC))
                {
                    lbNotify.Text = "Thành công";
                    lbNotify.ForeColor = Color.FromArgb(8, 186, 29);

                    DanhSachGhe DSG = new DanhSachGhe();
                    DSG.MaChuyenBay = PDC.MaChuyenBay;
                    DSG.HangVe = PDC.HangVe;
                    DSG.SoGheTrong = bllDSG.getSoGheTrong(tbMaChuyenBay.Text, cbHangVe.Text);

                    bllDSG.UpdateSoGheTrong(DSG);
                }
                else
                {
                    lbNotify.ForeColor = Color.Red;
                    lbNotify.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                }
            }
        }

        bool CheckInput()
        {
            lbNotify.Visible = true;

            if (string.IsNullOrEmpty(tbMaChuyenBay.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa chọn chuyến bay";
                return false;
            }
            if (bllDSG.getSoGheTrong(tbMaChuyenBay.Text, cbHangVe.Text) <= 0)
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Đã hết chỗ";
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbHoTen.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập họ tên";
                tbHoTen.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(tbCMND.Text) && !CheckCMND(tbCMND.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "CMND không hợp lệ, CMND phải đủ 9 số";
                tbCMND.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbSDT.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập số điện thoại";
                tbSDT.Focus();
                return false;
            }
            if (!CheckSDT(tbSDT.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Số điện thoại không hợp lệ, bắt đầu từ 0 và từ 9 đến 10 số";
                tbSDT.Focus();
                return false;
            }

            return true;
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            tbMaChuyenBay.Text = search.getMaChuyenBay();

            if (string.IsNullOrEmpty(tbMaChuyenBay.Text))
            {
                lbNotify1.Visible = true;
                lbNotify1.Text = "Bạn chưa chọn chuyến bay";
                return;
            }

            int ThoiGianChoPhepDatVe = bllTS.getThoiGianChoPhepDatVe();

            if (ThoiGianChoPhepDatVe == -1)
            {
                lbNotify1.Visible = true;
                lbNotify1.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                return;
            }
            if ((bllCB.getNgayKhoiHanh(tbMaChuyenBay.Text) - DateTime.Now).TotalDays < ThoiGianChoPhepDatVe)
            {
                lbNotify1.Visible = true;
                lbNotify1.Text = "Chỉ được phép đặt vé chậm nhất " + ThoiGianChoPhepDatVe + " ngày trước khi khởi hành";
                return;
            }
            Page.SetPage("tabReservate");
        }

        bool CheckSDT(string s)
        {
            if (s.Length < 9 || s.Length > 10) return false;
            if (!s.StartsWith("0")) return false;
            return true;
        }

        bool CheckCMND(string s)
        {
            if (s.Length == 9) return true;
            return false;
        }

        private void tbCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbHangVe_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMaChuyenBay.Text)) return;
            lbGiaTien.Text = (bllCB.getDonGia(tbMaChuyenBay.Text) * float.Parse(cbHangVe.SelectedValue.ToString())).ToString();
        }

        private void tbMaChuyenBay_TextChanged(object sender, EventArgs e)
        {
            lbGiaTien.Text = (bllCB.getDonGia(tbMaChuyenBay.Text) * float.Parse(cbHangVe.SelectedValue.ToString())).ToString();
        }
    }
}
