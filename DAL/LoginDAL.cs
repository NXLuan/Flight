using Flight.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight.DAL
{
    class LoginDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public LoginDAL()
        {
            dc = new DataConnection();
        }
        public DataTable GetLogin(string TenDangNhap, string MatKhau)
        {
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter("select * from NGUOIDUNG where TenDangNhap='" + TenDangNhap + "' and MatKhau='" + MatKhau + "'", con);
                    con.Open();
                    da.Fill(dt);
                    da.Dispose();
                    con.Close();
                    return dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}
