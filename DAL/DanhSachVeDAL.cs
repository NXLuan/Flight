using Flight.DTO;
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
    class DanhSachVeDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public DanhSachVeDAL()
        {
            dc = new DataConnection();
        }
        
        public DataTable getDanhSachVe()
        {
            string sql = "select * from DANHSACHVE";
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
        public int GetSoLuongHangVe()
        {
            string sql = "select count(*) from DANHSACHVE";
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
        public bool InsertHangVe(DanhSachVe[] dsv, int n)
        {
            string HangVe = "", TiLe = "";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    con.Open();
                    for (int i = 0; i < n; i++)
                    {
                        HangVe = dsv[i].HangVe;
                        TiLe = dsv[i].TiLe.ToString();
                        string sql = "insert into DANHSACHVE values('" + HangVe + "', " + TiLe + ")";
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
        public bool DeleteHangVe(string HangVe)
        {
            string sql = "delete from DANHSACHVE where HangVe ='" + HangVe + "'";
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
        public DanhSachVe GetInfo1HangVe(string HV)
        {
            string sql = "select * from DANHSACHVE where HangVe ='" + HV + "'";
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
                DanhSachVe dsv = new DanhSachVe
                {
                    HangVe = HV,
                    TiLe = float.Parse(dt.Rows[0][1].ToString())
                };
                return dsv;
            }
        }
        public bool CheckTrungHangVe(string s)
        {
            string sql = "select HangVe from DANHSACHVE where HangVe = '" + s + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count == 0) return false;
            return true;
        }
        public bool UpdateDanhSachVe(string HV, string TiLe)
        {
            string sql = "update DANHSACHVE set TiLe = '" + TiLe + "' where HangVe ='" + HV + "'";
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
