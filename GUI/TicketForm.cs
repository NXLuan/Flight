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
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
            ShowTicket();
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
            Page.SetPage("ReservateList");
        }

        private void btSeclectFlight_Click(object sender, EventArgs e)
        {
            Page.SetPage("tabSearch");
            pnForm.Controls.Clear();

            SearchForm search = new SearchForm();
            search.TopLevel = false;
            pnForm.Controls.Add(search);
            search.Dock = DockStyle.Fill;
            search.Show();
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            Page.SetPage("Ticket");
        }
    }
}
