using Flight.BLL;
using Flight.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight.GUI
{
    public partial class TicketForm : Form
    {
        DanhSachVeBLL bllDSV;
        DanhSachGheBLL bllDSG;
        ChuyenBayBLL bllCB;
        ThamSoBLL bllTS;
        VeChuyenBayBLL bllVCB;
        SearchForm search;

        public TicketForm()
        {
            InitializeComponent();
            ShowTicket();
            bllDSV = new DanhSachVeBLL();
            bllDSG = new DanhSachGheBLL();
            bllCB = new ChuyenBayBLL();
            bllVCB = new VeChuyenBayBLL();
            bllTS = new ThamSoBLL();

            lbNotify.Visible = false;
            lbNotify1.Visible = false;

            cbHangVe.DisplayMember = "HangVe";
            cbHangVe.ValueMember = "TiLe";
        }

        private void lbReservateList_Click(object sender, EventArgs e)
        {
            ShowReservateList();
        }

        private void lbTicket_Click(object sender, EventArgs e)
        {
            ShowTicket();
        }

        public void ShowTicket()
        {
            pnTicket.Visible = true;
            pnReservateList.Visible = false;
            Page.SetPage("Ticket");
        }
        public void ShowReservateList()
        {
            pnTicket.Visible = false;
            pnReservateList.Visible = true;
            Page.SetPage("TicketList");
        }

        private void btSeclectFlight_Click(object sender, EventArgs e)
        {
            Page.SetPage("tabSearch");
            pnForm.Controls.Clear();
            lbNotify1.Visible = false;

            search = new SearchForm();
            search.TopLevel = false;
            pnForm.Controls.Add(search);
            search.Dock = DockStyle.Fill;
            search.Show();
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            Page.SetPage("Ticket");
        }

        public bool CheckInput()
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
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Bạn chưa nhập Email";
                tbSDT.Focus();
                return false;
            }
            if (!CheckEmail(tbEmail.Text))
            {
                lbNotify.ForeColor = Color.Red;
                lbNotify.Text = "Email không hợp lệ";
                tbSDT.Focus();
                return false;
            }
            return true;
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

        bool CheckEmail(string s)
        {
            string Rules = @"^[\w\.]+@[\w]+\.[\w]+";
            Regex MyRegex = new Regex(Rules);
            return MyRegex.IsMatch(s);
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
            cbHangVe.DataSource = bllDSG.getDanhSachGheChuyenBay(tbMaChuyenBay.Text);
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
            if ((bllCB.getNgayKhoiHanh(tbMaChuyenBay.Text) - DateTime.Now).TotalMinutes < 0)
            {
                lbNotify1.Visible = true;
                lbNotify1.Text = "Chuyến bay này đã khởi hành";
                return;
            }
            Page.SetPage("Ticket");
        }

        private void btPrintTicket_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                DialogResult result = MessageBox.Show("Vé đã in sẽ không được thay đổi, bạn chắc chắn thông tin đã chính xác", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    VeChuyenBay VCB = new VeChuyenBay();

                    VCB.MaChuyenBay = tbMaChuyenBay.Text;
                    VCB.HangVe = cbHangVe.Text;
                    VCB.GiaTien = int.Parse(lbGiaTien.Text);
                    VCB.HoTen = tbHoTen.Text;
                    VCB.CMND = tbCMND.Text;
                    VCB.SDT = tbSDT.Text;
                    VCB.Email = tbEmail.Text;

                    if (bllVCB.insertVeChuyenBay(VCB))
                    {
                        lbNotify.Text = "Thành công";
                        lbNotify.ForeColor = Color.FromArgb(8, 186, 29);

                        DanhSachGhe DSG = new DanhSachGhe();
                        DSG.MaChuyenBay = VCB.MaChuyenBay;
                        DSG.HangVe = VCB.HangVe;
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
        }
    }
}
