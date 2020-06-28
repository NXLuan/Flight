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
    public partial class AdminControl : UserControl
    {
        Control pnSelect;
        Control pnRight;
        Control lbFormName;
        public AdminControl()
        {
            InitializeComponent();
        }
        public AdminControl(Control pnSelect, Control pnRight, Control lbFormName)
        {
            InitializeComponent();
            this.pnSelect = pnSelect;
            this.pnRight = pnRight;
            this.lbFormName = lbFormName;
        }

        private void btPhanQuyen_Click(object sender, EventArgs e)
        {
            if (pnSelect.Location == btPhanQuyen.Location) return;
            pnSelect.Location = btPhanQuyen.Location;

            AccountForm account = new AccountForm();
            ShowForm(account, "Quản lý tài khoản");
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
