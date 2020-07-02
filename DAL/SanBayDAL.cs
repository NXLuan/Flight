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
    class SanBayDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public SanBayDAL()
        {
            dc = new DataConnection();
        }

        public DataTable GetData(string sql)
        {
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

        public DataTable getSanBay()
        {
            string sql = "select * from SANBAY";

            return GetData(sql);
        }

        public bool CheckTrungMaSB(string s)
        {
            string sql = "select MaSanBay from SanBay where MaSanBay = '" + s + "'";

            DataTable dt = GetData(sql);

            if (dt.Rows.Count == 0) return false;
            return true;
        }
        public bool InsertSanBay(SanBay[] sanbay, int n)
        {
            string MaSanBay = "", TenSanBay = "";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    con.Open();
                    for (int i = 0; i < n; i++)
                    {
                        MaSanBay = sanbay[i].MaSanBay;
                        TenSanBay = sanbay[i].TenSanBay;
                        string sql = "insert into SANBAY values('" + MaSanBay + "', N'" + TenSanBay + "')";
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
        public int GetSoLuongSanBay()
        {
            string sql = "select count(*) from SANBAY";

            DataTable dt = GetData(sql);
            if (dt == null) return -1;
            return int.Parse(dt.Rows[0][0].ToString());
        }
        public SanBay GetInfo1SanBay(string MaSB)
        {
            string sql = "select * from SANBAY where MaSanBay ='" + MaSB + "'";

            DataTable dt = GetData(sql);
            if (dt == null) return null;

            SanBay sb = new SanBay
            {
                MaSanBay = MaSB,
                TenSanBay = dt.Rows[0][1].ToString()
            };
            return sb;
        }
        public bool DeleteSanBay(string MaSanBay)
        {
            string sql = "delete from SANBAY where MaSanBay ='" + MaSanBay + "'";
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
        public bool UpdateSanBay(string MaSB, string TenSB)
        {
            string sql = "update SANBAY set TenSanBay = N'" + TenSB + "' where MaSanBay ='" + MaSB + "'";
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
