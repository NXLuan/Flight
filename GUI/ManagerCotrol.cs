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
    public partial class ManagerCotrol : UserControl
    {
        Control pnSelect;
        Control pnRight;
        Control lbFormName;
        public ManagerCotrol()
        {
            InitializeComponent();
        }
        public ManagerCotrol(Control pnSelect, Control pnRight, Control lbFormName)
        {
            InitializeComponent();
            this.pnSelect = pnSelect;
            this.pnRight = pnRight;
            this.lbFormName = lbFormName;
        }

        private void btQuyDinh_Click(object sender, EventArgs e)
        {
            if (pnSelect.Location == btQuyDinh.Location) return;
            pnSelect.Location = btQuyDinh.Location;

            Regulation search = new Regulation();
            ShowForm(search, "Quy định chuyến bay");
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
