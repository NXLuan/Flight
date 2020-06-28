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
    class SanBayTrungGianDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public SanBayTrungGianDAL()
        {
            dc = new DataConnection();
        }

        public void insertSanBayTrungGian(SanBayTrungGian SBTG)
        {
            string sql = "insert into SANBAYTRUNGGIAN(MaChuyenBay, MaSanBay, ThoiGianDung, GhiChu)" +
               " VALUES(@MaChuyenBay, @MaSanBay, @ThoiGianDung, @GhiChu)";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = SBTG.MaChuyenBay;
                    cmd.Parameters.Add("@MaSanBay", SqlDbType.VarChar).Value = SBTG.MaSanBay;
                    cmd.Parameters.Add("@ThoiGianDung", SqlDbType.VarChar).Value = (SBTG.ThoiGianDung).ToString();
                    cmd.Parameters.Add("@GhiChu", SqlDbType.VarChar).Value = SBTG.GhiChu;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public DataTable getSanBayTrungGian(string MaChuyenBay)
        {
            string sql = "select MaSanBay, ThoiGianDung, GhiChu from SANBAYTRUNGGIAN where MaChuyenBay = '" + MaChuyenBay + "'";
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
        public void Delete(string MaChuyenBay)
        {
            string sql = "DELETE SANBAYTRUNGGIAN WHERE MaChuyenBay = @MaChuyenBay";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = MaChuyenBay;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool UpdateSanBayTrungGian(DataTable tbSBTG)
        {
            if (tbSBTG.Rows.Count == 0)
                return true;
            string MaChuyenBay = tbSBTG.Rows[0][0].ToString();
            SanBayTrungGianDAL dalSBTG = new SanBayTrungGianDAL();
            dalSBTG.Delete(MaChuyenBay);
            for (int i = 0; i < tbSBTG.Rows.Count; i++)
            {

                string sql = "insert into SANBAYTRUNGGIAN(MaChuyenBay, MaSanBay, ThoiGianDung, GhiChu)" +
               " VALUES(@MaChuyenBay, @MaSanBay, @ThoiGianDung, @GhiChu)";
                using (SqlConnection con = dc.getConnect())
                {
                    try
                    {
                        cmd = new SqlCommand(sql, con);
                        con.Open();
                        SanBayTrungGian SBTG = new SanBayTrungGian();
                        SBTG.MaChuyenBay = tbSBTG.Rows[i][0].ToString();
                        SBTG.MaSanBay = tbSBTG.Rows[i][1].ToString();
                        SBTG.ThoiGianDung = TimeSpan.Parse(tbSBTG.Rows[i][2].ToString());
                        SBTG.GhiChu = tbSBTG.Rows[i][3].ToString();
                        cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = SBTG.MaChuyenBay;
                        cmd.Parameters.Add("@MaSanBay", SqlDbType.VarChar).Value = SBTG.MaSanBay;
                        cmd.Parameters.Add("@ThoiGianDung", SqlDbType.VarChar).Value = (SBTG.ThoiGianDung).ToString();
                        cmd.Parameters.Add("@GhiChu", SqlDbType.VarChar).Value = SBTG.GhiChu;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return true;
        }
        public bool CheckTrungSanBayTrungGian(string MaChuyenBay, string MaSanBay)
        {
            string sql = "select MaChuyenBay, MaSanBay from SANBAYTRUNGGIAN where MaChuyenBay = '" + MaChuyenBay + "' and MaSanBay = '" + MaSanBay + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count == 0) return false;
            return true;
        }
    }
}
