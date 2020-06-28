using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight.GUI
{
    public partial class StaffControl : UserControl
    {
        Control pnSelect;
        Control pnRight;
        Control lbFormName;
        public StaffControl()
        {
            InitializeComponent();
        }
        public StaffControl(Control pnSelect, Control pnRight, Control lbFormName)
        {
            InitializeComponent();
            this.pnSelect = pnSelect;
            this.pnRight = pnRight;
            this.lbFormName = lbFormName;
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

        private void btFlightReception_Click(object sender, EventArgs e)
        {
            if (pnSelect.Location == btFlightReception.Location) return;
            pnSelect.Location = btFlightReception.Location;

            FlightReception search = new FlightReception();
            ShowForm(search, "Nhận lịch chuyến bay");
        }

        private void btSellTicket_Click(object sender, EventArgs e)
        {
            if (pnSelect.Location == btSellTicket.Location) return;
            pnSelect.Location = btSellTicket.Location;

            TicketForm search = new TicketForm();
            ShowForm(search, "Bán vé chuyến bay");
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            if (pnSelect.Location == btReport.Location) return;
            pnSelect.Location = btReport.Location;

            ReportForm search = new ReportForm();
            ShowForm(search, "Lập báo cáo chuyến bay");
        }
    }
}
