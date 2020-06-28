using Flight.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BLL
{
    class LoginBLL
    {
        LoginDAL dalLogin;
        public LoginBLL()
        {
            dalLogin = new LoginDAL();
        }
        public DataTable GetLogin(string TenDangNhap,string MatKhau)
        {
            return dalLogin.GetLogin(TenDangNhap, MatKhau);
        }
    }
}
