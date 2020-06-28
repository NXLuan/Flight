using Flight.BLL;
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
    public partial class LoginForm : Form
    {
        LoginBLL bllLogin;
        public LoginForm()
        {
            InitializeComponent();
            bllLogin = new LoginBLL();

            lbNotify.Visible = false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string TenDangNhap = this.tbAccount.Text;
            string MatKhau = this.tbPassword.Text;
            DataTable dt = bllLogin.GetLogin(TenDangNhap, MatKhau);

            if (dt.Rows.Count != 0)
            {
                MainForm.nguoiDung = dt.Rows[0][2].ToString();
                this.Close();
            }
            else
            {
                lbNotify.Visible = true;
            }
        }
    }
}
