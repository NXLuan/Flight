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
    class ChuyenBayDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public ChuyenBayDAL()
        {
            dc = new DataConnection();
        }

        public DateTime getNgayKhoiHanh(string MaChuyenBay)
        {
            string sql = "select NgayGio from CHUYENBAY where MaChuyenBay = '" + MaChuyenBay + "'";

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

                    return DateTime.Parse(dt.Rows[0][0].ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return DateTime.MinValue;
                }
            }
        }
        public int getDonGia(string MaChuyenBay)
        {
            string sql = "select DonGia from CHUYENBAY where MaChuyenBay = '" + MaChuyenBay + "'";

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
                    return -1;
                }
            }
        }
    }
}
