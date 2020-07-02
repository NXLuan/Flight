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
            string sql = "select SoGheTrong from DANHSACHGHE where MaChuyenBay = '" + MaChuyenBay + "' and HangVe = N'" + HangVe + "'";

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
        public DataTable getDanhSachGheChuyenBay(string MaChuyenBay)
        {
            string sql = "select DANHSACHGHE.HangVe, TiLe from DANHSACHVE, DANHSACHGHE where DANHSACHGHE.HangVe = DANHSACHVE.HangVe and MaChuyenBay = '" + MaChuyenBay + "'";
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

        public void UpdateSoGheTrong(DanhSachGhe DSG)
        {
            string sql = "update DANHSACHGHE set SoGheTrong = " + DSG.SoGheTrong +
                " where MaChuyenBay = '" + DSG.MaChuyenBay + "' and HangVe = N'" + DSG.HangVe + "'";

            ExcuteNonQuery(sql);
        }
        public void insertDanhSachGhe(DanhSachGhe DSG)
        {
            string sql = "insert into DANHSACHGHE(MaChuyenBay, HangVe, TongSoGhe, SoGheTrong)" +
               " VALUES(@MaChuyenBay, @HangVe, @TongSoGhe, @SoGheTrong)";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = DSG.MaChuyenBay;
                    cmd.Parameters.Add("@HangVe", SqlDbType.NVarChar).Value = DSG.HangVe;
                    cmd.Parameters.Add("@TongSoGhe", SqlDbType.Int).Value = DSG.TongSoGhe;
                    cmd.Parameters.Add("@SoGheTrong", SqlDbType.Int).Value = DSG.SoGheTrong;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void Delete(string MaChuyenBay)
        {
            string sql = "DELETE DANHSACHGHE WHERE MaChuyenBay = @MaChuyenBay";
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
        public bool UpdateDanhSachGhe(DataTable tbDSG)
        {
            if (tbDSG.Rows.Count == 0)
                return true;
            string MaChuyenBay = tbDSG.Rows[0][0].ToString();
            DanhSachGheDAL dalDSG = new DanhSachGheDAL();
            dalDSG.Delete(MaChuyenBay);
            for (int i = 0; i < tbDSG.Rows.Count; i++)
            {

                string sql = "insert into DANHSACHGHE(MaChuyenBay, HangVe, TongSoGhe, SoGheTrong)" +
                " VALUES(@MaChuyenBay, @HangVe, @TongSoGhe, @SoGheTrong)";
                using (SqlConnection con = dc.getConnect())
                {
                    try
                    {
                        cmd = new SqlCommand(sql, con);
                        con.Open();
                        DanhSachGhe DSG = new DanhSachGhe();
                        DSG.MaChuyenBay = tbDSG.Rows[i][0].ToString();
                        DSG.HangVe = tbDSG.Rows[i][1].ToString();
                        DSG.TongSoGhe = Int32.Parse(tbDSG.Rows[i][2].ToString());
                        DSG.SoGheTrong = DSG.TongSoGhe;
                        cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = DSG.MaChuyenBay;
                        cmd.Parameters.Add("@HangVe", SqlDbType.NVarChar).Value = DSG.HangVe;
                        cmd.Parameters.Add("@TongSoGhe", SqlDbType.Int).Value = DSG.TongSoGhe;
                        cmd.Parameters.Add("@SoGheTrong", SqlDbType.Int).Value = DSG.SoGheTrong;
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
        public DataTable getDanhSachGhe(string MaChuyenBay)
        {
            string sql = "select HangVe, TongSoGhe from DANHSACHGHE where MaChuyenBay = '" + MaChuyenBay + "'";
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
        public bool CheckTrungDanhSachGhe(string MaChuyenBay, string HangVe)
        {
            string sql = "select MaChuyenBay, HangVe from DANHSACHGHE where MaChuyenBay = '" + MaChuyenBay + "' and HangVe = N'" + HangVe + "'";
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
