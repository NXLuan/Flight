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
    }
}
