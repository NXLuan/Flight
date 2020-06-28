using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flight.DTO;
namespace Flight.DAL
{
    class NguoiDungDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public NguoiDungDAL()
        {
            dc = new DataConnection();
        }
        public List<string> GetListQuyen()
        {
            string sql = "select TenNhom from NHOMNGUOIDUNG";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter(sql, con);
                    con.Open();
                    da.Fill(dt);
                    da.Dispose();
                    con.Close();
                    List<string> listQuyen = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                        listQuyen.Add(dt.Rows[i][0].ToString());
                    return listQuyen;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
        public DataTable getTaiKhoan()
        {
            string sql = "select TenDangNhap, MatKhau, TenNhom as 'Quyen' from NGUOIDUNG, NHOMNGUOIDUNG ";
            sql += "where NGUOIDUNG.MaNhom = NHOMNGUOIDUNG.MaNhom";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter(sql, con);
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
        public int GetSoLuongTaiKhoan()
        {
            string sql = "select count(*) from NGUOIDUNG";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter(sql, con);
                    con.Open();
                    da.Fill(dt);
                    da.Dispose();
                    con.Close();
                    return int.Parse(dt.Rows[0][0].ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }
        public bool InsertTaiKhoan(NguoiDung[] user, int n)
        {
            string TenDN = "", MatKhau = "", MaNhom = "";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    con.Open();
                    for (int i = 0; i < n; i++)
                    {
                        TenDN = user[i].TenDangNhap;
                        MatKhau = user[i].MatKhau;
                        MaNhom = user[i].MaNhom;
                        string sql = "insert into NGUOIDUNG values('" + TenDN + "','" + MatKhau + "','" + MaNhom +"')";
                        cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public bool DeleteNguoiDung(string TenDN)
        {
            string sql = "delete from NGUOIDUNG where TenDangNhap ='" + TenDN + "'";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter(sql, con);
                    con.Open();
                    da.Fill(dt);
                    da.Dispose();
                    con.Close();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public NguoiDung GetInfo1TaiKhoan(string TenDN)
        {
            string sql = "select * from NGUOIDUNG where TenDangNhap ='" + TenDN + "'";
            using (SqlConnection con = dc.getConnect())
            {
                DataTable dt = new DataTable();
                try
                {
                    da = new SqlDataAdapter(sql, con);
                    con.Open();
                    da.Fill(dt);
                    da.Dispose();
                    con.Close();
                }
                catch
                {
                    return null;
                }
                NguoiDung nd = new NguoiDung
                {
                    TenDangNhap = TenDN,
                    MatKhau = dt.Rows[0][1].ToString(),
                    MaNhom = dt.Rows[0][2].ToString(),
                };
                return nd;
            }
        }
        public bool CheckTrungTenDN(string s)
        {
            string sql = "select TenDangNhap from NGUOIDUNG where TenDangNhap = '" + s + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count == 0) return false;
            return true;
        }
        public bool UpdateTaiKhoan(string TenDN, string MatKhau, string MaNhom)
        {
            string sql = "update NGUOIDUNG set MatKhau = '" + MatKhau + "', MaNhom = '" + MaNhom + "' ";
            sql += "where TenDangNhap ='" + TenDN + "'";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter(sql, con);
                    con.Open();
                    da.Fill(dt);
                    da.Dispose();
                    con.Close();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}

