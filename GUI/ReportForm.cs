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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            ShowMonthReport();
        }

        public void ShowMonthReport()
        {
            pnMonth.Visible = true;
            pnYear.Visible = false;
            Page.SetPage("tabMonth");
        }
        public void ShowYearReport()
        {
            pnMonth.Visible = false;
            pnYear.Visible = true;
            Page.SetPage("tabYear");
        }

        private void lbMonth_Click(object sender, EventArgs e)
        {
            ShowMonthReport();
        }

        private void lbYear_Click(object sender, EventArgs e)
        {
            ShowYearReport();
        }
    }
}
