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
    class BaoCaoDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public BaoCaoDAL()
        {
            dc = new DataConnection();
        }
        public DataTable GetDoanhThuThang(string Thang, string Nam)
        {
            string sql = "select CHUYENBAY.MaChuyenBay, count(VECHUYENBAY.MaChuyenBay) as SoVe, sum(GiaTien) as DoanhThu"
            + " from CHUYENBAY left join VECHUYENBAY on (CHUYENBAY.MaChuyenBay = VECHUYENBAY.MaChuyenBay)"
            + " where MONTH(NgayGio) = " + Thang + " and YEAR(NgayGio) = " + Nam 
            + " group by CHUYENBAY.MaChuyenBay";
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
                    return dt;
                }
                catch
                {
                    return null;
                }
            }
        }
        public bool InsertBaoCao(BaoCao baocao)
        {
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    con.Open();
                    string sql = "insert into BAOCAO(MaBaoCao, Thang, Nam, SoChuyenBay, DoanhThu) values(@MaBaoCao, @Thang, @Nam, @SoChuyenBay, @DoanhThu)";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@MaBaoCao", SqlDbType.VarChar).Value = baocao.MaBaoCao;
                    cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = baocao.Thang;
                    cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = baocao.Nam;
                    cmd.Parameters.Add("@SoChuyenBay", SqlDbType.Int).Value = baocao.SoChuyenBay;
                    cmd.Parameters.Add("@DoanhThu", SqlDbType.Money).Value = baocao.DoanhThu;
                    cmd.ExecuteNonQuery();
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
        public bool CheckTrungMaBaoCao(string MaBaoCao)
        {
            string sql = "select MaBaoCao from BAOCAO where MaBaoCao = '" + MaBaoCao + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count == 0) return false;
            return true;
        }
        public DataTable GetBaoCaoNam(string Nam)
        {
            string sql = "select Thang, SoChuyenBay, DoanhThu from BAOCAO where Nam = " + Nam;
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
                    return dt;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
