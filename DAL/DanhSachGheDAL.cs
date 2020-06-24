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
    class DanhSachGheDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public DanhSachGheDAL()
        {
            dc = new DataConnection();
        }

        public void ExcuteNonQuery(string sql)
        {
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    cmd = new SqlCommand(sql, con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public int getSoGheTrong(string MaChuyenBay, string HangVe)
        {
            string sql = "select SoGheTrong from DANHSACHGHE where MaChuyenBay = '" + MaChuyenBay + "' and HangVe = '" + HangVe + "'";

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

        public void UpdateSoGheTrong(DanhSachGhe DSG)
        {
            string sql = "update DANHSACHGHE set SoGheTrong = " + DSG.SoGheTrong +
                " where MaChuyenBay = '" + DSG.MaChuyenBay + "' and HangVe = '" + DSG.HangVe + "'";

            ExcuteNonQuery(sql);
        }
    }
}
