using Flight.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
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
    }
}
