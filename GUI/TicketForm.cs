using Flight.BLL;
using Flight.DTO;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Flight.GUI
{
    public partial class TicketForm : Form
    {
        DanhSachGheBLL bllDSG;
        ChuyenBayBLL bllCB;
        ThamSoBLL bllTS;
        VeChuyenBayBLL bllVCB;
        PhieuDatChoBLL bllPDC;
        SearchForm search;
        int Id;

        public TicketForm()
        {
            InitializeComponent();
            ShowTicket();
            bllDSG = new DanhSachGheBLL();
            bllCB = new ChuyenBayBLL();
            bllVCB = new VeChuyenBayBLL();
            bllPDC = new PhieuDatChoBLL();
            bllTS = new ThamSoBLL();

            lbNotify.Visible = false;
            lbNotify1.Visible = false;

            cbHangVe.DisplayMember = "HangVe";
            cbHangVe.ValueMember = "TiLe";

            cbTrangThai.Text = "Chưa thanh toán";

            LockCotrol();
        }

        private void lbReservateList_Click(object sender, EventArgs e)
        {
            if (lbTicketList.ForeColor == Color.Black) return;
            lbTicketList.ForeColor = Color.Black;
            lbTicket.ForeColor = Color.Gray;
            ShowReservateList();
        }

        private void lbTicket_Click(object sender, EventArgs e)
        {
            if (lbTicket.ForeColor == Color.Black) return;
            lbTicketList.ForeColor = Color.Gray;
            lbTicket.ForeColor = Color.Black;
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
            lbNotify.Visible = false;
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
                    if (btEdit.Text != "Hủy" && btSell.Text != "Hủy")
                    {
                        if (bllPDC.getTrangThai(dataGridPhieuDat.Rows[Id].Cells["colMaPhieuDat"].Value.ToString()) == "Chưa xuất vé")
                            bllPDC.UpdateTrangThai(dataGridPhieuDat.Rows[Id].Cells["colMaPhieuDat"].Value.ToString(), "Đã xuất vé");
                        else
                        {
                            lbNotify.Visible = true;
                            lbNotify.ForeColor = Color.Red;
                            lbNotify.Text = "Vé đã được xuất hoặc bị hủy";
                            return;
                        }
                    }
                    else
                      if (btEdit.Text == "Hủy")
                    {
                        if (bllPDC.getTrangThai(dataGridPhieuDat.Rows[Id].Cells["colMaPhieuDat"].Value.ToString()) == "Chưa xuất vé")
                        {
                            PhieuDatCho PDC = new PhieuDatCho();

                            PDC.MaPhieuDatCho = dataGridPhieuDat.Rows[Id].Cells["colMaPhieuDat"].Value.ToString();
                            PDC.MaChuyenBay = tbMaChuyenBay.Text;
                            PDC.HangVe = cbHangVe.Text;
                            PDC.GiaTien = int.Parse(lbGiaTien.Text);
                            PDC.TrangThai = "Đã xuất vé";
                            PDC.HoTen = tbHoTen.Text;
                            PDC.CMND = tbCMND.Text;
                            PDC.SDT = tbSDT.Text;
                            PDC.Email = tbEmail.Text;
                            bllPDC.UpdatePhieuDatCho(PDC);

                            btEdit.Text = "Chỉnh sửa";
                            btSell.Enabled = true;
                        }
                        else
                        {
                            lbNotify.Visible = true;
                            lbNotify.ForeColor = Color.Red;
                            lbNotify.Text = "Vé đã được xuất hoặc bị hủy";
                            btEdit.Text = "Chỉnh sửa";
                            btSell.Enabled = true;
                            return;
                        }
                    }
                    else if (btSell.Text == "Hủy")
                    {
                        LockCotrol();
                        btSell.Text = "Bán vé";
                        btEdit.Enabled = true;
                    }

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
                        lbNotify.Visible = true;
                        lbNotify.Text = "Thành công";
                        lbNotify.ForeColor = Color.FromArgb(8, 186, 29);

                        DanhSachGhe DSG = new DanhSachGhe();
                        DSG.MaChuyenBay = VCB.MaChuyenBay;
                        DSG.HangVe = VCB.HangVe;
                        DSG.SoGheTrong = bllDSG.getSoGheTrong(tbMaChuyenBay.Text, cbHangVe.Text);

                        bllDSG.UpdateSoGheTrong(DSG);
                        tbMaChuyenBay.Text = "";
                        tbHoTen.Text = "";
                        tbSDT.Text = "";
                        tbCMND.Text = "";
                        tbEmail.Text = "";
                        lbGiaTien.Text = "0";
                    }
                    else
                    {
                        lbNotify.ForeColor = Color.Red;
                        lbNotify.Text = "Đã có lỗi xảy ra, vui lòng thử lại sau";
                    }
                }
            }
        }

        private void dataGridPhieuDat_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridPhieuDat.CurrentCell == null)
            {
                btEdit.Enabled = false;
                tbMaChuyenBay.Text = "";
                tbHoTen.Text = "";
                tbSDT.Text = "";
                tbCMND.Text = "";
                tbEmail.Text = "";
                lbGiaTien.Text = "0";
                return;
            }
            Id = dataGridPhieuDat.CurrentCell.RowIndex;
            btEdit.Enabled = true;

            tbMaChuyenBay.Text = dataGridPhieuDat.Rows[Id].Cells["colMaChuyenBay"].Value.ToString();
            cbHangVe.Text = dataGridPhieuDat.Rows[Id].Cells["colHangVe"].Value.ToString();
            tbHoTen.Text = dataGridPhieuDat.Rows[Id].Cells["colHoTen"].Value.ToString();
            tbCMND.Text = dataGridPhieuDat.Rows[Id].Cells["colCMND"].Value.ToString();
            tbSDT.Text = dataGridPhieuDat.Rows[Id].Cells["colSDT"].Value.ToString();
            tbEmail.Text = dataGridPhieuDat.Rows[Id].Cells["colEmail"].Value.ToString();
        }

        public void LockCotrol()
        {
            btSelectFlight.Enabled = false;
            cbHangVe.Enabled = false;
            tbHoTen.Enabled = false;
            tbSDT.Enabled = false;
            tbCMND.Enabled = false;
            tbEmail.Enabled = false;
        }
        public void UnLockCotrol()
        {
            btSelectFlight.Enabled = true;
            cbHangVe.Enabled = true;
            tbHoTen.Enabled = true;
            tbSDT.Enabled = true;
            tbCMND.Enabled = true;
            tbEmail.Enabled = true;
        }

        private void btSell_Click(object sender, EventArgs e)
        {
            lbNotify.Visible = false;
            if (btSell.Text == "Hủy")
            {
                LockCotrol();
                btSell.Text = "Bán vé";
                btEdit.Enabled = true;

                tbMaChuyenBay.Text = "";
                tbHoTen.Text = "";
                tbSDT.Text = "";
                tbCMND.Text = "";
                tbEmail.Text = "";
                lbGiaTien.Text = "0";
                return;
            }
            btSell.Text = "Hủy";
            btEdit.Enabled = false;
            UnLockCotrol();
            tbMaChuyenBay.Text = "";
            tbHoTen.Text = "";
            tbSDT.Text = "";
            tbCMND.Text = "";
            tbEmail.Text = "";
            lbGiaTien.Text = "0";
        }

        private void btSelectFlight_Click(object sender, EventArgs e)
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

        private void btEdit_Click(object sender, EventArgs e)
        {
            lbNotify.Visible = false;
            if (btEdit.Text == "Hủy")
            {
                LockCotrol();
                btEdit.Text = "Chỉnh sửa";
                btSell.Enabled = true;
                tbMaChuyenBay.Text = dataGridPhieuDat.Rows[Id].Cells["colMaChuyenBay"].Value.ToString();
                cbHangVe.Text = dataGridPhieuDat.Rows[Id].Cells["colHangVe"].Value.ToString();
                tbHoTen.Text = dataGridPhieuDat.Rows[Id].Cells["colHoTen"].Value.ToString();
                tbCMND.Text = dataGridPhieuDat.Rows[Id].Cells["colCMND"].Value.ToString();
                tbSDT.Text = dataGridPhieuDat.Rows[Id].Cells["colSDT"].Value.ToString();
                tbEmail.Text = dataGridPhieuDat.Rows[Id].Cells["colEmail"].Value.ToString();
                return;
            }
            btEdit.Text = "Hủy";
            btSell.Enabled = false;
            UnLockCotrol();
        }

        private void tbSearch_OnValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearch.Text)) return;
            dataGridPhieuDat.DataSource = bllPDC.getInforPhieuDatCho(tbSearch.Text);
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
                tbSearch.Text = "Tìm kiếm";
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.Text = "";
        }

        private void cbTrangThai_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridPhieuDat.DataSource = bllPDC.getInforPhieuDatCho(cbTrangThai.Text);
        }
        private void dataGridPhieuDat_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridPhieuDat.RowCount; i++)
            {
                if (dataGridPhieuDat.Rows[i].Cells["colTrangThai"].Value.ToString() == "Đã xuất vé")
                {
                    dataGridPhieuDat.Rows[i].Cells["colTrangThai"].Style.ForeColor = Color.FromArgb(8, 186, 29);
                }
                else if (dataGridPhieuDat.Rows[i].Cells["colTrangThai"].Value.ToString() == "Đã hủy")
                {
                    dataGridPhieuDat.Rows[i].Cells["colTrangThai"].Style.ForeColor = Color.Red;
                }
                else if (dataGridPhieuDat.Rows[i].Cells["colTrangThai"].Value.ToString() == "Chưa xuất vé")
                {
                    dataGridPhieuDat.Rows[i].Cells["colTrangThai"].Style.ForeColor = Color.FromArgb(252, 193, 41);
                }
            }
        }

        private void TicketForm_Load(object sender, EventArgs e)
        {
            if (dataGridPhieuDat.CurrentCell == null)
            {
                btEdit.Enabled = false;
                tbMaChuyenBay.Text = "";
                tbHoTen.Text = "";
                tbSDT.Text = "";
                tbCMND.Text = "";
                tbEmail.Text = "";
                lbGiaTien.Text = "0";
            }
        }

        private void tbSearchVe_OnValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearchVe.Text)) return;
            datagridVe.DataSource = bllVCB.getInforVeChuyenBay(tbSearchVe.Text);
        }

        private void tbSearchVe_Leave(object sender, EventArgs e)
        {
            if (tbSearchVe.Text == "")
                tbSearchVe.Text = "Tìm kiếm";
        }

        private void tbSearchVe_Enter(object sender, EventArgs e)
        {
            tbSearchVe.Text = "";
        }
    }
}
