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
    class ChuyenBayDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public ChuyenBayDAL()
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

        public DateTime getNgayKhoiHanh(string MaChuyenBay)
        {
            string sql = "select NgayGio from CHUYENBAY where MaChuyenBay = '" + MaChuyenBay + "'";

            DataTable dt = GetData(sql);
            if (dt != null) return DateTime.Parse(dt.Rows[0][0].ToString());
            return DateTime.MinValue;
        }
        public int getDonGia(string MaChuyenBay)
        {
            string sql = "select DonGia from CHUYENBAY where MaChuyenBay = '" + MaChuyenBay + "'";

            DataTable dt = GetData(sql);
            if (dt != null) return int.Parse(dt.Rows[0][0].ToString());
            return -1;
        }

        public DataTable getThongTinChuyenBay(string NgayGio, string SanBayDi, string SanBayDen)
        {
            string sql = "select CHUYENBAY.MaChuyenBay, DI.TenSanBay as SanBayDi, DEN.TenSanBay as SanBayDen, NgayGio, ThoiGianBay, SUM(SoGheTrong) as SoGheTrong, SUM(TongSoGhe) - SUM(SoGheTrong) as SoGheDat " +
                   "from CHUYENBAY, SANBAY DI, SANBAY DEN, DANHSACHGHE " +
                   "where CHUYENBAY.MaSanBayDi = DI.MaSanBay and CHUYENBAY.MaSanBayDen = DEN.MaSanBay and CHUYENBAY.MaChuyenBay = DANHSACHGHE.MaChuyenBay and CONVERT(date, NgayGio) = '" + NgayGio + "' and DI.TenSanBay = N'" + SanBayDi + "' and DEN.TenSanBay = N'" + SanBayDen + "' " +
                   "group by DANHSACHGHE.MaChuyenBay, CHUYENBAY.MaChuyenBay, DI.TenSanBay, DEN.TenSanBay, NgayGio, ThoiGianBay";

            return GetData(sql);
        }
        public DataTable getChuyenBay()
        {
            string sql = "select * from CHUYENBAY";
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
        public void insertChuyenBay(ChuyenBay CB)
        {
            string sql = "insert into CHUYENBAY(MaChuyenBay, DonGia, MaSanBayDen, MaSanBayDi, NgayGio, ThoiGianBay)" +
               " VALUES(@MaChuyenBay, @DonGia, @MaSanBayDen, @MaSanBayDi, @NgayGio, @ThoiGianBay)";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = CB.MaChuyenBay;
                    cmd.Parameters.Add("@DonGia", SqlDbType.Int).Value = CB.DonGia;
                    cmd.Parameters.Add("@MaSanBayDen", SqlDbType.VarChar).Value = CB.MaSanBayDen;
                    cmd.Parameters.Add("@MaSanBayDi", SqlDbType.VarChar).Value = CB.MaSanBayDi;
                    cmd.Parameters.Add("@NgayGio", SqlDbType.DateTime).Value = CB.NgayGio;
                    cmd.Parameters.Add("@ThoiGianBay", SqlDbType.VarChar).Value = (CB.ThoiGianBay).ToString();


                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public bool DeleteChuyenBay(string MaChuyenBay)
        {
            string sql = "DELETE CHUYENBAY WHERE MaChuyenBay = @MaChuyenBay";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MSSV", SqlDbType.VarChar).Value = MaChuyenBay;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool UpdateChuyenBay(ChuyenBay CB)
        {
            string sql = "UPDATE CHUYENBAY SET MaChuyenBay = @MaChuyenBay, DonGia = @DonGia, MaSanBayDi = @MaSanBayDi, MaSanBayDen = @MaSanBayDen," +
                " NgayGio = @NgayGio, ThoiGianBay = @ThoiGianBay WHERE MaChuyenBay = @MaChuyenBay";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = CB.MaChuyenBay;
                cmd.Parameters.Add("@DonGia", SqlDbType.Int).Value = CB.DonGia;
                cmd.Parameters.Add("@MaSanBayDen", SqlDbType.VarChar).Value = CB.MaSanBayDen;
                cmd.Parameters.Add("@MaSanBayDi", SqlDbType.VarChar).Value = CB.MaSanBayDi;
                cmd.Parameters.Add("@NgayGio", SqlDbType.DateTime).Value = CB.NgayGio;
                cmd.Parameters.Add("@ThoiGianBay", SqlDbType.VarChar).Value = (CB.ThoiGianBay).ToString();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool CheckTrungChuyenBay(string MaChuyenBay)
        {
            string sql = "select MaChuyenBay from CHUYENBAY where MaChuyenBay = '" + MaChuyenBay + "'";
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
