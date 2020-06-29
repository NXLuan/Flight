using Flight.BLL;
using Flight.DTO;
using Flight.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight
{
    public partial class MainForm : Form
    {
        static public string nguoiDung = null;
        AdminControl adminControl;
        ManagerCotrol managerCotrol;
        StaffControl staffControl;

        ThamSoBLL bllTS;
        PhieuDatChoBLL bllPDC;
        DanhSachGheBLL bllDSG;

        Thread thread;
        bool isRunning;

        public MainForm()
        {
            InitializeComponent();
            bllTS = new ThamSoBLL();
            bllPDC = new PhieuDatChoBLL();
            bllDSG = new DanhSachGheBLL();

            pnSelect.Location = new Point(-1, -1);
            pnSelect.Visible = false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btReservate_Click(object sender, EventArgs e)
        {
            if (pnSelect.Location == btReservate.Location) return;
            pnSelect.Location = btReservate.Location;

            ReservateForm reservate = new ReservateForm();
            ShowForm(reservate, "Phiếu đặt chỗ");
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            pnSelect.Location = new Point(-1, -1);
            pnSelect.Visible = false;
            lbFormName.Text = "Màn hình chính";
            pnRight.Controls.Clear();
            if (btLogin.ButtonText == "Đăng nhập")
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                if (loginForm.close) return;
                if (nguoiDung == "AD")
                {
                    adminControl = new AdminControl(pnSelect, pnRight, lbFormName);
                    adminControl.Dock = DockStyle.Top;
                    this.pnFunction.Controls.Add(adminControl);
                }
                else if (nguoiDung == "QL")
                {
                    managerCotrol = new ManagerCotrol(pnSelect, pnRight, lbFormName);
                    managerCotrol.Dock = DockStyle.Top;
                    this.pnFunction.Controls.Add(managerCotrol);
                }
                else if (nguoiDung == "NV")
                {
                    staffControl = new StaffControl(pnSelect, pnRight, lbFormName);
                    staffControl.Dock = DockStyle.Top;
                    this.pnFunction.Controls.Add(staffControl);
                }
                else return;
                btLogin.ButtonText = "Đăng xuất";
            }
            else if (btLogin.ButtonText == "Đăng xuất")
            {
                btLogin.ButtonText = "Đăng nhập";
                if (nguoiDung == "AD")
                {
                    this.pnFunction.Controls.Remove(adminControl);
                }
                else if (nguoiDung == "QL")
                {
                    this.pnFunction.Controls.Remove(managerCotrol);
                }
                else if (nguoiDung == "NV")
                {
                    this.pnFunction.Controls.Remove(staffControl);
                }
            }
        }

        private void btFlightSearch_Click(object sender, EventArgs e)
        {
            if (pnSelect.Location == btFlightSearch.Location) return;
            pnSelect.Location = btFlightSearch.Location;

            SearchForm search = new SearchForm();
            ShowForm(search, "Tra cứu chuyến bay");
        }

        void ShowForm(Form Name, string state)
        {
            pnSelect.Visible = true;
            pnRight.Controls.Clear();
            lbFormName.Text = state;
            Name.TopLevel = false;
            pnRight.Controls.Add(Name);
            Name.Dock = DockStyle.Fill;
            Name.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (thread == null)
            {
                isRunning = true;
                thread = new Thread(procedure_UpdatePhieuDat);
                thread.IsBackground = true;
                thread.Start();
            }
        }
        public void procedure_UpdatePhieuDat()
        {
            while (isRunning)
            {
                if (bllTS.getQuyDinhHuy() <= 0) return;
                DataTable dt = bllPDC.getThongTinPhieuHuy();
                if (dt == null) return;
                for (int i =0; i< dt.Rows.Count; i++)
                {
                    DanhSachGhe DSG = new DanhSachGhe();
                    DSG.MaChuyenBay = dt.Rows[i][1].ToString();
                    DSG.HangVe = dt.Rows[i][2].ToString();
                    DSG.SoGheTrong = bllDSG.getSoGheTrong(DSG.MaChuyenBay, DSG.HangVe) + 1;

                    bllDSG.UpdateSoGheTrong(DSG);
                    bllPDC.HuyPhieuDatCho(dt.Rows[i][0].ToString());
                }
                dt.Dispose();
            }
        }
    }
}
